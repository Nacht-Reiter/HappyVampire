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
  }
};
