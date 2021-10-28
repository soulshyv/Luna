import Vue from "vue";
import CustomPropertyType from "./CustomPropertyType.vue";

Vue.component("custom-property-types", CustomPropertyType);

if (document.getElementsByClassName("customPropertyType").length > 0) {
    let vue = new Vue({
        el: ".customPropertyType"
    });
}