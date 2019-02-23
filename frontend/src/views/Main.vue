<template>
  <div>
    <PatientForm></PatientForm>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import axios from "axios";
import db from "../firebase";
import PatientForm from "../components/PatientForm.vue";

const provider = db.provider;
const firebase = db.app;

export default {
  name: "Main",
  methods: {
    ...mapActions(["initState"])
  },
  components: {
    PatientForm
  },
  computed: {
    ...mapGetters(["test"])
  }
};
</script>

<style>
</style>