<template>
    <div>
        <table>
            <thead>
                <tr>
                    <th>
                        <input type="text" v-model="name" placeholder="Nom" />
                    </th>
                </tr>
                <tr>
                    <th></th>
                    <th></th>
                    <th></th>
                    <th></th>
                </tr>
            </thead>
        </table>
    </div>
</template>

<script>

export default {
    name: "CustomProperties",
    props: {
        
    },
    data() {
        return {
            name: "",
            type: "",
            properties: []            
        }
    },
    mounted() {
        
    },
    methods: {
        
    }
}
</script>
