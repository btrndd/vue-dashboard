import Vue from 'vue';
import Router from 'vue-router';

Vue.use(Router)

const Login = () => import(/* webpackChunkName: "login" */'@/views/login/IndexLogin');
const Sidebar = () => import(/* webpackChunkName: "layout" */'@/layout/AppSidebar');
const Header = () => import(/* webpackChunkName: "layout" */'@/layout/AppHeader');
const Dashboard = () => import(/* webpackChunkName: "dashboard" */'@/views/dashboard/IndexDashboard');
const Users = () => import(/* webpackChunkName: "users" */'@/views/users/IndexUsers');
const Register = () => import(/* webpackChunkName: "register" */'@/views/register/IndexRegister');

// import Login from '@/views/login/IndexLogin';
// import Sidebar from '@/layout/AppSidebar';
// import Header from '@/layout/AppHeader';
// import Dashboard from '@/views/dashboard/IndexDashboard';
// import Users from '@/views/users/IndexUsers';

const router = new Router({
    mode: 'history',
    routes: [{
        name: 'login',
        path: '/',
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
        path: '/register',
        components: {
            sidebar: Sidebar,
            header: Header,
            page: Register,
        }
    }]
});

export default router