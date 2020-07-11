import axios from 'axios'

import {
  SET_PRODUCTS,
  SET_PRODUCT_LOADING,
  SET_PRODUCT_ERROR,
} from './mutation-types'

const catalogUrl = 'https://localhost:5005/';

const state = {
  products: [],
  loading: false,
  errorMessage: ''
}

const getters = {
  products: state => state.products,
  loading: state => state.loading,
  errorMessage: state => state.errorMessage
}

const mutations = {
  [SET_PRODUCT_LOADING](state) {
    state.loading = true
    state.errorMessage = ''
  },
  
  [SET_PRODUCTS](state, products) {
    state.loading = false
    state.products = products
  },

  [SET_PRODUCT_ERROR](state, { errorMessage }) {
    state.errorMessage = errorMessage
  }
}

const actions = {
  async fetchProducts({ commit }, categoryId) {
    commit(SET_PRODUCT_LOADING)
  
    try {
      const queryParams = categoryId ? `?categoryId=${categoryId}` : '';
      const response = await axios.get(`${catalogUrl}Products${queryParams}`)

      commit(SET_PRODUCTS, response.data)
    } catch (e) {
      commit(SET_PRODUCT_ERROR, { errorMessage: e.message })
    }
  }
}

export const productsStore = {
  namespaced: true,
  state,
  getters,
  mutations,
  actions
}