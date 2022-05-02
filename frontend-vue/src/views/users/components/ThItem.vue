<template>
  <th class="header-items">
    <div class="th-wrapper">
      <p>{{ item }}</p>
      <div v-if="this.sort">
        <button type="button">
          <i class="fas fa-arrow-up" aria-hidden="true"></i>
        </button>
        <button type="button">
          <i class="fas fa-arrow-down" aria-hidden="true"></i>
        </button>
      </div>
    </div>
  </th>
</template>

<script>
export default {
  props: {
    item: String,
  },
  computed: {
    sort() {
      return (this.item !== 'Ações' ? true : false);
    }
  }
}
</script>

<style scoped>
.th-wrapper {
  display: flex;
  align-items: center;
  justify-content: space-evenly;
  padding-left: 20px;
  padding-right: 10px;
}

.th-wrapper button {
  opacity: 0.5;
}

.th-wrapper button:focus {
  opacity: 1;
}

.th-wrapper div {
  width: 31px;
}
</style>