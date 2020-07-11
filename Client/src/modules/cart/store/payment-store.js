import axios from 'axios'

import {
  SET_PAYMENT_LOADING,
  SET_PAYMENT_COMPLETED,
  SET_PAYMENT_ERROR
} from './mutation-types'

const paymentUrl = 'https://localhost:5007/';

const state = {
  loading: false,
  errorMessage: null
}

const getters = {
  loading: state => state.loading,
  errorMessage: state => state.errorMessage
}

const mutations = {
  [SET_PAYMENT_LOADING](state) {
    state.loading = true
    state.errorMessage = null
  },
  
  [SET_PAYMENT_COMPLETED](state) {
    state.loading = false
  },

  [SET_PAYMENT_ERROR](state, errorMessage) {
   state.loading = false
   state.errorMessage = errorMessage
  }
}

const actions = {
  async pay({ commit }, payRequest) {
    commit(SET_PAYMENT_LOADING)

    try {
      await axios.post(`${paymentUrl}Pay`, payRequest)

      commit(SET_PAYMENT_COMPLETED)
    } catch (e) {
      const errorMessage = e.response?.data?.errors || e.message

      commit(SET_PAYMENT_ERROR, errorMessage)
    }
  }
}

export const paymentStore = {
  namespaced: true,
  state,
  getters,
  mutations,
  actions
}