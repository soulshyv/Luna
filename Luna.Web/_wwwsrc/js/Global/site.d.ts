import { VueConstructor } from "vue";

declare global {
    interface Window {
        moment: any;
        $: JQueryStatic;
        jQuery: JQueryStatic;
        Vue: VueConstructor;
    }
}
