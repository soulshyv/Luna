import "@babel/polyfill";

import "./Window/jquery";
import "./Window/moment";
import "./Window/vue";

import "bootstrap-sass";

import "jquery-numeric";
import "jquery.marquee";

$(".test").on("click", function (e) {
    alert("coucou");
});