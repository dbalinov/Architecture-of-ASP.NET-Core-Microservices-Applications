import Vue from 'vue'
import vuetify from '@/plugins/vuetify'
import router from '@/plugins/router'
import store from '@/plugins/store'
import App from './App.vue'

import { addIdentityModule } from '@/modules/identity'
import { addProductsModule } from '@/modules/products'
import { addCartModule } from '@/modules/cart'

Vue.config.productionTip = false

addIdentityModule({ store, router })
addProductsModule({ store, router })
addCartModule({ store, router })

new Vue({
  store,
  router,
  vuetify,
  render: h => h(App),
}).$mount('#app')
