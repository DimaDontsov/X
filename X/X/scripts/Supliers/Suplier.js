




vSuplierPage = new Vue({
    el: "#v-suplier-page",
    data: {
        User: null,
        DrugSuplies: null,
        Packs: null,
        Mess: ""
    },
    methods: {
        getUserId: function () {

        },
        fillUser: function () {

        },
        fillDrugSuplies: function () {

        },
        fillPacks: function () {

        },
        setUserId: function (u) {
            var that = this;
            $.get("/api/DrugSupliers/" + u, {}, function (data) {
                that.$data.User = data; 
            });
        }
    },

    created: function () {
        this.setUserId(loggedUserId);
    }
});
