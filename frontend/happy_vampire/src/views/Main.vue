<template>
  <div>
    {{ test }}
  </div>
</template>

<script>
import {mapActions, mapGetters} from 'vuex';

export default {
  name: "Main",
  created(){
    this.initState()
  },
  methods: {
    ...mapActions(['initState'])
  },
  computed: {
    ...mapGetters(['test'])
  }
};
</script>

<style>
</style>