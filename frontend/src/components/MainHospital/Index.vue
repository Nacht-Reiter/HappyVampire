<template>
    <div>
        <!-- <div class="patientList">
            <button class="patientListBtn">Список больных</button>
        </div> -->
        <patient-list></patient-list>
    </div>
</template>

<script>
import PatientList from './PatientList'

export default {
    name: 'mainHospital',
    components: {
        "patient-list": PatientList
    }
}
</script>

<style>
.addPatientBtnWrapper {
  display: flex;
  justify-content: center;
  margin-bottom: 30px;
}

.addPatientBtn{
  
}



</style>
