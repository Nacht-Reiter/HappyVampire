import Vue from "vue";
import Vuex from "vuex";

import getters from "./getters";
import actions from "./actions";
import mutations from "./mutations";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    // authenticated: false,
    authenticated: true,
    accountType: "donor",
    // accountType: "hospital",
    hospital: {
      id: 1
    },
    donor: {
      id: 1
    },
    patient: {
      id: null,
      bloodType: "I+"
    },
    patientList: [],
    server: {
      ip: "192.168.32.77",
      port: "3000"
    }
  },
  getters,
  mutations,
  actions
});
