<template>
  <aside class="side-menu" :class="{'thin-width': hiddenWidth}">
    <img :src="imgPath" alt="Logo da Lyncas" class="logo" :class="{'logo-thin': hiddenWidth}" />
    <ul>
      <li
        @click="handleDashClick"
        class="menu-wrapper"
        :id="dashName"
        :data-page="dashName"
      >
        <menu-btn :arrow="dashArrow" :icon="dashIcon" :name="dashName" :title="dashTitle" />
      </li>
      <li
        @click="handleUsersClick"
        class="menu-wrapper"
        :id="usersName"
        :data-page="usersName"
      >
        <menu-btn :arrow="usersArrow" :icon="usersIcon" :name="usersName" :title="usersTitle" />
      </li>
    </ul>
  </aside>
</template>

<script>
import MenuBtn from '@/components/main/MenuBtn';

export default {
  components: { MenuBtn },
  data() {
    return {
      usersName: 'users',
      usersTitle: 'Usuários',
      usersIcon: 'fas fa-users',
      dashName: 'dashboard',
      dashTitle: 'Dashboard',
      dashIcon: 'fas fa-th-large',
      usersArrow: false,
      dashArrow: false,
    }
  },
  computed: {
    hiddenWidth() {
      return this.$store.state.hiddenWidth;
    },
    imgPath() {
      return this.hiddenWidth ? 
      require('@/assets/img/icon-branco.png') 
      : require('@/assets/img/logo-branca.png');
    }
  },
  methods: {
    handleDashClick() {
      this.dashArrow = true;
      this.usersArrow = false;
      this.$router.push({ name: 'dash' });
    },

    handleUsersClick() {
      this.dashArrow = false;
      this.usersArrow = true;
      this.$router.push({ name: 'users' });
    }
  }
}
</script>

<style scoped>
  .side-menu {
    width: 250px;
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

  .logo {
    width: 180px;
  }

  .logo-thin {
    width: 40px;
    margin: 40px 0 40px 0;
  }

  ul {
    list-style: none;
  }
</style>