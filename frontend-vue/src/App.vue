<template>
  <div id="app">
    <router-view />
    <router-view name="header" />
    <router-view name="sidebar" />
    <router-view name="spinner" />
    <router-view name="page" />
    <loading-spinner v-if="showSpinner" />
  </div>
</template>

<script>
import LoadingSpinner from './components/LoadingSpinner.vue'
export default {
  components: { LoadingSpinner },
  name: 'App',
  computed: {
    showSpinner() {
      return this.$store.state.spinner;
    },
  }  
}
</script>

<style>
  #app {
    font-family: 'Merriweather Sans', sans-serif;
  }

  * {
    margin: 0;
    padding: 0;
    font-family: 'Merriweather Sans', sans-serif;
  }

  button, button:focus {
    background: none;
    border: 1px solid transparent;
  }

  button:active {
    border: 1px solid grey;
  }

  .main {
    position: relative;
    margin-left: 250px;
    background-color: white;
    border-left: 30px solid #f5f4f4;
    border-right: 30px solid #f5f4f4;
    border-top: 30px solid #f5f4f4;
    padding: 20px;
    height: 100vh;
  }

  .thin-width {
    width: 60px !important;
  }

  .thin-left {
    margin-left: 60px !important;
  }
</style>
