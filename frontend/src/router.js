import Vue from "vue";
import Router from "vue-router";
import Main from "./views/Main.vue";
import Patients from "./views/Patients.vue";
import HospitalRegistration from "./views/Registration/Hospital.vue";
import DonorRegistration from "./views/Registration/Donor.vue";
import PatientRegistration from "./views/Registration/Patient.vue";

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
      path: "/registerPatient",
      name: "registerPatient",
      component: PatientRegistration
    },
    {
      path: "/registerHospital",
      name: "registerHospital",
      component: HospitalRegistration
    },
    {
      path: "/registerDonor",
      name: "registerDonor",
      component: DonorRegistration
    }
  ]
});

// Router.beforeEach((to, from, next) => {
//   if (to.matched.some(record => record.meta.requiresLogin) && ???) {
//       // You can use store variable here to access globalError or commit mutation 
//       next("/Login")
//   } else {
//       next()
//   }
// })