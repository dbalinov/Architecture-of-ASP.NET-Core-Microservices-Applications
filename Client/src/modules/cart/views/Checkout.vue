<template>
  <div>
    <h1 class="text-h2">Checkout</h1>
    <v-stepper v-model="setp">
      <v-stepper-header>
        <v-stepper-step :complete="setp > 1" step="1">Order</v-stepper-step>
        <v-divider></v-divider>
        <v-stepper-step :complete="setp > 2" step="2">Payment</v-stepper-step>
        <v-divider></v-divider>
        <v-stepper-step step="3">Complete</v-stepper-step>
      </v-stepper-header>

      <v-stepper-items>
        <v-stepper-content step="1">
          <v-card class="mb-12" height="160px" flat>
            <v-form>
              <v-alert dense outlined type="error" v-if="errorMessage">{{errorMessage}}</v-alert>
              <v-text-field label="Phone Number" v-model="phoneNumber"></v-text-field>
              <v-text-field label="Address" v-model="address"></v-text-field>
            </v-form>
          </v-card>
          <v-btn color="primary" @click="onCreateOrder">
            Create Order
          </v-btn>
        </v-stepper-content>
        <v-stepper-content step="2">
          <v-card class="mb-12" height="350px" flat>
            <v-card class="mx-auto mb-5" width="344">
              <v-alert dense outlined type="error" v-if="errorMessage">{{ errorMessage }}</v-alert>
              <v-card-text>
                <v-form ref="form" v-model="valid" lazy-validation>
                  <v-row>
                    <v-col>
                      <v-text-field label="Card Number" v-model="card.number" v-on:keypress="isNumber" :rules="cardNumberRules" maxlength="16" required :disabled="loading" outlined>
                        <template v-slot:append>
                          <img src="@/assets/visa-icon.png" height="24" v-if="isVisa" />
                          <img src="@/assets/mastercard-icon.png" height="24" v-if="isMastercard" />
                        </template>
                      </v-text-field>
                    </v-col>
                  </v-row> 
                  <v-row>
                    <v-col cols="7" class="d-flex flex-row">
                      <v-select v-model="card.month" :items="months" :rules="monthRules" label="MM" outlined required :disabled="loading" style="border-top-right-radius: 0; border-bottom-right-radius: 0;"></v-select>
                      <v-select v-model="card.year" :items="years" :rules="yearRules" label="YY" outlined required :disabled="loading" style="border-top-left-radius: 0; border-bottom-left-radius: 0;"></v-select>
                    </v-col>
                    <v-col cols="5">
                      <v-text-field type="password" label="CVC" v-model="card.ccv" maxlength="3" :rules="cvcRules" outlined required :disabled="loading"></v-text-field>
                    </v-col>
                  </v-row>
                  <v-row>
                    <v-col>
                      <v-btn color="primary" :disabled="loading" :loading="loading" @click="onPay">
                        Pay
                      </v-btn>
                    </v-col>
                  </v-row>
                </v-form>
              </v-card-text>
            </v-card>
          </v-card>
        </v-stepper-content>
        <v-stepper-content step="3">
          <v-card class="mb-12" height="200px" flat>
            <h2>Payment completed</h2>
          </v-card>
        </v-stepper-content>
      </v-stepper-items>
    </v-stepper>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
  data: () => ({
    setp: 1,
    phoneNumber: '',
    address: '',
    card: {
      number: '',
      ccv: '',
      year: null,
      month: null
    },
    valid: true,
      cardNumberRules: [
        v => !!v || 'Card number is required'
      ],
      monthRules: [
        v => !!v || 'MM is required'
      ],
      yearRules: [
        v => !!v || 'YY is required'
      ],
      cvcRules: [
        v => !!v || 'CVC is required',
        v => /^[0-9]{3}$/.test(v) || 'CVC should contain 3 letters'
      ],
    months: [],
    years: []
  }),
  computed: {
    ...mapGetters('cart', [
      'cartItems'
    ]),
    ...mapGetters('order', [
      'orderId'
    ]),
    loading() {
      return this.$store.state.order.loading ||
        this.$store.state.payment.loading
    },
    errorMessage() {
      return this.$store.state.order.errorMessage ||
        this.$store.state.payment.errorMessage
    },
    orderRequest() {
      const orderLines = this.cartItems
        .map(cartItem => ({ 
          productId: cartItem.productId,
          quantity: cartItem.count
        }))

      return {
        phoneNumber: this.phoneNumber,
        address: this.address,
        orderLines
      }
    },
    paymentRequest() {
      return {
        orderId: this.orderId,
        totalPrice: 0, // TODO: Set total price
        cardNumber: this.card.number,
        ccv: this.card.ccv,
        year: this.card.year,
        month: this.card.month
      }
    },
    isVisa() {
      if (this.card.type) {
        return this.card.type === 'VISA';
      }

      if (!this.card.number) {
        return false;
      }

      return this.card.number.match(/^4/) != null;
    },
    isMastercard: function () {
      if (this.card.type) {
        return this.card.type === 'MASTERCARD';
      }

      if (!this.card.number) {
        return false;
      }

      return this.card.number.match(/^5[1-5]/) != null;
    }
  },
  methods: {
    ...mapActions('order', [
      'createOrder'
    ]),
    ...mapActions('payment', [
      'pay'
    ]),
    async onCreateOrder() {
      await this.createOrder(this.orderRequest)

      if (this.orderId > 0) {
        this.setp = 2
      }
    },
    async onPay() {
      // Deffer length validation on pay button click
      if (this.cardNumberRules.length === 1) {
        this.cardNumberRules.push(v => v.length === 16 || 'Card Number has invalid length');
      }

      if (!this.$refs.form.validate()) {
        return;
      }

      await this.pay(this.paymentRequest)

      if (!this.errorMessage) {
        this.setp = 3
      }
    },
    isNumber: function (evt) {
      evt = evt ? evt : window.event;
      const charCode = evt.which ? evt.which : evt.keyCode;

      if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        evt.preventDefault();
      } else {
        return true;
      }
    },
  },
  mounted() {
    var year = new Date().getFullYear();
    for (let i = 0; i <= 20; i++) {
      this.years.push((year + i).toString().slice(-2));
    }
    for (let j = 1; j <= 12; j++) {
      this.months.push(j > 9 ? j.toString() : "0" + j.toString());
    }
  }
}
</script>