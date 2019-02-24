<template>
  <div>
    <div>
      <img src="../../assets/navbar.png" alt width="100%">
    </div>
    <h2 class="text-center">Регистрации больного</h2>
    <br>
    <div class="row h-100 justify-content-center align-items-center">
      <b-form @submit.prevent="postPatient">
        <b-form-group label="Name:" label-for="nameInput">
          <b-form-input id="nameInput" v-model="name" required placeholder="Enter patient name"/>
        </b-form-group>
        <b-form-group label="Diagnosis:" label-for="diagnosisInput">
          <b-form-input
            id="diagnosisInput"
            v-model="diagnosis"
            required
            placeholder="Enter patient diagnosis"
          />
        </b-form-group>
        <b-form-group label="Motivation Letter" label-for="motivationLetterText">
          <b-form-textarea
            id="motivationLetterText"
            v-model="motivationLetter"
            placeholder="Add motivation letter"
            rows="3"
            max-rows="6"
          />
        </b-form-group>
        <b-form-group label="Blood type:" label-for="bloodTypeSelect">
          <b-form-select
            id="bloodTypeSelect"
            :options="bloodTypesList"
            required
            v-model="bloodType"
          />
        </b-form-group>
        <b-form-group label="Resus factor:" label-for="resusFactorSelect">
          <b-form-select
            id="resusFactorSelect"
            :options="rhesusFactorsList"
            required
            v-model="rhesusFactor"
          />
        </b-form-group>
        <b-form-group>
          <b-button @click="callImagePicker" variant="primary">Pick an image</b-button>
          <div v-if="imageIsLoading">
            <img src="../../assets/giphy.gif">
          </div>
          <div v-else-if="picture.url">
            <br>
            <img width="300px" :src="picture.url">
            <br>
          </div>
        </b-form-group>
        <div>
          <img v-if="formIsLoading" src="../../assets/giphy.gif">
          <b-button v-else type="submit" class="mr-2" variant="primary">Submit</b-button>
        </div>
        <b-button v-if="patientIsAdded" type="reset">Finish with that</b-button>
        <input type="file" style="display:none" ref="impick" @change="pickImage">
      </b-form>
    </div>
  </div>
</template>

<script>
import db from "../../firebase.js";
const firebase = db.firebase;
import axios from "axios";
const bloodTypesList = ["I", "II", "III", "IV"];
const rhesusFactorsList = ["+", "-"];
export default {
  name: "PatientForm",
  data() {
    return {
      name: null,
      motivationLetter: null,
      bloodType: null,
      rhesusFactor: null,
      diagnosis: null,
      picture: {
        name: null,
        file: null,
        url: null
      },
      imageIsLoading: false,
      formIsLoading: false,
      patientIsAdded: false
    };
  },
  computed: {
    bloodTypesList: () => bloodTypesList,
    rhesusFactorsList: () => rhesusFactorsList
  },
  methods: {
    callImagePicker() {
      this.$refs.impick.click();
    },
    cleanData() {
      this.name = null;
      this.motivationLetter = null;
      this.bloodType = null;
      this.rhesusFactor = null;
      this.diagnosis = null;
      this.picture = {
        name: null,
        file: null,
        url: null
      };
      this.imageIsLoading = false;
      this.formIsLoading = false;
    },
    pickImage(event) {
      const images = event.target.files;
      const img = images[0];
      const imgName = img.name;
      const fileReader = new FileReader();

      this.picture.name = img.name;
      if (imgName.lastIndexOf(".") <= 0) {
        return alert("picked file is not valid");
      }

      fileReader.readAsDataURL(img);
      fileReader.addEventListener("load", () => {
        this.imageIsLoading = true;
        this.picture.file = img;
        this.addToFireBase();
      });
    },
    addToFireBase() {
      const pictureName = this.picture.name;
      const firebaseImageRef = firebase
        .storage()
        .ref(`patients/${pictureName}`);

      firebaseImageRef
        .put(this.picture.file)
        .then(() => {
          firebaseImageRef
            .getDownloadURL()
            .then(url => (this.picture.url = url));
          this.imageIsLoading = false;
        })
        .catch(e => {
          console.error(e);
          this.imageIsLoading = false;
        });
    },
    postPatient() {
      this.formIsLoading = true;
      const formData = {
        fullName: this.name,
        motivationLetter: this.motivationLetter,
        bloodType: this.bloodType + this.rhesusFactor,
        diagnosis: this.diagnosis,
        photo: this.picture.url
      };
      axios
        .post(`http://${this.$store.state.server.ip}:${this.$store.state.server.port}/hospital/patient/${this.$store.state.hospital.id}`, formData)
        .then(data => {
          this.formIsLoading = false;
          this.patientIsAdded = true;
          this.cleanData();
          // router
          this.$router.push("/");
        })
        .catch(e => {
          this.formIsLoading = false;
        });
    }
  }
};
</script>

<style>
.small-image {
  height: 100px;
  width: 100px;
}
</style>
