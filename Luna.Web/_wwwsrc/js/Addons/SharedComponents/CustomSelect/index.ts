import Vue from "vue";
import VSelect from "./SelectCustom.vue";

Vue.component("select-custom", VSelect);

if (document.getElementsByClassName("select-custom").length > 0) {
    let vue = new Vue({
        el: ".select-custom"
    });
}