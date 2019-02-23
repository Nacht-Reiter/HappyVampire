<template>
  <div>
    {{ test }}
  </div>
</template>

<script>
import {mapActions, mapGetters} from 'vuex';
import db from '../firebase'

const provider = db.provider;
const firebase = db.app;

export default {
  name: "Main",
  created(){
    this.initState()
    this.signInWithGoogle()
  },
  methods: {
    ...mapActions(['initState']),

    signInWithGoogle() {
      firebase.auth().signInWithPopup(provider).then(function(result) {
  // This gives you a Google Access Token. You can use it to access the Google API.
  var token = result.credential.accessToken;
  // The signed-in user info.
  var user = result.user;
  console.log('Success')
  // ...
}).catch(function(error) {
  // Handle Errors here.
  var errorCode = error.code;
  var errorMessage = error.message;
  // The email of the user's account used.
  var email = error.email;
  // The firebase.auth.AuthCredential type that was used.
  var credential = error.credential;
  // ...
});

      // console.log(firebase.auth.GoogleAuthProvider())
    }

  },
  computed: {
    ...mapGetters(['test'])
  }
};
</script>

<style>
</style>