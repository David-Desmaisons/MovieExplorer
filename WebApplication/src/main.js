import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import vuetify from "./plugins/vuetify";
import action from "./plugins/action.js";

Vue.config.productionTip = false;
Vue.use(action);

new Vue({
  router,
  vuetify,
  render: h => h(App)
}).$mount("#app");
