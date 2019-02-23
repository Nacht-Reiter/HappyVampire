<template>
  <div>
    <div v-if="authenticated">
      <div v-if="accountType === 'hospital'">Авторизовано как поликлиника
        <main-hospital></main-hospital>
      </div>
      <div v-else>Авторизовано как донор
        <main-donor></main-donor>
      </div>
    </div>
    <div v-else>НЕ Авторизовано
      <my-header></my-header>
      <info-headline></info-headline>
      <choose-account-type></choose-account-type>
      <my-footer></my-footer>
    </div>
  </div>
</template>

<script>
import { mapActions, mapGetters } from "vuex";
import axios from "axios";
import db from "../firebase";
// import PatientForm from "../components/PatientForm.vue";
import Header from "../components/Main/Header";
import Footer from "../components/Main/Footer";
import InfoHeadline from "../components/Main/InfoHeadline";
import ChooseAccountType from "../components/Main/ChooseAccountType";
import MainDonor from "../components/MainDonor/Index";
import MainHospital from "../components/MainHospital/Index";

export default {
  name: "Main",
  created() {
    this.initState();
  },
  components: {
    "my-header": Header,
    "choose-account-type": ChooseAccountType,
    "my-footer": Footer,
    "info-headline": InfoHeadline,
    "main-donor": MainDonor,
    "main-hospital": MainHospital,
  },
  methods: {
    ...mapActions(["initState"])
  },
  computed: {
    ...mapGetters(["accountType", "authenticated"])
  }
};
</script>

<style>
.container {
  max-width: 960px;
}

/*
 * Custom translucent site header
 */

.site-header {
  background-color: rgba(0, 0, 0, 0.85);
  -webkit-backdrop-filter: saturate(180%) blur(20px);
  backdrop-filter: saturate(180%) blur(20px);
}
.site-header a {
  color: #999;
  transition: ease-in-out color 0.15s;
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
  background-color: rgba(255, 255, 255, 0.1);
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

.overflow-hidden {
  overflow: hidden;
}

.bg-light {
  background-color: #ffffff !important;
}

.bg-light-custom {
  background-color: #f8f9fa !important;
}
</style>