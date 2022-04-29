<template>
  <div class="input" :class="type">
    <label :for="field">{{ label }}</label>
    <input :name="field" :id="field" :type="type" :placeholder="placeholder" :maxlength="maxLength" :value="value.content" @input="handleInput" required />
    <small class="warning" v-if="value.fulfilled">Por favor, preencha este campo.</small>
  </div>
</template>

<script>
export default {
  props: {
    label: String,
    field: String,
    maxLength: String,
    placeholder: String,
    type: String,
    value: {
      type: Object,
    }
  },
  methods: {
    handleInput(event) {
      if (event.target.value === '') {
        this.$emit('input', {
          content: event.target.value,
          fulfilled: true,
        });
      } else {
        this.$emit('input', {
          content: event.target.value,
          fulfilled: false,
        });
      }
    },
  },
}
</script>

<style scoped>
.input {
  width: 100%;
  margin: 0 5px 20px 5px;
}

.input input {
  width: 96%;
  border: solid 1px lightgray;
  border-radius: 5px;
  height: 40px;
  padding-left: 4%;
  margin-top: 8px;
  font-family: 'Merriweather Sans', sans-serif;
}

.password {
  margin-bottom: 10px;
}

#phone::placeholder {
  font-size: 12px;
}

#email {
  width: 97%;
  padding-left: 2%;
}

.warning {
  color: red;
}
</style>