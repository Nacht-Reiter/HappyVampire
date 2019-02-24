<template>
    
<div class="position-relative overflow-hidden p-3 p-md-5 m-md-3 text-center bg-light-custom">
    <div class="col-md-5 p-lg-5 mx-auto my-5">
      <h1 class="display-4 font-weight-normal">Happy Vampire</h1>
      <!-- <p class="lead font-weight-normal">And an even wittier subheading to boot. Jumpstart your marketing efforts with this example based on Apple’s marketing pages.</p> -->
      <p class="lead font-weight-normal ">Уже зарегестрированы ?</p>

      <div class="d-flex justify-content-center">
        <router-link :to="{name: 'login'}">
          <b-button variant="outline-danger btn-lg ">Вход</b-button>
        </router-link> 
      </div>
    </div>
</div>
</template>

<script>
export default {
    name: "info-headline"
}
</script>

<style>
.lead{
  font-size: 1.5em;
}
</style>
