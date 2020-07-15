import axios from 'axios'

import {
  SET_CATEGORIES,
  SET_CATEGORY_LOADING,
  SET_CATEGORY_ERROR
} from './mutation-types'

const catalogUrl = 'http://localhost:5005/';

const state = {
  categories: [],
  loading: false,
  errorMessage: ''
}

const getters = {
  categories: state => state.categories,
  loading: state => state.loading,
  errorMessage: state => state.errorMessage
}

const mutations = {
  [SET_CATEGORY_LOADING](state) {
    state.loading = true
    state.errorMessage = ''
  },
  
  [SET_CATEGORIES](state, categories) {
    state.loading = false
    state.categories = categories
  },

  [SET_CATEGORY_ERROR](state, { errorMessage }) {
    state.errorMessage = errorMessage
  }
}

const actions = {
  async fetchCategories({ commit }) {
    commit(SET_CATEGORY_LOADING)
  
    try {
      const response = await axios.get(`${catalogUrl}Categories`)

      commit(SET_CATEGORIES, response.data)
    } catch (e) {
      commit(SET_CATEGORY_ERROR, { errorMessage: e.message })
    }
  }
}

export const categoriesStore = {
  namespaced: true,
  state,
  getters,
  mutations,
  actions
}