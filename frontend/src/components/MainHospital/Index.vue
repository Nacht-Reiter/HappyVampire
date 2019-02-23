<template>
    <div>
        <div class="addPatient">
            <router-link tag="a" :to="{name: 'registerPatient'}">
                    <button class="addPatientBtn">Добавить больного</button>
            </router-link>
        </div>
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

</style>
