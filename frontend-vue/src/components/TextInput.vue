<template>
  <div class="input" :class="type">
    <label :for="field">{{ label }}</label>
    <input
      :name="field"
      :id="field"
      :type="type"
      :placeholder="placeholder"
      :maxlength="maxLength"
      :value="this.value.content" 
      @keyup="executeMask"
      @input="handleInput"
    />
    <small class="warning" v-if="value.feedback">{{ value.message }}</small>
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
    formatPhone() {
      const onlyNumbers = this.value.content.replace(/\D/g, '');
      const numberWithParenteses = onlyNumbers.replace(/^(\d{2})(\d)/g, '($1) $2');
      const numberWithHifen = numberWithParenteses.replace(/(\d)(\d{4})$/, '$1-$2');
      return numberWithHifen;
    },
    executeMask() {
      if (this.field === 'phone') {
        this.$emit('input', {
          content: this.formatPhone(),
          feedback: false,
          message: 'Por favor, preencha este campo.'
        });
      }
    },
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



@media only screen and (max-width: 545px) {
  .input input {
    padding-left: 8%;
  }

  #email {
    padding-left: 8%;
  }
}

@media only screen and (max-width: 360px) {  
  .input input::placeholder {
    font-size: 10px;
  }
}
</style>