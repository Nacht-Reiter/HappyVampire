<template>
    <div>

        <!-- <div class="recepientList">
            <button class="recepientListBtn">Найти рецепиента</button>
        </div> -->
        <patient-list></patient-list>
    </div>
</template>

<script>
import PatientList from './PatientList'

export default {
    name: 'mainDonor',
    components: {
        "patient-list": PatientList
    }
}
</script>

<style>

</style>
