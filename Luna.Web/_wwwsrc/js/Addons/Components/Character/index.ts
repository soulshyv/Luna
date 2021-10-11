import Vue from "vue";
import Character from "./Character.vue";

Vue.component("character", Character);

if (document.getElementsByClassName("character")) {
    let vue = new Vue({
        el: ".character"
    });
}