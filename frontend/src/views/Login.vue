<template>
  <div>
    <div>
      <img src="../assets/navbar.png" alt width="100%">
    </div>
    <div class="container h-100">
      <h2 class="text-center">Вход</h2>
      <br>
      <div class="row h-100 justify-content-center align-items-center">
        <form @submit.prevent="logIn">
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
          <button type="submit" class="btn btn-primary">Войти</button>
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
const bloodTypesList = ["I", "II", "III", "IV"];
const rhesusFactorsList = ["+", "-"];
export default {
  name: "Login",
  data() {
    return {
      password: null,
      email: null
    };
  },
  created() {
    console.log(this, this.$router);
  },
  computed: {},
  methods: {
    ...mapMutations([
      "SET_AUTHENTICATED",
      "SET_ACCOUNT_TYPE",
      "SET_BLOOD_TYPE"
    ]),
    logIn() {
      firebase
        .auth()
        .signInWithEmailAndPassword(this.email, this.password)
        .then(data => {
          axios.get("");
          Cookie.set("token", data.user.ra);
          axios
            .get(`http://192.168.32.77:3000/auth/${data.user.uid}`)
            .then(({ data }) => {
              this.SET_AUTHENTICATED(true);
              if (data.isDonor) {
                this.SET_ACCOUNT_TYPE("donor");
              } else {
                this.SET_ACCOUNT_TYPE("hospital");
              }
              this.$router.push("/");
            });
        })
        .catch(error => {
          console.log(error);
        });
    }
  }
};
</script>

<style >
</style>