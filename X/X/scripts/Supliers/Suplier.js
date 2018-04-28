




vSuplierPage = new Vue({
    el: "#v-suplier-page",
    data: {
        that : this,
        User: {
            Name: "",
            Balance: -1,
            Id :  null
        },
        MyDrugSuplies: function () { return this.User.DrugSuplies },
        NewSuply: {
            Drug: {
                Id: -1,
                Name: function () { for (let d of Drugs) if (d.Id === Id) return d.Name},
                UnitsOfMeasurement: []
            },
                

        },
        Drugs: [],
        /*
        AddEditDrugSuply: {
            Id: -1,
            DrugSuplierId: that.User.Id,
            Price: -1,
            Count: -1,
            UnitsOfMeasurementId: -1,
            DrugId: -1,
        } */
    },
    methods: {
        fillDrugs: function () {
            var that = this;
            $.get("/api/Drugs", {}, function (data) {
                that.$data.Drugs = data;
            });
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
        this.fillDrugs();
    }
});
