import { cartStore } from './store/cart-store'
import { orderStore } from './store/order-store'
import { paymentStore } from './store/payment-store'
import { cartRoutes } from './router/cart-routes'

export function addCartModule({ store, router }) {
  store.registerModule(['cart'], cartStore)
  store.registerModule(['order'], orderStore)
  store.registerModule(['payment'], paymentStore)

  router.addRoutes(cartRoutes)
}
