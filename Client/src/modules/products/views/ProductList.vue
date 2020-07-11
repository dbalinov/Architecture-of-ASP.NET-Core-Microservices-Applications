<template>
  <div>
    <h1 class="text-h2">Products</h1>
        <v-select
          v-model="selectedCategoryId"
          :items="categories"
          filled
          label="Category"
          item-text="name"
          item-value="id"
          clearable
        ></v-select>

    <v-card class="d-flex flex-wrap justify-center" flat tile>
      <v-card
        v-for="product in products"
        :key="product.id"
        class="ma-5"
        outlined
        width="304"
      >
        <router-link :to="'/product-details/' + product.id">
          <v-img :src="product.imageBase64" height="380px"></v-img>
        </router-link>

        <v-card-title>
          {{ product.name }}
        </v-card-title>
        <v-card-actions class="mx-2">
          Price: &euro; {{ product.price }}
          <v-spacer></v-spacer>
          <v-btn
            outlined
            color="primary"
            @click="addToCart({ productId: product.id, count: 1 })"
          >
            Add to cart
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-card>
  </div>
</template>

<script>
import { mapGetters, mapActions } from 'vuex'

export default {
  data: () => ({
    selectedCategoryId: null
  }),
  computed: {
    ...mapGetters('products', [
      'products',
      'loading',
      'errorMessage'
    ]),
    ...mapGetters('categories', [
      'categories'
    ])
  },
  watch: {
    selectedCategoryId() {
      this.fetchProducts(this.selectedCategoryId)
    }
  },
  methods: {
    ...mapActions('products', [
      'fetchProducts'
    ]),
    ...mapActions('categories', [
      'fetchCategories'
    ]),
    ...mapActions('cart', [
      'addToCart'
    ])
  },
  beforeMount() {
    this.fetchProducts()
    this.fetchCategories()
  }
}
</script>