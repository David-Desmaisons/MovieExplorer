import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    showSearch: true,
    searchInformation: "",
    loading: false
  },
  mutations: {
    updateSearchStatus(state, value) {
      state.showSearch = value;
    },
    updateSearchInformation(state, value) {
      state.searchInformation = value;
    },
    updateLoading(state, value) {
      state.loading = value;
    }
  },
  actions: {
    displaySearch({ commit }) {
      commit("updateSearchInformation", "");
      commit("updateSearchStatus", true);
    },
    hideSearch({ commit }) {
      commit("updateSearchInformation", "");
      commit("updateSearchStatus", true);
    }
  }
});
