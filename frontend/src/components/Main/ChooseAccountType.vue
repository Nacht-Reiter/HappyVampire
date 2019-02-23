<template>

  <div class="d-md-flex flex-md-equal w-100 my-md-3 pl-md-3">
    <div class="mr-md-3 pt-3 px-3 pt-md-5 px-md-5 text-center overflow-hidden"
         style="background-color: #A4DAD8">
      <div class="my-3 py-3">
        <h2 class="display-5">Донор</h2>
        <p class="lead">Если ты желаешь помочь.</p>
      </div>
      <router-link :to="{name: 'registerDonor'}">

      <a href="#">
        <div class="bg-light shadow-sm mx-auto" style="width: 80%; height: 440px; border-radius: 21px 21px 0 0;">
          <img src="../../assets/donor.jpg" width="300" alt="donor_picture">
        </div>
      </a>
      </router-link>

    </div>
    <div class="bg-light mr-md-3 pt-3 px-3 pt-md-5 px-md-5 text-center overflow-hidden">
      <div class="my-3 p-3">
        <h2 class="display-5">Клиника</h2>
        <p class="lead">Если вам требуется донорская помощь.</p>
      </div>

      <router-link :to="{name: 'registerHospital'}">
      <a href="#">
        <div class="shadow-sm mx-auto" style="width: 80%; height: 440px; border-radius: 21px 21px 0 0; background-color: #A4DAD8">
          <img src="../../assets/hospital.png" width="300" alt="hospital_picture" style="padding: 170px 0 0 0;">
        </div>
      </a>
      </router-link>
    </div>
  </div>


</template>

<script>
export default {
    name: "chooseAccountType"
}
</script>
