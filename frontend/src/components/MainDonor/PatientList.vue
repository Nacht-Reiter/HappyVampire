<template>
    <div>
          <img src="../../assets/navbar.png" alt="" width="100%">

          <div class="container">
    <h1 class="text-center">Список пациентов</h1>
  </div>

  <div class="position-relative overflow-hidden p-3 p-md-5 m-md-3 text-center">
    <main role="main" class="container">


            <div class="card mb-3" v-for="patient in patientList" :key="patient.id">
        <!-- {{ patient }} -->
        <div class="row no-gutters">
          <div class="col-md-4">
            <img v-if="patient.photo"  :src="patient.photo" class="card-img" alt="Patient picture">
            <img v-else src="../../assets/default-user-image.png" class="card-img" alt="Patient picture">
          </div>
          <div class="col-md-8">
            <div class="card-body">
              <h3 class="card-title text-left">{{patient.name}}</h3>
              <p class="card-text text-left"><span class="bold">Диагноз: </span>{{patient.diagnosis}}</p>
              <p class="card-text text-left"><span class="bold">Группа крови: </span>{{patient.bloodType}}</p>
              <div class="help-btn float-right align-bottom">
                <!-- <router-link :to="{name: 'helpPatient'}"> -->
                <a href="#" class="btn btn-primary">Помочь</a>
                <!-- </router-link> -->
              </div>
            </div>
          </div>
        </div>
      </div>


    </main>
  </div>
    </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'


export default {
    name: "patientList",
    computed: {
      ...mapGetters(['patientList'])
    },
    created(){
      this.setPatientList()
    },
    methods: {
      ...mapActions(['setPatientList'])
    }

}
</script>

<style>



.help-btn {
  position: absolute;
  bottom: 0;
  padding: 10px;
  right: 10px;
}

</style>
