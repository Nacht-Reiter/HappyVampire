<template>
  <div>
    <div v-for="patient in patients">
      <patient :patient="patient" :v-key="patient.key"></patient>
    </div>
  </div>
</template>

<script>
import patient from "../components/patient.vue";
const patients = [
  {
    name: "roma",
    letter: "Lettterere erfsfsfefs sfsefse fsefsefsefseffffesfsefsef",
    bloodType: "2",
    id: "23"
  },
  {
    name: "roma",
    letter: "Lettterere erfsfsfefs sfsefse fsefsefsefseffffesfsefsef",
    bloodType: "2",
    id: "33"
  }
];
export default {
  name: "Patiens",
  components: {
    patient
  },
  computed: {
    patients: () => patients
  }
};
</script>

<style >
</style>
