<template>
  <div id="app">
    <v-app id="inspire">
      <v-app-bar app color="primary" dark>
        <img class="mr-3" src="@/assets/logo.svg" height="40" />

        <router-link :to="'/'">
          <v-toolbar-title class="white--text">Plant Shop</v-toolbar-title>
        </router-link>

        <v-spacer></v-spacer>

        <router-link :to="'/cart'">
          <v-badge v-if="count" :content="count" color="orange" overlap>
            <v-icon large>mdi-cart</v-icon>
          </v-badge>
          <v-icon large v-else>mdi-cart</v-icon>
        </router-link>
        <v-icon large
          v-if="isAuthenticated"
          class="ml-5"
          @click="logout">mdi-logout</v-icon>
      </v-app-bar>
      <v-main>
        <v-container fluid>
          <v-row align="center" justify="center">
            <v-col class="text-center">
              <router-view></router-view>
            </v-col>
          </v-row>
        </v-container>
      </v-main>
    </v-app>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
  name: 'App',
  computed: {
    ...mapGetters('cart', [
      'count'
    ]),
    ...mapGetters('identity', [
      'isAuthenticated'
    ])
  },
  methods: {
    ...mapActions('identity', [
      'logout'
    ])
  }
}
</script>
