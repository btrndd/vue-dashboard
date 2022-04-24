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
    },

    getters: {
        hiddenWidth(state) {
            return state.hiddenWidth;
        },

        hiddenLeft(state) {
            return state.hiddenLeft;
        }
    },

    mutations: {
        hidden(state, payload) {
            state.hiddenLeft = payload;
            state.hiddenWidth = payload;
        }
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