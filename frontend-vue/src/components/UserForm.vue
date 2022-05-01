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
import UsersService from '@/services/users/users.service';
import TextInput from '@/components/TextInput.vue'

export default {
  components: { TextInput },
  data() {
    return {
      name: {
        content: '',
        feedback: false,
        message: 'Por favor, preencha este campo.'
      },
      lastName: {
        content: '',
        feedback: false,
        message: 'Por favor, preencha este campo.'
      },
      phone: {
        content: '',
        feedback: false,
        message: 'Por favor, preencha este campo.'
      },
      email: {
        content: '',
        feedback: false,
        message: 'Por favor, preencha este campo.'
      },
      birthDate: {
        content: '',
        feedback: false,
        message: 'Por favor, preencha este campo.'
      },
      password: {
        content: '',
        feedback: false,
        message: 'Por favor, preencha este campo.'
      },
      checkPassword: {
        content: '',
        feedback: false,
        message: 'Por favor, preencha este campo.'
      }
    }
  },
  computed: {
    form() {
      return [this.name, this.lastName, this.phone, this.email, this.birthDate, this.password, this.checkPassword];
    },
    formObject() {
      return { 
        name: this.name.content, 
        lastName: this.lastName.content,
        email: this.email.content,
        phone: this.phone.content,
        birthDate: this.birthDate.content,
        password: this.password.content,
        status: true
      };
    }
  },
  methods: {
    goBack() {
      this.$store.commit('updateUsersArrow', true);
      this.$router.push({ name: 'users' });
    },
    verifyRequired() {
      const required = this.form.filter((e) => e.content === '' || e.content === null);
      if (required === 0) {
        return true;
      }
      required.forEach((e) => e.feedback = true);
    },
    verifyEmail() {
      const regexEmail = /^[\w-.]+@([\w-]+\.)+[\w-]{2,4}$/;
      if (regexEmail.test(this.email.content)) {
        return true;
      }
      if (this.phone.feedback === false) {
        this.email.feedback = true;
        this.email.message = 'Por favor, insira um email válido.';
      }
    },
    verifyPassword() {
      const regex = /\d/g;
      const haveNumber = regex.test(this.password.content);
      if (this.password.content.length >= 6 && haveNumber) {
        return true;
      }
      if (this.phone.feedback === false) {  
        this.password.feedback = true;
        this.password.message = 'Sua senha precisa ter no mínimo 6 digitos e um número.';
      }
    },
    verifyPhone() {
      const onlyNumbers = this.phone.content.replace(/\D/g, '');
      if (onlyNumbers.length >= 10) {
        return true;
      }
      if (this.phone.feedback === false) {
        this.phone.feedback = true;
        this.phone.message = 'Por favor, insira um número válido.';
      }      
    },
    doubleCheckPassword() {
      if (this.password.content === this.checkPassword.content) {
        return true;
      }
      if (this.phone.feedback === false) {
        this.checkPassword.feedback = true;
        this.checkPassword.message = 'Por favor, verifique a senha inserida.';
      }      
    },
    async handleSubmit() {
      this.verifyRequired();
      this.verifyEmail();
      this.verifyPhone();
      this.verifyPassword();
      this.doubleCheckPassword();
      const allowSubmit = this.form.some((e) => e.feedback === true);
      if (!allowSubmit) {
        // call spinner
        await UsersService.save(this.formObject);
        this.goBack();
      }
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