import { removeCookies } from "../axios.js";
export default {
  INIT_STATE(state) {
    state.test = "123";
  },
  SET_PATIENT_LIST(state, patientList) {
    state.patientList = patientList;
  },
  SET_AUTHENTICATED(state, status) {
    state.authenticated = status;
  },
  SET_ACCOUNT_TYPE(state, status) {
    state.accountType = status;
  },
  LOG_OUT(state) {
    state.accountType = null;
    state.authenticated = false;
    removeCookies();
  },
  SET_BLOOD_TYPE(state, bloodType) {
    state.donor.bloodType = bloodType;
  }
};
