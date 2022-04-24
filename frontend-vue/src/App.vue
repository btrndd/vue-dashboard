<template>
  <div id="app">
    <router-view />
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
</style>
