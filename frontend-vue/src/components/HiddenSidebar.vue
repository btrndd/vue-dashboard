<template>
  <aside class="side-menu">
    <img src="@/assets/img/logo-branca.png" alt="Logo da Lyncas" class="logo" />
    <ul>
      <li @click="goToDash" class="menu-wrapper" id="dashboard" data-page="dashboard">
        <menu-btn :icon="dashIcon" :name="dashName" :title="dashTitle" />
      </li>
      <li @click="goToUsers" class="menu-wrapper" :id="usersName" :data-page="usersName">
        <menu-btn :icon="usersIcon" :name="usersName" :title="usersTitle" />
      </li>
    </ul>
  </aside>
</template>

<script>
import MenuBtn from '@/components/MenuBtn';

export default {
  components: { MenuBtn },
  data() {
    return {
      usersName: 'users',
      usersTitle: 'Usuários',
      usersIcon: 'fas fa-users',
      dashName: 'dashboard',
      dashTitle: 'Dashboard',
      dashIcon: 'fas fa-th-large'
    }
  },
  methods: {
    goToDash() {
      this.$router.push({ name: 'dash' });
    },

    goToUsers() {
      this.$router.push({ name: 'users' });
    }
  }
}
</script>

<style scoped>
  .side-menu {
    width: 80px;
    height: 100vh;
    background-color: #00174a;
    display: flex;
    align-items: center;
    flex-direction: column;
    position: fixed;
    left: 0;
    top: 0;
    border-bottom: 130px solid #00174a;
  }

  .menu-btn {
    width: 60px;
  }

  .logo {
    width: 180px;
  }

  ul {
    list-style: none;
  }
</style>