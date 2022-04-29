<template>    
  <form class="form">
    <div class="inputWrapper">
      <text-input field="name" label="Nome" v-model="name" />
      <text-input field="lastName" label="Sobrenome" v-model="lastName" />
    </div>
    <div class="inputWrapper">
      <text-input field="phone" label="Telefone" placeholder="(99) 99999-9999" maxLength="15" v-model="phone" />
      <text-input field="birthDate" type="date" label="Data de Nascimento" v-model="birthDate" />
    </div>
    <text-input field="email" label="Email" v-model="email" />
    <div class="inputWrapper">
      <text-input field="password" type="password" label="Senha" v-model="password" />
      <text-input field="checkPassword" type="password" label="Repetir Senha" v-model="checkPassword"/>
    </div>
    <div class="checkbox">
      <input type="checkbox" name="status" id="status" />
      <label for="status">Ativo</label>
    </div>
    <button type="button" id="cadastrar" class="register-btn" data-page="register" @click="handleSubmit">Cadastrar</button>
    <button type="button" class="cancel-btn" @click="goBack" >Cancelar</button>
  </form>
</template>

<script>
import TextInput from '@/components/TextInput.vue'
export default {
  components: { TextInput },
  data() {
    return {
      name: {
        content: '',
        fulfilled: false,
      },
      lastName: {
        content: '',
        fulfilled: false,
      },
      phone: {
        content: '',
        fulfilled: false,
      },
      email: {
        content: '',
        fulfilled: false,
      },
      birthDate: {
        content: '',
        fulfilled: false,
      },
      password: {
        content: '',
        fulfilled: false,
      },
      checkPassword: {
        content: '',
        fulfilled: false,
      }
    }
  },
  methods: {
    goBack() {
      this.$store.commit('updateUsersArrow', true);
      this.$router.push({ name: 'users' });
    },
    handleSubmit() {
      // console.log('aqui');
      // this.$emit('checkRequired');
    }
  }
}
</script>

<style scoped>
form {
  padding: 50px 30px 0 30px;
  font-size: 16px;
}

.inputWrapper {
  display: flex;  
  justify-content: space-between;
}

.checkbox {
  padding: 10px;
}

.checkbox input {
  margin-right: 5px;
}

.register-btn {
  background-color: #00174a;
  color: white;
  width: 100px;
  height: 40px;
  border-radius: 6px;
  margin-top: 10px;
}

.cancel-btn {
  background-color: #4a0000;
  color: white;
  width: 100px;
  height: 40px;
  border-radius: 6px;
  margin-left: 5px;
}
</style>