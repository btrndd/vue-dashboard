<template>
  <div id="app">
    <LoginPage />
  </div>
</template>

<script>
import LoginPage from '@/views/LoginPage';

export default {
  name: 'App',
  components: {
    LoginPage
  }
}
</script>

<style>
#app {
  font-family: 'Merriweather Sans', sans-serif;
}
</style>
