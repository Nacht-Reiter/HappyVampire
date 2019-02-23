<template>
  <div class="container hospitalRegistration">
    <div class="wrapper">
      <div>
        <h2>Страница регистрации поликлиники</h2>
      </div>
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