<template>
  <Fragment>
    <Header />
    <Sidebar />
    <!-- <Dashboard /> -->
  </Fragment>
</template>

<script>
import { Fragment } from 'vue-fragment';
import Sidebar from '@/components/SideBar'
import Header from '@/components/MainHeader'

export default {
  components: { Fragment, Sidebar, Header }
}
</script>

<style>
  button, button:focus {
    outline: none;
    background: transparent;
    border: 1px solid transparent;
  }

  button:active {
    outline: none;
    background: transparent;
    border: 1px solid grey;
  }

  .thin-width {
    width: 60px !important;
  }

  .thin-left {
    margin-left: 60px !important;
  }
</style>