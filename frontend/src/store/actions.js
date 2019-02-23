export default {
  initState({commit}) {
    commit('INIT_STATE');
  },
  setPatientList({commit, state}){
    console.log(state.accountType)
    
    // TODO: patientList should be fetched from server 
    const patientList = [
      { 
        id: 0, 
        name: 'Вася', 
        photo: "https://png.pngtree.com/element_origin_min_pic/17/05/03/8547024f6770877dc91581dea87ec5cf.jpg", 
        motivationLetter: '123', 
        diagnosis: '12343', 
        bloodType: 'I+'
      },
      { 
        id: 1, 
        name: 'Вася1', 
        photo: "", 
        motivationLetter: '123', 
        diagnosis: '12343', 
        bloodType: 'I+'
      }
    ]

    // if (state.accountType === 'donor'){
      // filter patientList by bloodType
    // } 
    

    commit('SET_PATIENT_LIST', patientList);
  }
};