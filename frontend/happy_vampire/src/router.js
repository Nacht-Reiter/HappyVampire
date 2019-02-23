import Vue from "vue";
import Router from "vue-router";
import Main from "./views/Main.vue";
import Patients from "./views/Patients.vue";
import Registration from "./views/Registration.vue";

Vue.use(Router);

export default new Router({
  mode: "history",
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/",
      name: "Main",
      component: Main
    },
    {
      path: "/patients",
      name: "Patients",
      component: Patients
    },
    {
      path: "/registration",
      name: "Registration",
      component: Registration
    }
  ]
});
