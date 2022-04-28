<template>
  <th class="header-items">
    <div class="th-wrapper">
      <p>{{ item }}</p>
      <div>
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
  }
}
</script>

<style scoped>
.th-wrapper {
  display: flex;
  align-items: center;
  justify-content: space-between;
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