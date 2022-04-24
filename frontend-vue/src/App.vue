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

  .main {
    position: relative;
    margin-left: 250px;
    background-color: white;
    border-left: 30px solid #f5f4f4;
    border-right: 30px solid #f5f4f4;
    border-top: 30px solid #f5f4f4;
    padding: 20px;
  }

  .thin-width {
    width: 60px !important;
  }

  .thin-left {
    margin-left: 60px !important;
  }
</style>
