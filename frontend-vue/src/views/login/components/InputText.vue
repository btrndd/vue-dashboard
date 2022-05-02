<template>
  <div>
    <input
      class="form-input"
      :type="type"
      :placeholder="placeholder"
      :value="this.value.content"
      @input="handleInput"
    />
    <small class="warning" v-if="value.feedback">{{ value.message }}</small>
  </div>
</template>

<script>
export default {
  props: {
    placeholder: String,
    type: String,
    name: String,
    value: {
      type: Object,
    }
  },
  methods: {
    handleInput(event) {
      if (event.target.value === '') {
        this.$emit('input', {
          content: event.target.value,
          feedback: true,
          message: 'Por favor, preencha este campo.'
        });
      } else {
        this.$emit('input', {
          content: event.target.value,
          feedback: false,
          message: 'Por favor, preencha este campo.'
        });
      }
    },
  }
}
</script>

<style scoped>
div {
  display: flex;
  flex-direction: column;
}

.form-input {
  width: 350px;
  height: 30px;
  border-radius: 3px;
  border: 1px solid lightgray;
  margin-top: 15px;
  margin-bottom: 5px;
  padding: 5px 10px 5px 10px;
}

.warning {
  color: red;
}
</style>