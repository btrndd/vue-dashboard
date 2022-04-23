<template>
  <div id="app">
    <router-view />
    <router-view name="sidebar" />
    <router-view name="header" />
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
    outline: none;
    background: transparent;
    border: 1px solid transparent;
  }

  button:active {
    outline: none;
    background: transparent;
    border: 1px solid grey;
}
</style>
