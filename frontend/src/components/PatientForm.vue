<template>
  <div>
    <b-form @submit>
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
      <b-form-group label="Blood type:" label-for="bloodTypeSelect">
        <b-form-select
          id="bloodTypeSelect"
          :options="bloodTypesList"
          required
          v-model="bloodTypesList"
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
        <img v-if="picture.url" class="small-image" :src="picture.url">
      </b-form-group>
      <b-button type="submit" class="mr-2" variant="primary">Submit</b-button>
      <b-button type="reset" variant="danger">Reset</b-button>
      <input type="file" style="display:none" ref="impick" @change="pickImage">
    </b-form>
  </div>
</template>

<script>
import firebase from "firebase";
const bloodTypesList = ["1", "2", "3", "4"];
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
      }
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
        })
        .catch(console.error);
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
