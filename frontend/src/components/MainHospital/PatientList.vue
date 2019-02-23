<template>
    <div>
          <img src="../../assets/navbar.png" alt="" width="100%">

          <div class="container">
    <h1 class="text-center">Список пациентов</h1>
  </div>

  <div class="position-relative overflow-hidden p-3 p-md-5 m-md-3 text-center">
    <main role="main" class="container">
      <div class="card mb-3">
        <div class="row no-gutters">
          <div class="col-md-4">
            <img src="../../assets/default-user-image.png" class="card-img" alt="Patient picture">
          </div>
          <div class="col-md-8">
            <div class="card-body">
              <h3 class="card-title text-left">Имя пациента</h3>
              <p class="card-text text-left">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.</p>
              <div class="help-btn float-right align-bottom">
                <a href="#" class="btn btn-primary">Помочь11</a>
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
export default {
    name: "patientList"
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
