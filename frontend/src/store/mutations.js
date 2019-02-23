export default {
  INIT_STATE(state) {
    state.test = '123'  
  },
  SET_PATIENT_LIST(state, patientList){
    state.patientList = patientList
  }
};