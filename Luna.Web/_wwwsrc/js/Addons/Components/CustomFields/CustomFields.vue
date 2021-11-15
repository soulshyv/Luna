<template>
    <div>
        <div class="row">
            <div class="col-md-1" v-if="urlNewOption">
                <button type="button"
                        class="btn btn-sm btn-primary"
                        data-bs-toggle="modal"
                        :data-bs-target="`#addNewOptionModal-${name}`"
                        style="height: 100%; border-top-right-radius: 0; border-bottom-right-radius: 0;"
                >
                  <i class="fa fa-plus"></i>
                </button>
            </div>
            <div :class="`col-md-${urlNewOption ? '11' : '12'}`" :style="urlNewOption ? `border-top-right-radius: 0; border-bottom-right-radius: 0;` : ''">
                <v-select :value="selection" class="" v-model="selection" :id="id" :name="name" :multiple="multiple" :options="options" label="text" :placeholder="placeholder" @input="select" v-on:reset="reset">
                    <template slot="option" slot-scope="option">
                        <span>{{ option.text }}</span>
                    </template>
                </v-select>
              <template v-for="(property, index) in customSection.customProperties">
                  <div class="row">
                      <div class="col-md-12">
                          
                      </div>
                  </div>
              </template>
            </div>
        </div>
    </div>
</template>

<script>
    import {CustomField} from "../../Models/CustomField";

    export default {
        name: "CustomFields",
        props: {
            name: {
                type: String,
                default: ""
            },
            id: {
                type: String,
                default: ""
            }
        },
        data() {
            return {
                customField: CustomField
            }
        },
        mounted() {
            let $this = this;

            if (this.url) {
                fetch(this.url).then(res => {
                    res.json().then(json => {
                        $this.options = json;
                        $this.selection = $this.defaultValue ? json.find(_ => _.value === this.defaultValue) : null;
                    });
                });
            }
        },
        methods: {
            select() {
                this.$emit('input', this.selection);
            },
            reset() {
                this.selection = null;
            },
            toggleModal() {
                $(`#addNewOptionModal-${this.name}`).modal('toggle');
            },
            add() {
                if (!this.newOptionName || !this.newOptionName.length) {
                    return;
                }
                
                let $this = this;
                
                $.ajax({
                    url: this.urlNewOption,
                    type: 'POST',
                    data: {
                        name: $this.newOptionName,
                        description: $this.newOptionDescription,
                    }
                }).done(function(data) {
                    $this.errorMessage = null;

                    if ($this.url) {
                        fetch($this.url).then(res => {
                            res.json().then(json => ($this.options = json));
                        });
                    }

                    $this.toggleModal();
                    $this.newOptionName = "";
                    $this.newOptionDescription = "";
                }).fail(function(data) {
                    $this.errorMessage = "L'entité n'a pas pu être ajoutée";
                });
            }
        }
    }
</script>
