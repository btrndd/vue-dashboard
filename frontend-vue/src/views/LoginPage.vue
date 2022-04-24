<template>
  <div class="wrapper">
    <main class="login-container">
      <img src="@/assets/img/logo-azul.png" alt="Logo da Lyncas" class="logo-login" />
      <form class="form-card">
        <h3 class="form-title">LOGIN</h3>
        <input-text :name="email" :type="text" :placeholder="Email" />
        <input-text :name="password" :type="password" :placeholder="Senha" />
        <submit-btn :id="'login-btn'" :buttonText="buttonText" />
      </form> 
    </main>
  </div>
</template>

<script>
import SubmitBtn from '@/components/login/SubmitBtn';
import InputText from '@/components/login/InputText';

export default {
  components: { SubmitBtn, InputText },
  data() {
    return {    
      email: 'email',
      Email: 'Email',
      password: 'password',
      Senha: 'Senha',
      text: 'text',
      buttonText: 'Log In',
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