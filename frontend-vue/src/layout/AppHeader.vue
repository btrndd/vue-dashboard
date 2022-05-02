<template>
  <header class="header"  :class="{'thin-left': hiddenLeft}">
    <button type="button" class="show-sidebar" @click="hideSidebar">
      <i class="fas fa-align-right fa-lg"></i>
    </button>
    <div class="avatar-wrapper">
      <img src="@/assets/img/avatar.png" alt="Imagem de perfil" class="avatar" />
      <div class="logoff-wrapper">
        <p class="user">{{ username }}</p>
        <button @click="handleLogout" class="logout" type="button">Sair</button>
      </div>
    </div>
  </header>
</template>

<script>
export default {
  computed: {
    applyHide() {
      return this.$store.state.hiddenWidth;
    },
    hiddenLeft() {
      return this.$store.state.hiddenLeft;
    },
    username() {
      return this.$store.state.username;
    }
  },
  methods: {
    goToLogin() {
      this.$router.push({ name: 'login' });
    },

    handleLogout() {
      localStorage.clear();
      this.goToLogin();
    },

    hideSidebar() {
      const payload = this.applyHide === true ? false : true;
      this.$store.commit('hidden', payload);
    }
  }

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