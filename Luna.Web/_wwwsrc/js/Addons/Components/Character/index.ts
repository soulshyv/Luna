import Vue from "vue";
import Character from "./Character.vue";

Vue.component("character", Character);

let vue = new Vue({
    el: ".character"
});