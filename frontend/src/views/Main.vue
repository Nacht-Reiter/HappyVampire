<template>
  <div>


<div v-if="authenticated">

<router-link :to="{ name: 'registerHospital'}">hospital</router-link>
<br>
<router-link :to="{ name: 'registerDonor'}">donor</router-link>

<img src="../assets/navbar.png" alt="" width="100%">
<div class="position-relative overflow-hidden p-3 p-md-5 m-md-3 text-center bg-light-custom">
    <div class="col-md-5 p-lg-5 mx-auto my-5">
      <h1 class="display-4 font-weight-normal">Punny headline</h1>
      <p class="lead font-weight-normal">And an even wittier subheading to boot. Jumpstart your marketing efforts with this example based on Apple’s marketing pages.</p>
    </div>
  </div>

  <div class="d-md-flex flex-md-equal w-100 my-md-3 pl-md-3">
    <div class="mr-md-3 pt-3 px-3 pt-md-5 px-md-5 text-center overflow-hidden"
         style="background-color: #A4DAD8">
      <div class="my-3 py-3">
        <h2 class="display-5">Донор</h2>
        <p class="lead">Если ты желаешь помочь.</p>
      </div>
      <a href="#">
        <div class="bg-light shadow-sm mx-auto" style="width: 80%; height: 440px; border-radius: 21px 21px 0 0;">
          <img src="../assets/donor.jpg" width="300" alt="donor_picture">
        </div>
      </a>
    </div>
    <div class="bg-light mr-md-3 pt-3 px-3 pt-md-5 px-md-5 text-center overflow-hidden">
      <div class="my-3 p-3">
        <h2 class="display-5">Клиника</h2>
        <p class="lead">Если вам требуется донорская помощь.</p>
      </div>
      <a href="#">
        <div class="shadow-sm mx-auto" style="width: 80%; height: 440px; border-radius: 21px 21px 0 0; background-color: #A4DAD8">
          <img src="../assets/hospital.png" width="300" alt="hospital_picture" style="padding: 170px 0 0 0;">
        </div>
      </a>
    </div>
  </div>


  <footer class="container py-5">
    <div class="row">
      <div class="col-12 col-md">
        <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" fill="none" stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" class="d-block mb-2" role="img" viewBox="0 0 24 24"><title>Product</title><circle cx="12" cy="12" r="10"/><path d="M14.31 8l5.74 9.94M9.69 8h11.48M7.38 12l5.74-9.94M9.69 16L3.95 6.06M14.31 16H2.83m13.79-4l-5.74 9.94"/></svg>
        <!-- <small class="d-block mb-3 text-muted">&copy; 2017-{{ site.time | date: "%Y" }}</small> -->
      </div>
      <div class="col-6 col-md">
        <h5>Features</h5>
        <ul class="list-unstyled text-small">
          <li><a class="text-muted" href="#">Cool stuff</a></li>
          <li><a class="text-muted" href="#">Random feature</a></li>
          <li><a class="text-muted" href="#">Team feature</a></li>
          <li><a class="text-muted" href="#">Stuff for developers</a></li>
          <li><a class="text-muted" href="#">Another one</a></li>
          <li><a class="text-muted" href="#">Last time</a></li>
        </ul>
      </div>
      <div class="col-6 col-md">
        <h5>Resources</h5>
        <ul class="list-unstyled text-small">
          <li><a class="text-muted" href="#">Resource</a></li>
          <li><a class="text-muted" href="#">Resource name</a></li>
          <li><a class="text-muted" href="#">Another resource</a></li>
          <li><a class="text-muted" href="#">Final resource</a></li>
        </ul>
      </div>
      <div class="col-6 col-md">
        <h5>Resources</h5>
        <ul class="list-unstyled text-small">
          <li><a class="text-muted" href="#">Business</a></li>
          <li><a class="text-muted" href="#">Education</a></li>
          <li><a class="text-muted" href="#">Government</a></li>
          <li><a class="text-muted" href="#">Gaming</a></li>
        </ul>
      </div>
      <div class="col-6 col-md">
        <h5>About</h5>
        <ul class="list-unstyled text-small">
          <li><a class="text-muted" href="#">Team</a></li>
          <li><a class="text-muted" href="#">Locations</a></li>
          <li><a class="text-muted" href="#">Privacy</a></li>
          <li><a class="text-muted" href="#">Terms</a></li>
        </ul> 
      </div>
    </div>
  </footer>

</div>
<div v-else>
  
  <div v-if="accountType === 'hospital'">
    <div class="addPatient">
        <button class="addPatientBtn">Добавить больного</button>
    </div>
    <div class="patientList">
        
        <button class="patientListBtn">Список больных</button>
    </div>
  </div>
  <div v-else> 

    <div class="recepientList">
        <button class="recepientListBtn">Найти рецепиента</button>
    </div>
  </div>

</div>

    </div>

</template>

<script>
import {mapActions, mapGetters} from 'vuex';
// import db from '../firebase'

// const provider = db.provider;
// const firebase = db.app;

export default {
  name: "Main",
  created(){
    this.initState()
    // this.signInWithGoogle()
  },
  methods: {
    ...mapActions(['initState']),

//     signInWithGoogle() {
//       firebase.auth().signInWithPopup(provider).then(function(result) {
//   // This gives you a Google Access Token. You can use it to access the Google API.
//   var token = result.credential.accessToken;
//   // The signed-in user info.
//   var user = result.user;
//   console.log('Success')
//   // ...
// }).catch(function(error) {
//   // Handle Errors here.
//   var errorCode = error.code;
//   var errorMessage = error.message;
//   // The email of the user's account used.
//   var email = error.email;
//   // The firebase.auth.AuthCredential type that was used.
//   var credential = error.credential;
//   // ...
// });

      // console.log(firebase.auth.GoogleAuthProvider())
    // }

  },
  computed: {
    ...mapGetters(['accountType', 'authenticated'])
  }
};
</script>

<style scoped>


.container {
  max-width: 960px;
}

/*
 * Custom translucent site header
 */

.site-header {
  background-color: rgba(0, 0, 0, .85);
  -webkit-backdrop-filter: saturate(180%) blur(20px);
  backdrop-filter: saturate(180%) blur(20px);
}
.site-header a {
  color: #999;
  transition: ease-in-out color .15s;
}
.site-header a:hover {
  color: #fff;
  text-decoration: none;
}

/*
 * Dummy devices (replace them with your own or something else entirely!)
 */

.product-device {
  position: absolute;
  right: 10%;
  bottom: -30%;
  width: 300px;
  height: 540px;
  background-color: #333;
  border-radius: 21px;
  -webkit-transform: rotate(30deg);
  transform: rotate(30deg);
}

.product-device::before {
  position: absolute;
  top: 10%;
  right: 10px;
  bottom: 10%;
  left: 10px;
  content: "";
  background-color: rgba(255, 255, 255, .1);
  border-radius: 5px;
}

.product-device-2 {
  top: -25%;
  right: auto;
  bottom: 0;
  left: 5%;
  background-color: #e5e5e5;
}


/*
 * Extra utilities
 */

.flex-equal > * {
  -ms-flex: 1;
  flex: 1;
}
@media (min-width: 768px) {
  .flex-md-equal > * {
    -ms-flex: 1;
    flex: 1;
  }
}

.overflow-hidden { overflow: hidden; }

.bg-light {
  background-color: #ffffff!important;
}

.bg-light-custom {
  background-color: #F8F9FA!important;
}


</style>