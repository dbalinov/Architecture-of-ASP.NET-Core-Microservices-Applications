import store from '@/plugins/store'
import Login from '../views/Login.vue'
import Register from '../views/Register.vue'

const ifNotAuthenticated = (to, from, next) => {
  if (!store.getters['identity/isAuthenticated']) {
    next()
    return
  }
  next('/')
}

export const identityRoutes = [
  {
    path: '/login',
    name: 'login',
    component: Login,
    beforeEnter: ifNotAuthenticated
  },
  {
    path: '/register',
    name: 'register',
    component: Register,
    beforeEnter: ifNotAuthenticated
  }
]
