import Vue from "vue";
import Vuex from "vuex";
import { get } from "@/infra/ajax";

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    showSearch: true,
    searchInformation: "",
    error: null,
    showError: false,
    loading: false,
    genres: []
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
    },
    updateGenres(state, value) {
      state.genres = value;
    },
    updateError(state, value) {
      state.error = value;
    },
    updateShowError(state, value) {
      state.showError = value;
    }
  },
  actions: {
    displaySearch({ commit }) {
      commit("updateSearchInformation", "");
      commit("updateSearchStatus", true);
    },
    hideSearch({ commit }) {
      commit("updateSearchInformation", "");
      commit("updateSearchStatus", false);
    },
    async loadGenres({ commit, state }) {
      if (state.genres.length > 0) {
        return;
      }
      const result = await get("Genres");
      commit("updateGenres", result.genres);
    },
    displayError({ commit }, value) {
      commit("updateError", value);
      commit("updateShowError", true);
    }
  }
});
