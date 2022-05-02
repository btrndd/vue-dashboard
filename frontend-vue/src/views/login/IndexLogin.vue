<template>
  <div class="wrapper">
    <main class="login-container">
      <img src="@/assets/img/logo-azul.png" alt="Logo da Lyncas" class="logo-login" />
      <div class="form-card">
        <h3 class="form-title">LOGIN</h3>
        <input-text type="text" placeholder="Email" v-model="email" />
        <input-text type="password" placeholder="Senha" v-model="password" />
        <button class="login-btn" type="button" @click="handleSubmit">Log In</button>
      </div> 
    </main>
  </div>
</template>

<script>
import InputText from '@/views/login/components/InputText';
import UsersService from '@/services/users/users.service';

export default {
  components: { InputText },
  data() {
    return {
      email: {
        content: '',
        feedback: false,
        message: 'Por favor, preencha este campo.'
      },
      password: {
        content: '',
        feedback: false,
        message: 'Por favor, preencha este campo.'
      },
    }
  },
  computed: {
    form() {
      return [this.email, this.password];
    },
    formObject() {
      return {
        email: this.email.content,
        password: this.password.content,
      };
    }
  },
  methods: {
    verifyRequired() {
      const required = this.form.filter((e) => e.content === '' || e.content === null);
      if (required === 0) {
        return true;
      }
      required.forEach((e) => e.feedback = true);
    },
    goDash() {
      this.$store.commit('updateDashArrow', true);
      
      this.$router.push({ name: 'dash' });
    },
    async updateUsername(id) {
      const user = await UsersService.getById(id);
      this.$store.commit('updateUsername', user.name);
    },
    async handleSubmit() {
      this.verifyRequired();
      const allowSubmit = this.form.some((e) => e.feedback === true);
      if (!allowSubmit) {
        this.$store.commit('showSpinner', true);
        const result = await UsersService.login(this.formObject);
        if (result.data) {
          await this.updateUsername(result.data.id);
          this.goDash();
          console.log(result);
        } else {
          window.alert(result.message);
        }
        this.$store.commit('showSpinner', false);        
      }
    }
  }
}
</script>

<style scoped>
  .form-card {
      display: flex;
      flex-direction: column;
      justify-content: center;
      align-items: center;
      border: 2px solid lightgray;
      border-radius: 5px;
      width: 400px;
      padding-bottom: 15px;
  }

  .form-title {
    background-color: #00174a;
    color: white;
    width: 400px;
    height: 40px;
    text-align: center;
    margin: 0;
    padding-top: 20px;
  }

  .logo-login {
      width: 200px;
  }

  .login-container {
      display: flex;
      height: 500px;
      margin: auto;
      flex-direction: column;
      align-items: center;   
      position: absolute;
      top: 0; 
      bottom: 0;
      left: 0; 
      right: 0;
  }

  .warning {
      color: red;
      margin-top: 4px;
  }

  .login-btn {
    width: 350px;
    height: 40px;
    border-radius: 50px;
    margin-top: 15px;
    color: white;
    background-color: #00174a;
    font-weight: 600;
  }

  @media only screen and (max-width: 460px) {
      .form-card {
          width: 300px;
      }
      
      button {
          width: 250px;
      }

      .form-title {
          width: 300px;
      }

      input.form-input {
          width: 250px;
      }
  }
</style>