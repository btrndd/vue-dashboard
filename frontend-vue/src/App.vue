<template>
  <div id="app">
    <router-view />
    <router-view name="header" />
    <router-view name="sidebar" />
    <router-view name="page" />
  </div>
</template>

<script>
export default {
  name: 'App',
}
</script>

<style>
  #app {
    font-family: 'Merriweather Sans', sans-serif;
  }

  * {
    margin: 0;
    padding: 0;
  }

  button, button:focus {
    background: none;
    border: 1px solid transparent;
  }

  button:active {
    border: 1px solid grey;
  }

  .thin-width {
    width: 60px !important;
  }

  .thin-left {
    margin-left: 60px !important;
  }
</style>
