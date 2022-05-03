<template>
  <div class="background" @click="cancelModal">
    <div class="modal">
      <p>{{ message }}</p>
      <div>
        <span :class="color"></span>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    userId: String,
  },
  computed: {
    message() {
      return this.$store.state.message;
    },
    color() {
      return this.$store.state.color;
    }
  },
  methods: {
    cancelModal() {
      this.$store.commit('showAlert', false);
    },
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
  flex-wrap: row-wrap;
  padding: 20px;
  box-shadow: 1px 2px 1px 1px gray;
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

.modal span {
  display: inline-block;
  position: absolute;
  bottom: 0.2px;
  left: 0;
  width: 100%;
  height: .3em;
  animation: linear loading 3s;
}

.green {
  background: #00b673;
}

.red {
  background: #d43e3e;
}

@keyframes loading {
  0% {
    opacity: 0;
    width: 25%;
  }
  50% {
    opacity: 0.5;
    width: 60%;
  }
  100% {
    opacity: 1;
    width: 100%;
  }
}
</style>