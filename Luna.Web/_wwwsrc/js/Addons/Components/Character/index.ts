import Vue from "vue";
import Character from "./Character.vue";

Vue.component("character", Character);

if (document.getElementsByClassName("character").length > 0) {
    let vue = new Vue({
        el: ".character"
    });
}