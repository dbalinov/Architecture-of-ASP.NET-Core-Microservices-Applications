import { identityStore } from './store/identity-store'
import { identityRoutes } from './router/identity-routes'

export function addIdentityModule({ store, router }) {
  store.registerModule(['identity'], identityStore)

  router.addRoutes(identityRoutes)
}
