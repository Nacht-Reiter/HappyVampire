export default {
  authenticated(state) {
      return state.authenticated;
  },
  accountType(state) {
    return state.accountType;
  },
  patientList(state){
    return state.patientList;
  },
  server(state){
    return state.server;
  }
};