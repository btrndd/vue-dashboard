<template>
  <div class="main" :class="{'thin-left': hiddenLeft}" >
    <div class="container">
      <h2 class="title">Usuários / Cadastrar</h2>      
    </div>  
    <user-form />
  </div>
</template>

<script>
import UserForm from '@/components/UserForm.vue'
export default {
  components: { UserForm },
  computed: {
    hiddenLeft() {
      return this.$store.state.hiddenLeft;
    },
  },
}
</script>

<style scoped>
.container {
  display: flex;
  justify-content: space-between;
  align-items: center;
  height: 3%;
  margin-bottom: 20px;
}

.container h2 {
  margin: 30px 0 0 15px;
}

@media only screen and (max-width: 920px) {
  .container h2 {
    margin: 20px 0 0 0;
  }
}

@media only screen and (max-width: 545px) {
  .container h2 {
    font-size: 19px;
    width: 100%;
  }
}
</style>