import Vue from 'vue';
import Router from 'vue-router';

Vue.use(Router)

const Login = () => import(/* webpackChunkName: "login" */'@/views/login/IndexLogin');
const Sidebar = () => import(/* webpackChunkName: "layout" */'@/layout/AppSidebar');
const Header = () => import(/* webpackChunkName: "layout" */'@/layout/AppHeader');
const Dashboard = () => import(/* webpackChunkName: "dashboard" */'@/views/dashboard/IndexDashboard');
const Users = () => import(/* webpackChunkName: "users" */'@/views/users/IndexUsers');
const Register = () => import(/* webpackChunkName: "update" */'@/views/register/IndexRegister');
const Edit = () => import(/* webpackChunkName: "update" */'@/views/edit/IndexEdit');

const router = new Router({
    mode: 'history',
    routes: [{
        name: 'login',
        path: '/',
        redirect: '/login',
        component: Login
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
            page: Users,
        }
    }, {
        name: 'register',
        path: '/users/register',
        components: {
            sidebar: Sidebar,
            header: Header,
            page: Register,
        }
    }, {
        name: 'register',
        path: '/users/edit/:id',
        components: {
            sidebar: Sidebar,
            header: Header,
            page: Edit,
        }
    }]
});

export default router