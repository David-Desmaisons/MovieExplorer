import { get } from "@/infra/ajax";

export default {
  install(Vue) {
    Vue.prototype.$get = get;
  }
};
