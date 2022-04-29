<template>
  <button :id="id" type="button">{{ buttonText }}</button>
</template>

<script>
export default {
  props: {
    id: String,
    buttonText: String,
  }
}
</script>

<style scoped>
  button {
    width: 350px;
    height: 40px;
    border-radius: 50px;
    margin-top: 15px;
    color: white;
    background-color: #00174a;
    font-weight: 600;
  }
</style>