<template>
  <div class="background" @click="cancelModal">
    <div class="modal">
      <p>Você realmente deseja excluir este usuário?</p>
      <div class="modal-wrapper">
        <button class="confirm-btn" :id="this.userId" @click="removeUser">Confirmar</button>
        <button class="cancel-btn" @click="cancelModal">Cancelar</button>
      </div>
    </div>
  </div>
</template>

<script>
import UsersService from '@/services/users/users.service';

export default {
  props: {
    userId: String,
  },
  methods: {
    cancelModal(event) {
      this.$emit('confirmRemove', event.target);
    },
    async removeUser(event) {
      this.$store.commit('showSpinner', true);
      const result = await UsersService.remove(this.userId);
      this.$store.commit('showSpinner', false);
      this.$emit('confirmRemove', event.target);
      if (result.data) {
        this.$store.commit('updateMessage', result.message);
        this.$store.commit('updateColor', 'green');
        this.$store.dispatch('showAlert');
      } else {
        this.$store.commit('updateMessage', result.message);
        this.$store.commit('updateColor', 'red');
        this.$store.dispatch('showAlert');
      }
    }
  }
}
</script>

<style scoped>
.modal {
  position: fixed;
  z-index: 999;
  height: max-content;
  width: max-content;
  overflow: show;
  margin: auto;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  color: gray;
  display: flex;
  flex-direction: column;
  padding: 30px;
  box-shadow: 1px 2px 1px 1px gray;
  border-radius: 5px;
  visibility: visible;
  background-color: white;
}

.background {
  display: block;
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background-color: rgba(0,0,0,0.1);
}

.modal-wrapper {
  display: flex;
  margin-top: 10px;
  justify-content: space-evenly;
}

.confirm-btn {
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
  margin-top: 10px;
}

@media only screen and (max-width: 720px) {
  .modal {
    width: 200px;
  }

  .modal p {
    text-align: center;
  }

  .confirm-btn {
    margin-right: 5px;
  }
}
</style>