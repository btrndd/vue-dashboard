<template>
  <main class="main" :class="{'thin-left': hiddenLeft}">
    <div class="container">
      <h2>Usuários</h2>
      <search-wrapper />
    </div>
    <table>
      <thead class="table-header">
        <th-item v-for="(title, i) in titles" :key="i" :item="title" />
      </thead>
      <tr class="separator"></tr>
      <tbody class="tbody">
        <row-item v-for="(user, i) in users" :key="i" :user="user" />
      </tbody>
    </table>
  </main>
</template>

<script>
import ThItem from '@/views/users/components/ThItem';
import SearchWrapper from '@/views/users/components/SearchWrapper';
import RowItem from '@/views/users/components/RowItem';
import UsersService from '@/services/users/users.service';

export default {
  components: { ThItem, SearchWrapper, RowItem},
  data() {
    return {
      titles: ['Nome', 'Telefone', 'Email', 'Data Nasc.', 'Status', 'Ações'],
      users: []
    }
  },
  computed: {
    hiddenLeft() {
      return this.$store.state.hiddenLeft;
    },
  },
  methods: {
    async list() {
      this.users = await UsersService.list();
    }
  },
  mounted() {
    this.list();
  }
}
</script>

<style>
table {
  width: 100%;
  margin-top: 40px;
  border-spacing: 0;
  border-collapse: collapse;
}

.table-header {
  border: solid 1px lightgray;
  color: grey;
  height: 60px;
  overflow: auto;
  overflow-x: hidden;
}

.separator {
  height: 25px;
}

.user-row td {
  border-bottom: 10px solid white;
  height: 50px;
  background-color: #f5f4f4;
  color: grey;
  text-align: center;
}

.container {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.list-avatar {
  height: 40px;
  border-radius: 50%;
  margin-right: 20px;
}

.name-wrapper {
  display: flex;
  align-items: center;
  padding-left: 15%;
}

.name-text {
  text-align: center;
}

.acoes-wrapper {
  display: flex;
  justify-content: space-evenly;
}

.acoes-wrapper button {
  color: #00174a;
}

.search-wrapper label {
  position: relative;
  right: -30px;
  top: 10px;
  color: gray;
}

.active {
  background-color: #e6fff3;
  height: 20px;
  padding-top: 3px;
  width: 100px;
  color: #2bd988;
}

.inactive {
  background-color: #ffe6e6;
  height: 20px;
  padding-top: 3px;
  width: 100px;
  color: #d92b2b;
}

.request {
  position: fixed;
  z-index: 999;
  height: max-content;
  width: max-content;
  overflow: show;
  margin: auto;
  top: 0;
  left: 250px;
  bottom: 0;
  right: 0;
  color: white;
  display: flex;
  align-items: center;
  justify-content: center;
  padding: 10px;
  box-shadow: 1px 2px 1px 1px gray;
  border-radius: 5px;
  visibility: visible;
}

.good {
  background-color: #2bd988;
}

.bad {
  background-color: #d47575;
}

.no-users {
  color: grey;
  text-align: center;
  width: fit-content;
  margin: auto;
}

.modal {
  position: fixed;
  z-index: 999;
  height: max-content;
  width: max-content;
  overflow: show;
  margin: auto;
  top: 0;
  left: 250px;
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

.modal-wrapper {
  display: flex;
  margin-top: 10px;
  justify-content: space-evenly;
}

@media only screen and (max-width: 1280px) {
  .request {
    left: 80px;
  }

  .modal {
    left: 80px;
  }
}
</style>