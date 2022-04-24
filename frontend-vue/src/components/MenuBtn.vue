<template>
  <button
    type="button"
    :id="name"
    :data-page="name"
    class="menu-btn"
    :class="{'thin-width': hiddenWidth}"
  >
    <i :class="icon" :id="name" :data-page="name"></i>
    {{ title }}
  </button>
</template>

<script>
export default {
  props: {
    name: String,
    title: String,
    icon: String,
  },
  
  computed: {
    hiddenWidth() {
      return this.$store.state.hiddenWidth;
    }
  }
}
</script>

<style scoped>
  button {
    display: flex;
    align-items: center;
    margin: 0;
    width: 250px;
    background-color: #001033;
    color: white;
    font-size: 18px;
    height: 40px;
    opacity: 0.5;
    padding: 0;
  }

  .menu-btn i {
  margin: 0 30px 0 20px;
  }

  button:focus {
    background-color: #001033;
    opacity: 1;
  }
</style>