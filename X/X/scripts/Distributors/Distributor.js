


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
        AllDrugs: [],
        Mess: ""
    },
    methods: {
        getUserId: function () {

        },
        fillUser: function () {

        },
        fillDrugSuplies: function () {

        },
        fillDrugs : function (){
            var that = this;
            $.get("/api/DrugSupliers/" + u, {}, function (data) {
                that.$data.AllDrugs = data;
            });
        },
        fillPacks: function () {
            var that = this;
            $.get("/api/DrugDistributors/" + u, {}, function (data) {
                that.$data.Packs = data;
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
