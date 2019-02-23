<template>
  <div>
    <div class="indigo btn" @click="callImagePicker">pick an image</div>
    <input type="file" style="display:none" ref="impick" @change="pickImage">
    <div @click="addToFireBase">add to firebase</div>
  </div>
</template>

<script>
import firebase from "firebase";
export default {
  name: "PatientForm",
  data() {
    return {
      picture: {
        name: null,
        file: null,
        url: null
      }
    };
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

<style >
</style>
