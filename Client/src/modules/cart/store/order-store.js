import axios from 'axios'

import {
  SET_ORDER_LOADING,
  SET_ORDER_ID,
  SET_ORDER_ERROR
} from './mutation-types'

const orderUrl = 'http://localhost:5003/';

const state = {
  orderId: null,
  loading: false,
  errorMessage: null
}

const getters = {
  orderId: state => state.orderId,
  loading: state => state.loading,
  errorMessage: state => state.errorMessage
}

const mutations = {
  [SET_ORDER_LOADING](state) {
    state.loading = true
    state.errorMessage = null
    state.order = null
  },
  
  [SET_ORDER_ID](state, orderId) {
    state.loading = false
    state.orderId = orderId
  },

  [SET_ORDER_ERROR](state, errorMessage) {
    state.loading = false
    state.errorMessage = errorMessage
  }
}

const actions = {
  async createOrder({ commit }, orderRequest) {
    commit(SET_ORDER_LOADING)

    try {
      const response = await axios.post(`${orderUrl}Order`, orderRequest)

      commit(SET_ORDER_ID, response.data.orderId)
    } catch (e) {
      const errorMessage = e.response?.data?.errors || e.message

      commit(SET_ORDER_ERROR, errorMessage)
    }
  }
}

export const orderStore = {
  namespaced: true,
  state,
  getters,
  mutations,
  actions
}