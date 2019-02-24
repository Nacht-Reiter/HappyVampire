<template>
  <div>
    <div>
      <img src="../../assets/navbar.png" alt="" width="100%">
    </div>
    <!--<div class="container hospitalRegistration">-->
    <div>
    </div>
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
              <input type="text" class="form-control" v-model="hospital.name" id="name" aria-describedby="name" placeholder="Введите название">
            </div>
            <div class="form-group">
              <label for="exampleInputCoordinates">Введите координаты</label>
              <input type="text" class="form-control" v-model="hospital.coordinates" id="coordinates" aria-describedby="coordinates" placeholder="Введите координаты">
            </div>
            <div class="form-group">
              <label for="exampleInputAddress">Введите адрес</label>
              <input type="text" class="form-control"  v-model="hospital.address" id="address" aria-describedby="address" placeholder="Введите адрес">
            </div>
            <button type="submit" class="btn btn-primary" @click.prevent="addHospital">Submit</button>
          </form>
        </div>
    </div>
  </div>
</template>

<script>
import axios from "axios"

import firebase from "firebase";

export default {
  name: "Registration",
  data(){
    return {
      password: null,
      email: null,
      hospital: {
        name: '',
        coordinates: '',
        address: '',
      }
    }
  },
  // created(){
  //   console.log(this.$router)
  // },
  methods: {
    addUserToFirebase() {
      return firebase
        .auth()
        .createUserWithEmailAndPassword(this.email, this.password)
        .catch(console.error);
    },
    async addHospitalToDb(){
      try{
        const res = await axios.post(`http://${this.$store.getters.server.ip}:${this.$store.getters.server.port}/hospital`, {
          "name": this.name,
          "coordinates": this.coordinates,
          "address": this.address
        })
        console.log("Hospital succssfully created", res)
        
        this.$router.push({ path: "/"})
      } catch(e){
        console.log(e)
      }
    },

    addHospital() {
      this.addUserToFirebase().then(data =>
        this.addHospitalToDb({ ...this.hospital, token: data.user.ra })
      );
    }

  }
};
</script>

<style scoped>


.title{
  font-weight: bold
}

</style>