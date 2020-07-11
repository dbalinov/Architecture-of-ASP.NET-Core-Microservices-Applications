import store from '@/plugins/store'
import CartList from '../views/CartList.vue'
import Checkout from '../views/Checkout.vue'

const ifAuthenticated = (to, from, next) => {
  if (store.getters['identity/isAuthenticated']) {
    next()
    return
  }

  next('/login')
}

export const cartRoutes = [
  {
    path: '/cart',
    name: 'cartList',
    component: CartList
  },
  {
    path: '/checkout',
    name: 'checkout',
    component: Checkout,
    beforeEnter: ifAuthenticated
  }
]
