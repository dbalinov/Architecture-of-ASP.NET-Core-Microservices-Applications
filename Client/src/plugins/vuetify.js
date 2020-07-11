import Vue from 'vue'
import Vuetify from 'vuetify'
import colors from 'vuetify/lib/util/colors'
import '@mdi/font/css/materialdesignicons.css'
import 'vuetify/dist/vuetify.min.css'

Vue.use(Vuetify)

const options = {
  theme: {
    themes: {
      light: {
        primary: colors.lightGreen.darken3,
        secondary: colors.lightGreen.lighten2
      }
    }
  }
}

export default new Vuetify(options)