import Vue from 'vue';
import Router from 'vue-router';

Vue.use(Router)

const LoginPage = () => import(/* webpackChunkName: "login" */'@/views/LoginPage');
const Sidebar = () => import(/* webpackChunkName: "main" */'@/components/main/SideBar');
const Header = () => import(/* webpackChunkName: "main" */'@/components/main/MainHeader');
const Dashboard = () => import(/* webpackChunkName: "dashboard" */'@/components/dashboard/DashBoard');
const Users = () => import(/* webpackChunkName: "users" */'@/components/users/UsersList');

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
            page: Users,
        }
    }]
});

export default router