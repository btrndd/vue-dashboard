<template>
  <div class="search-wrapper">
    <label>
      <i class="fas fa-search" aria-hidden="true"></i>
    </label>
    <input class="search-bar" placeholder="Buscar usuários">
    <button @click="goToRegister" class="add-button" type="button" id="register" data-page="register">Adicionar</button>
  </div>
</template>

<script>
export default {
  methods: {
    goToRegister() {
      this.$router.push({ name: 'register' });
    }
  }
}
</script>

<style>
.search-wrapper {
  width: 60%;
  display: flex;
  justify-content: flex-end;
}

.search-bar { 
  height: 40px;
  width: 65%;
  border-radius: 5px;
  border: 1px solid grey;
  padding-left: 40px;
}

.add-button {
  text-align: center;
  color: white;
  font-weight: 800;
  height: 40px;
  border-radius: 20px;
  margin-left: 10px;
  width: 20%;
  background-color: #00174a;
}
</style>