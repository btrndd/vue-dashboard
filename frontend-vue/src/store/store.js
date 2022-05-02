import Vue from 'vue'
import Vuex from 'vuex'

// import carrinho from './modules/carrinho'
// import parametros from './modules/parametros'

// import * as getters from './getters'

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        hiddenWidth: false,
        hiddenLeft: false,
        arrow: false,
        dashArrow: false,
        spinner: false,
        username: ''
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
            return state.showSpinner;
        },

        username(state) {
            return state.username;
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
    },

    // actions: {
    //     adicionarProduto({ commit }, payload) {
    //         setTimeout(() => {
    //             commit('adicionarProduto', payload)
    //         }, 1000)
    //     }
    // }
    // getters,
    // modules: { carrinho, parametros }
})