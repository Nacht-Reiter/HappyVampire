<template>
  <div>
    <div>
      <img src="../../assets/navbar.png" alt="" width="100%">
    </div>
    <!--<div class="container hospitalRegistration">-->
    <div>
    </div>
    <div class="container h-100">
      <h2 class="text-center">Регистрации поликлиники</h2>
      <br>
        <div class="row h-100 justify-content-center align-items-center">
          <form>
            <div class="form-group">
              <label for="exampleInputEmail1">Введите название</label>
              <input type="text" class="form-control" id="name" aria-describedby="name" placeholder="Введите название">
            </div>
            <div class="form-group">
              <label for="exampleInputCoordinates">Введите координаты</label>
              <input type="text" class="form-control" id="coordinates" aria-describedby="coordinates" placeholder="Введите координаты">
            </div>
            <button type="submit" class="btn btn-primary">Submit</button>
          </form>
        </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Registration"
};
</script>

<style scoped>


.title{
  font-weight: bold
}

</style>