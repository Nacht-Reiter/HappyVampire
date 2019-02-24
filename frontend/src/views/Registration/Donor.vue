<template>
  <div>
    <div>
      <img src="../../assets/navbar.png" alt width="100%">
    </div>
    <div class="container h-100">
      <h2 class="text-center">Регистрации донора</h2>
      <br>
      <div class="row h-100 justify-content-center align-items-center">
        <form @submit.prevent="addUser">
          <div class="form-group">
            <label for="exampleInputName">Введите имя</label>
            <input
              type="text"
              class="form-control"
              id="name"
              v-model="name"
              aria-describedby="name"
              placeholder="Введите имя"
            >
          </div>
          <div class="form-group">
            <label for="exampleInputName">Введите пароль</label>
            <input
              type="password"
              v-model="password"
              class="form-control"
              id="password"
              placeholder="Введите пароль"
            >
          </div>
          <div class="form-group">
            <label for="exampleInputName">Введите email</label>
            <input type="email" class="form-control" v-model="email" placeholder="Введите email">
          </div>
          <div class="form-group">
            <label for="exampleInputBloodtype">Введите тип крови</label>
            <b-form-select
              id="resusFactorSelect"
              :options="bloodTypesList"
              required
              v-model="bloodType"
            />
          </div>
          <div class="form-group">
            <label for="exampleInputBloodtype">Введите резус-фактор</label>
            <b-form-select
              id="resusFactorSelect"
              :options="rhesusFactorsList"
              required
              v-model="rhesusFactor"
            />
          </div>
          <div class="form-group">
            <label for="exampleInputTelephone">Введите номер телефона</label>
            <input
              type="text"
              class="form-control"
              v-model="phone"
              placeholder="Введите номер телефона"
            >
          </div>
          <button type="submit" class="btn btn-primary">Submit</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import firebase from "firebase";
import axios from "axios";
import Cookie from "js-cookie";
import { mapMutations } from "vuex";
const bloodTypesList = ["1", "2", "3", "4"];
const rhesusFactorsList = ["+", "-"];
export default {
  name: "Registration",
  data() {
    return {
      name: null,
      bloodType: null,
      rhesusFactor: null,
      password: null,
      email: null,
      phone: null,
      imageIsLoading: false,
      formIsLoading: false,
      patientIsAdded: false
    };
  },
  computed: {
    bloodTypesList: () => bloodTypesList,
    rhesusFactorsList: () => rhesusFactorsList,
    donor() {
      return {
        fullName: this.name,
        bloodType: this.bloodType + this.rhesusFactor,
        rating: 0
      };
    }
  },
  methods: {
    ...mapMutations(["SET_AUTHENTICATED", "SET_ACCOUNT_TYPE"]),
    addUserToFirebase() {
      return firebase
        .auth()
        .createUserWithEmailAndPassword(this.email, this.password)
        .catch(console.error);
    },
    addUserToDb(donor) {
      axios
        .post("http://192.168.32.77:3000/donor", donor)
        .then(() => {
          Cookie.set("token", donor.token);
          Cookie.set("userStatus", "donor");
        })
        .then(() => {
          this.SET_AUTHENTICATED(true);
          this.SET_ACCOUNT_TYPE("donor");
          this.$router.push("/");
        })
        .catch(console.error);
    },
    addUser() {
      this.addUserToFirebase().then(
        data => data && this.addUserToDb({ ...this.donor, token: data.user.ra })
      );
    }
  }
};
</script>

<style >
</style>