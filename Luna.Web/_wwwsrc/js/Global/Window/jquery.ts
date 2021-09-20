/// <reference types="jquery"/>
import $ from "jquery";

export default (window["$"] = window["jQuery"] = $);
require("jquery-ui-dist/jquery-ui.js"); 