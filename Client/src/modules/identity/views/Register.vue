<template>
  <div>
    <h1>Register</h1>
    <v-row align="center" justify="center">
      <v-col cols="12" sm="8" md="4">
        <v-card class="elevation-1 mb-5">
          <v-toolbar color="primary" dark flat>
            <v-toolbar-title>Register form</v-toolbar-title>
          </v-toolbar>
          <v-card-text>
            <v-form>
              <v-alert dense outlined type="error" v-if="errorMessage">{{errorMessage}}</v-alert>
              <v-text-field label="FirstName" v-model="user.firstName"></v-text-field>
              <v-text-field label="LastName" v-model="user.lastName"></v-text-field>
              <v-text-field label="Email" prepend-icon="mdi-account" v-model="user.email"></v-text-field>
              <v-text-field label="Password" prepend-icon="mdi-lock" type="password" v-model="user.password"></v-text-field>
              <v-text-field label="ConfirmPassword" prepend-icon="mdi-lock" type="password" v-model="user.confirmPassowrd"></v-text-field>
            </v-form>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="primary" @click="onRegister">Register</v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
  data: () => ({
    user: {
      firstName: '',
      lastName: '',
      email: '',
      password: '',
      confirmPassword: ''
    }
  }),
    computed: {
    ...mapGetters('identity', [
      'isAuthenticated',
      'errorMessage'
    ])
  },
  methods: {
    onRegister() {
      this.register(this.user)

      if(this.isAuthenticated) {
        this.$router.push({ path: '/' });
      }
    },
    ...mapActions('identity', [
      'register'
    ])
  }
}
</script>