


vDistributorPage = new Vue({
    el: "#v-distributor-page",
    data: {
        User: {
            Name: "",
            Balance: -1
        },
        DrugSuplies: [],
        MyDrugSuplies: [],
        Packs: [],
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
            var that = this;
            $.get("/api/DrugDistributors/" + u, {}, function (data) {
                that.$data.User = data;
            });
        },
        setUserId: function (u) {
            var that = this;
            $.get("/api/DrugDistributors/" + u, {}, function (data) {
                that.$data.User = data;
            });
        }
    },
    created: function () {
        this.setUserId(loggedUserId);
    }
});
