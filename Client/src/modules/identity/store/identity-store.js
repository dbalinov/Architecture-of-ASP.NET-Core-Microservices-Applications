import axios from 'axios'

import {
  SET_IDENTITY_LOADING,
  SET_IDENTITY_TOKEN,
  REMOVE_IDENTITY_TOKEN,
  SET_IDENTITY_ERROR,
} from './mutation-types'

const identityUrl = 'https://localhost:5001/';

const state = {
  loading: false,
  token: localStorage.getItem('user-token') || '',
  errorMessage: ''
}

if (state.token) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${state.token}`
}

const getters = {
  isAuthenticated: state => !!state.token,
  errorMessage: state => state.errorMessage
}

const mutations = {
  [SET_IDENTITY_LOADING](state) {
    state.loading = true
    state.errorMessage = ''
  },

  [SET_IDENTITY_TOKEN](state, { token }) {
    state.loading = false
    state.token = token
  },

  [REMOVE_IDENTITY_TOKEN](state) {
    state.token = ''
  },

  [SET_IDENTITY_ERROR](state, { errorMessage }) {
    state.loading = false
    state.errorMessage = errorMessage
  }
}

const actions = {
  async login({ commit }, user) {
    commit(SET_IDENTITY_LOADING)

    try {
      const response = await axios.post(`${identityUrl}Identity/Login`, user)

      localStorage.setItem('user-token', response.data.token)

      axios.defaults.headers.common['Authorization'] = `Bearer ${response.data.token}`

      commit(SET_IDENTITY_TOKEN, response.data)
    } catch (e) {
      localStorage.removeItem('user-token')

      commit(SET_IDENTITY_ERROR, { errorMessage: e.message })
    }
  },
  
  logout({ commit }) {
    commit(REMOVE_IDENTITY_TOKEN)

    axios.defaults.headers.common['Authorization'] = null

    localStorage.removeItem('user-token')
  },

  async register({ commit }, user) {
    commit(SET_IDENTITY_LOADING)
  
    try {
      const response = await axios.post(`${identityUrl}Identity/Register`, user)

      localStorage.setItem('user-token', response.data.token)
      
      commit(SET_IDENTITY_TOKEN, response.data)
    } catch (e) {
      localStorage.removeItem('user-token')

      commit(SET_IDENTITY_ERROR, { errorMessage: e.message })
    }
  }
}

export const identityStore = {
  namespaced: true,
  state,
  getters,
  mutations,
  actions
}