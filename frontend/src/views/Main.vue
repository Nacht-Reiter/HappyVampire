<template>
  <div>hello world</div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import axios from "axios";
import db from "../firebase";

const provider = db.provider;
const firebase = db.app;

export default {
  name: "Main",
  methods: {
    ...mapActions(["initState"])
  },
  computed: {
    ...mapGetters(["test"])
  }
};
</script>

<style>
</style>