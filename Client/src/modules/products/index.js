import { productsStore } from './store/products-store'
import { categoriesStore } from './store/categories-store'
import { productsRoutes } from './router/products-routes'

export function addProductsModule({ store, router }) {
  store.registerModule(['products'], productsStore)
  store.registerModule(['categories'], categoriesStore)

  router.addRoutes(productsRoutes)
}
