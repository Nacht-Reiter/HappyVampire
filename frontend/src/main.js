import Vue from "vue";
import App from "./App.vue";
import router from "./router.js";
import store from "./store/store";
import { addInterceptor } from "./axios.js";
import BootstrapVue from "bootstrap-vue";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";

addInterceptor();

Vue.config.productionTip = false;
Vue.use(BootstrapVue);

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
