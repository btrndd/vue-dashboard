import Vue from 'vue';
import Router from 'vue-router';

// import Usuario from './components/usuario/Usuario'
// import UsuarioLista from './components/usuario/UsuarioLista'
// import UsuarioDetalhe from './components/usuario/UsuarioDetalhe'
// import UsuarioEditar from './components/usuario/UsuarioEditar'
Vue.use(Router)

const LoginPage = () => import(/* webpackChunkName: "login" */'@/views/LoginPage');
// const SideBar = () => import(/* webpackChunkName: "main" */'@/components/SideBar');
// const MainHeader = () => import(/* webpackChunkName: "main" */'@/components/MainHeader');
const MainPage = () => import(/* webpackChunkName: "main" */'@/views/MainPage');

const router = new Router({
    mode: 'history',
    routes: [{
        name: 'login',
        path: '/',
        component: LoginPage
    }, {
        name: 'dash',
        path: '/dashboard',
        components: {
            page: MainPage,
        }
    }, {
        name: 'users',
        path: '/users',
        components: {
            page: MainPage,
        }
    }]
});

export default router