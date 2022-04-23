<template>
  <header class="header">
    <button type="button" class="show-sidebar"><i class="fas fa-align-right fa-lg"></i></button>
    <div class="avatar-wrapper">
      <img src="@/assets/img/avatar.png" alt="Imagem de perfil" class="avatar" />
      <div class="logoff-wrapper">
        <p class="user">Nome de Usuário</p>
        <button class="logout" type="button">Sair</button>
      </div>
    </div>
  </header>
</template>

<script>
export default {

}
</script>

<style>
  .header {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-left: 250px;
    height: 60px;
    background-color: white;
  }
  
  .avatar {
    height: 50px;
    border-radius: 50%;
  }

  .avatar-wrapper {
    display: flex;
    margin-right: 40px;
  }

  .logoff-wrapper {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    padding: 5px 20px 0 10px;
  }

  .logoff-wrapper button {
    color: gray;
  }

  .show-sidebar {
    margin-left: 20px;
    color: royalblue;
  }
</style>