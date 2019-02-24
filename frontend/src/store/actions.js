import axios from "axios";

export default {
  initState({ commit }) {
    commit("INIT_STATE");
  },
  async setPatientList({ commit, state }) {
    try {
      if (state.accountType === "donor") {
        const patientsReq = await axios.get(
          `http://${state.server.ip}:${state.server.port}/patient`
        );
        const patientListRaw = patientsReq.data;
        const patientList = filterPatientsByField(
          patientListRaw,
          "bloodType",
          state.donor.bloodType
        );
        commit("SET_PATIENT_LIST", patientList);
      } else {
        const hospitalReq = await axios.get(
          `http://${state.server.ip}:${state.server.port}/hospital/${
            state.hospital.id
          }`
        );
        const hospital = hospitalReq.data;
        const patientList = hospital.patients;
        commit("SET_PATIENT_LIST", patientList);
      }
    } catch (e) {
      console.log(e);
    }
  }
};

function filterPatientsByField(patientList, field, value) {
  return patientList.filter(el => el[field] == value);
}

// const patientList = [
//   {
//     id: 0,
//     name: 'Вася',
//     photo: "https://png.pngtree.com/element_origin_min_pic/17/05/03/8547024f6770877dc91581dea87ec5cf.jpg",
//     motivationLetter: '123',
//     diagnosis: '12343',
//     bloodType: 'I+'
//   },
//   {
//     id: 1,
//     name: 'Вася1',
//     photo: "",
//     motivationLetter: '123',
//     diagnosis: '12343',
//     bloodType: 'I+'
//   }
// ]
