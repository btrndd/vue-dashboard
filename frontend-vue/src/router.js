import Vue from 'vue';
import Router from 'vue-router';

// import Usuario from './components/usuario/Usuario'
// import UsuarioLista from './components/usuario/UsuarioLista'
// import UsuarioDetalhe from './components/usuario/UsuarioDetalhe'
// import UsuarioEditar from './components/usuario/UsuarioEditar'
Vue.use(Router)

const LoginPage = () => import(/* webpackChunkName: "login" */'@/views/LoginPage');
const Sidebar = () => import(/* webpackChunkName: "main" */'@/components/SideBar');
const Header = () => import(/* webpackChunkName: "main" */'@/components/MainHeader');
const Dashboard = () => import(/* webpackChunkName: "dashboard" */'@/components/DashBoard');

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
            sidebar: Sidebar,
            header: Header,
            page: Dashboard,
        }
    }, {
        name: 'users',
        path: '/users',
        components: {
            sidebar: Sidebar,
            header: Header,
            page: Dashboard,
        }
    }]
});

export default router