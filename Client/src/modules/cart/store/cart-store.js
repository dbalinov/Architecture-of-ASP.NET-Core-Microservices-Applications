import {
  ADD_TO_CART,
  REMOVE_FROM_CART,
} from './mutation-types'

const cartItemsString = localStorage.getItem('cartItems')
const state = {
  cartItems: cartItemsString ? JSON.parse(cartItemsString) : []
}

const getters = {
  cartItems: state => state.cartItems,
  count: state => state.cartItems
    .reduce((acc, cartItem) => acc + cartItem.count, 0)
}

const mutations = {
  [ADD_TO_CART](state, { productId, count }) {
    const cartItem = state.cartItems.find(x => x.productId === productId);

    if (cartItem) {
      cartItem.count += count
    } else {
      state.cartItems = [
        ...state.cartItems,
        { productId, count }
      ]
    }
  },

  [REMOVE_FROM_CART](state, { productId, count }) {
    const cartItem = state.cartItems.find(x => x.productId === productId);

    if (!cartItem) {
      return
    }

    if (count >= cartItem.count) {
      state.cartItems = state.cartItems.filter(x => x.productId != productId)
    }
    else {
      cartItem.count -= count
    }
  }
}

const actions = {
  addToCart({ commit, state }, { productId, count }) {
    commit(ADD_TO_CART, { productId, count })
    
    localStorage.setItem('cartItems', JSON.stringify(state.cartItems));
  },

  removeFromCart({ commit, state }, { productId, count }) {
    commit(REMOVE_FROM_CART, { productId, count })

    localStorage.setItem('cartItems', JSON.stringify(state.cartItems));
  }
}

export const cartStore = {
  namespaced: true,
  state,
  getters,
  mutations,
  actions
}