<template>
  <tr class="user-row">
    <td data-title="Nome">
      <div class="name-wrapper">
        <img class="list-avatar" src="@/assets/img/avatar.png">
        <p class="name-text">{{ user.name }} {{ user.lastName }}</p>
      </div>
    </td>
    <td data-title="Telefone">{{ user.phone | phoneNumber }}</td>
    <td data-title="Email">{{ user.email }}</td>
    <td data-title="Data Nasc.">{{ this.date }}</td>
    <td data-title="Status">
      <p :class="statusClass">{{ user.status | active }}</p>
    </td>
    <td>
      <div class="acoes-wrapper">
        <button type="button" data-name="edit" @click="editUser">
          <i class="fas fa-edit" data-name="edit" aria-hidden="true"></i>
        </button>
        <button type="button" data-name="remove" @click="removeUser" :id="this.user.id">
          <i class="fas fa-trash" data-name="remove" aria-hidden="true" :id="this.user.id"></i>
        </button>
      </div>
    </td>
  </tr>
</template>

<script>
export default {
  props: {
    user: Object,
  },
  data() {
    return {
      birthDate: new Date(this.user.birthDate),
    }
  },
  methods: {
    addZero(number) {
      return (number <= 9 ? "0" + number : number);
    },
    editUser() {
      this.$router.push({ name: 'edit', params: { id: this.user.id } });
    },
    removeUser(event) {
      this.$emit('confirmRemove', event.target);
    }
  },
  computed: {
    date() {
      return (this.addZero(this.birthDate.getDate().toString()) 
        + "/" + (this.addZero(this.birthDate.getMonth()+1).toString()) + "/" + this.birthDate.getFullYear());
    },
    statusClass() {
      return (this.user.status ? 'active' : 'inactive');
    }
  },
  filters: {
    active(value) {
      return (value ? 'Ativo' : 'Inativo');
    },
    phoneNumber(value) {
      return value.replace(/\D/g, '').replace(/^(\d{2})(\d)/g, '($1) $2').replace(/(\d)(\d{4})$/, '$1-$2');
    }
  },
}
</script>

<style>

</style>