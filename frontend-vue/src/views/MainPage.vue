<template>
  <Fragment>
    <Header />
    <Sidebar />
    <Dashboard />
  </Fragment>
</template>

<script>
import { Fragment } from 'vue-fragment';
import Sidebar from '@/components/SideBar';
import Header from '@/components/MainHeader';
import Dashboard from '@/components/DashBoard';

export default {
  components: { Fragment, Sidebar, Header, Dashboard }
}
</script>

<style>
  button, button:focus {
    border: 1px solid transparent;
  }

  button:active {
    border: 1px solid grey;
  }

  .thin-width {
    width: 60px !important;
  }

  .thin-left {
    margin-left: 60px !important;
  }
</style>