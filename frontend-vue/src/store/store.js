import Vue from 'vue'
import Vuex from 'vuex'
import createPersistedState from 'vuex-persistedstate'

Vue.use(Vuex)

export default new Vuex.Store({
    plugins: [createPersistedState({
        storage: window.sessionStorage,
    })],
    state: {
        hiddenWidth: false,
        hiddenLeft: false,
        arrow: false,
        dashArrow: false,
        spinner: false,
        username: '',
        message: 'Usuário criado com sucesso!',
        alert: false,
        color: 'red'
    },

    getters: {
        hiddenWidth(state) {
            return state.hiddenWidth;
        },

        hiddenLeft(state) {
            return state.hiddenLeft;
        },

        arrow(state) {
            return state.arrow;
        },

        dashArrow(state) {
            return state.dashArrow;
        },
        
        spinner(state) {
            return state.spinner;
        },

        username(state) {
            return state.username;
        },

        message(state) {
            return state.message;
        },

        alert(state) {
            return state.alert;
        },

        color(state) {
            return state.color;
        }
    },

    mutations: {
        hidden(state, payload) {
            state.hiddenLeft = payload;
            state.hiddenWidth = payload;
        },
        updateUsersArrow(state, payload) {
            state.arrow = payload;
        },
        showSpinner(state, payload) {
            state.spinner = payload;
        },
        updateDashArrow(state, payload) {
            state.dashArrow = payload;
        },
        updateUsername(state, payload) {
            state.username = payload;
        },
        updateMessage(state, payload) {
            state.message = payload;
        },
        showAlert(state, payload) {
            state.alert = payload;
        },
        updateColor(state, payload) {
            state.color = payload;
        },
    },

    actions: {
        async showAlert(context) {
            context.commit('showAlert', true);
            setTimeout(() => {
                context.commit('showAlert', false)
            }, 3000);
        }
    }
})