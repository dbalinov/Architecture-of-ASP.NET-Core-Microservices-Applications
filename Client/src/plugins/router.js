import Vue from 'vue'
import VueRouter from 'vue-router'

Vue.use(VueRouter)

export default new VueRouter({
  routes: [
    { path: '/', redirect: '/product-list' }
  ],
  mode: 'history',
  base: process.env.BASE_URL
})
