import Vue from 'vue';
import Router from 'vue-router';

// import Usuario from './components/usuario/Usuario'
// import UsuarioLista from './components/usuario/UsuarioLista'
// import UsuarioDetalhe from './components/usuario/UsuarioDetalhe'
// import UsuarioEditar from './components/usuario/UsuarioEditar'
Vue.use(Router)

const LoginPage = () => import(/* webpackChunkName: "login" */'@/views/LoginPage');
const SideBar = () => import(/* webpackChunkName: "main" */'@/components/SideBar');
const MainHeader = () => import(/* webpackChunkName: "main" */'@/components/MainHeader');

const router = new Router({
    mode: 'history',
    routes: [{
        path: '/',
        component: LoginPage
    }, {
        name: 'Dashboard',
        path: '/dashboard',
        components: {
            sidebar: SideBar,
            header: MainHeader
        }
    }]
});

export default router