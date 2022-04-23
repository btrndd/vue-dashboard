<template>
  <input :name="name" class="form-input" :type="type" :placeholder="placeholder" />
</template>

<script>
export default {
  props: {
    placeholder: String,
    type: String,
    name: String,
  }
}
</script>

<style scoped>
  .form-input {
    width: 350px;
    height: 30px;
    border-radius: 3px;
    border: 1px solid lightgray;
    margin-top: 15px;
    padding: 5px 10px 5px 10px;
  }
</style>