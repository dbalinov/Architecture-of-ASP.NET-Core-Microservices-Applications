<template>
  <div>
    <h1 class="text-h2">Shopping Cart</h1>
    <v-data-table
      :headers="headers"
      :items="items"
      :items-per-page="5"
      :loading="loading"
      class="elevation-1"
      hide-default-footer
    >
      <template v-slot:item.product="{ item }">
        <v-img :src="item.imageBase64" aspect-ratio="1" width="50" />
        {{ item.product }}
      </template>

      <template v-slot:item.price="{ item }">
        {{ item.price }} &euro;
      </template>

      <template v-slot:item.quantity="{ item }">
        {{ item.quantity }} 
        <v-icon @click="addToCart({ productId: item.productId, count: 1 })">mdi-chevron-up</v-icon>
        <v-icon @click="removeFromCart({ productId: item.productId, count: 1 })">mdi-chevron-down</v-icon>
      </template>
      <template v-slot:item.total="{ item }">
        {{ item.total }} &euro;
      </template>
    </v-data-table>
    <h2 class="text-h4 my-5">Total price: {{ totalPrice }} &euro;</h2>

    <v-btn color="primary" dark large to="/checkout">Checkout</v-btn>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
  data () {
    return {
      headers: [
        { text: 'Product', value: 'product' },
        { text: 'Price', value: 'price' },
        { text: 'Quantity', value: 'quantity' },
        { text: 'Total', value: 'total' }
      ]
    }
  },
  computed: {
    ...mapGetters('products', [
      'products',
      'loading'
    ]),
    ...mapGetters('cart', [
      'cartItems'
    ]),
    items() {
      return this.cartItems.map(cartItem => {
        const product = this.products.find(x => x.id == cartItem.productId)

        return {
          productId: cartItem.productId,
          product: product?.name,
          imageBase64: product?.imageBase64,
          price: product?.price,
          quantity: cartItem.count,
          total: product?.price * cartItem.count
        }
      });
    },
    totalPrice() {
      return this.items
        .reduce((acc, item) => acc + item.total, 0)
    }
  },
  methods: {
    ...mapActions('products', [
      'fetchProducts'
    ]),
    ...mapActions('cart', [
      'addToCart',
      'removeFromCart'
    ])
  },
  beforeMount() {
    this.fetchProducts()
  }
}
</script>
