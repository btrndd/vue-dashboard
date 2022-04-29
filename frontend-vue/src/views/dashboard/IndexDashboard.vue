<template>
  <main class="main" :class="{'thin-left': hiddenLeft}">
    <h1 class="title">Bem vindo a Lyncas</h1>    
  </main>
</template>

<script>
export default {
  computed: {
    hiddenLeft() {
      return this.$store.state.hiddenLeft;
    },
  },
}
</script>

<style scoped>
  .title {
    text-align: center;
    margin-top: 80px;
    height: 100vh;
  }
</style>