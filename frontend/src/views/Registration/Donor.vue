<template>
  <div class="container donorRegistration">
    <div class="wrapper">
      <div>
        <h2>Страница регистрации донора</h2>
      </div>
        <form>
          <div class="form-group">
            <label for="exampleInputName">Введите имя</label>
            <input type="text" class="form-control" id="name" aria-describedby="name" placeholder="Введите имя">
          </div>
          <div class="form-group">
            <label for="exampleInputBloodtype">Введите тип крови</label>
            <input type="text" class="form-control" id="bloodtype" aria-describedby="bloodtype" placeholder="Введите тип крови">
          </div>
          <div class="form-group">
            <label for="exampleInputTelephone">Введите номер телефона</label>
            <input type="text" class="form-control" id="telephone" aria-describedby="telephone" placeholder="Введите номер телефона">
          </div>
          <button type="submit" class="btn btn-primary">Submit</button>
        </form>
      </div>
  </div></template>

<script>
export default {
  name: "Registration"
};
</script>

<style >
</style>