<template>
  <div>
    <div>
      <img src="../../assets/navbar.png" alt width="100%">
    </div>
    <!--<div class="container hospitalRegistration">-->
    <div></div>
    <div class="container h-100">
      <h2 class="text-center">Регистрации поликлиники</h2>
      <br>
      <div class="row h-100 justify-content-center align-items-center">
        <form>
          <div class="form-group">
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
            <label for="exampleInputEmail1">Введите название</label>
            <input
              type="text"
              class="form-control"
              v-model="hospital.name"
              id="name"
              aria-describedby="name"
              placeholder="Введите название"
            >
          </div>
          <div class="form-group">
            <label for="exampleInputCoordinates">Введите координаты</label>
            <input
              type="text"
              class="form-control"
              v-model="hospital.coordinates"
              id="coordinates"
              aria-describedby="coordinates"
              placeholder="Введите координаты"
            >
          </div>
          <div class="form-group">
            <label for="exampleInputAddress">Введите адрес</label>
            <input
              type="text"
              class="form-control"
              v-model="hospital.address"
              id="address"
              aria-describedby="address"
              placeholder="Введите адрес"
            >
          </div>
          <button type="submit" class="btn btn-primary" @click.prevent="addHospital">Submit</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import { mapMutations } from "vuex";
import Cookie from "js-cookie";
import firebase from "firebase";

export default {
  name: "Registration",
  data() {
    return {
      password: null,
      email: null,
      hospital: {
        name: "",
        coordinates: "",
        address: ""
      }
    };
  },
  methods: {
    ...mapMutations(["SET_AUTHENTICATED", "SET_ACCOUNT_TYPE"]),
    addUserToFirebase() {
      return firebase
        .auth()
        .createUserWithEmailAndPassword(this.email, this.password)
        .catch(console.error);
    },
    async addHospitalToDb(token, uid) {
      try {
        const res = await axios.post(
          `http://${this.$store.getters.server.ip}:${
            this.$store.getters.server.port
          }/auth/hospital/${uid}`,
          {
            name: this.hospital.name,
            coordinates: this.hospital.coordinates,
            address: this.hospital.address
          }
        );
        console.log(res)
        // return
        if (res) {
          Cookie.set("token", token);
          Cookie.set("userStatus", "hospital");
          this.$store.state.hospital.id = res.data.id
          this.SET_AUTHENTICATED(true);
          this.SET_ACCOUNT_TYPE("hospital");
        }

        this.$router.push({ path: "/" });
      } catch (e) {
        console.log(e);
      }
    },

    addHospital() {
      this.addUserToFirebase().then(
        data => data && this.addHospitalToDb(data.user.ra, data.user.uid)
      );
    }
  }
};
</script>

<style scoped>
.title {
  font-weight: bold;
}
</style>