<template>
  <div>
    <h1>Login</h1>
    <v-row align="center" justify="center">
      <v-col cols="12" sm="8" md="4">
        <v-card class="elevation-1 mb-5">
          <v-toolbar color="primary" dark flat>
            <v-toolbar-title>Login form</v-toolbar-title>
          </v-toolbar>
          <v-card-text>
            <v-form>
              <v-alert dense outlined type="error" v-if="errorMessage">{{errorMessage}}</v-alert>
              <v-text-field label="Email" prepend-icon="mdi-account" v-model="user.email"></v-text-field>
              <v-text-field label="Password" prepend-icon="mdi-lock" type="password" v-model="user.password"></v-text-field>
            </v-form>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="primary" @click="onLogin">Login</v-btn>
          </v-card-actions>
        </v-card>
        <router-link to="/register">
          Register
        </router-link>
      </v-col>
    </v-row>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
  data: () => ({
    user: {
      email: '',
      password: ''
    }
  }),
  computed: {
    ...mapGetters('identity', [
      'isAuthenticated',
      'errorMessage'
    ])
  },
  methods: {
    onLogin() {
      this.login(this.user)

      if(this.isAuthenticated) {
        this.$router.push({ path: '/' });
      }
    },
    ...mapActions('identity', [
      'login'
    ])
  }
}
</script>