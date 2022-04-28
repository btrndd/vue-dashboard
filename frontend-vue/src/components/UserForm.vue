<template>    
  <form class="form">
    <div class="inputWrapper">
      <text-input field="name" label="Nome" />
      <text-input field="lastName" label="Sobrenome" />
    </div>
    <div class="inputWrapper">
      <text-input field="phone" label="Telefone" placeholder="(99) 99999-9999" maxLength="15" />
      <text-input field="birthDate" type="date" label="Data de Nascimento" min="1900-01-01" max="2030-12-31" />
    </div>
    <text-input field="email" label="Email" />
    <div class="inputWrapper">
      <text-input field="password" type="password" label="Senha" />
      <text-input field="checkPassword" type="password" label="Repetir Senha" />
    </div>
    <div class="checkbox">
      <input type="checkbox" name="status" id="status" />
      <label for="status">Ativo</label>
    </div>
    <button type="button" id="cadastrar" class="register-btn" data-page="register">Cadastrar</button>
    <button type="button" id="cadastrar" class="cancel-btn" data-page="register">Cancelar</button>
  </form>
</template>

<script>
import TextInput from '@/components/TextInput.vue'
export default {
  components: { TextInput },

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