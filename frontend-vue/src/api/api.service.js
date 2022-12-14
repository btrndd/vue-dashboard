import Vue from 'vue';
import axios from 'axios';
import VueAxios from 'vue-axios';
import { API_URL } from '@/config/config';

const ApiService = {
  init() {
    Vue.use(VueAxios, axios);
    this.setbaseURL(API_URL);
  },
  setbaseURL(url) {
    Vue.axios.defaults.baseURL = url;
  },
  getbaseURL() {
    this.init();
    return Vue.axios.defaults.baseURL;
  },
  setHeader() {
    this.init();
    const auth = JSON.parse(localStorage.getItem('auth'));
    const credentials = btoa(auth.email + ':' + auth.password);
    Vue.axios.defaults.headers.common = { 'Authorization': `Basic ${credentials}` };
  },
  get(resource, slug = '') {
    this.setHeader();
    return Vue.axios.get(`${resource}/${slug}`)
  },
  post(resource, params, config = null) {
    if (resource === 'login') {
      this.init();
    } else {
      this.setHeader();
    }   
    return Vue.axios.post(`${resource}`, params, config)
  },
  put(resource, params, slug, config = null) {
    this.setHeader();
    return Vue.axios.put(`${resource}/${slug}`, params, config)
  },
  delete(resource, slug) {
    this.setHeader();
    return Vue.axios.delete(`${resource}/${slug}`)
  },
}

export default ApiService;