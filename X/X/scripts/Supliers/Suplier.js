




vSuplierPage = new Vue({
    el: "#v-suplier-page",
    data: {
        that: this,
        isEdit: false,
        User: {
            Name: "",
            Balance: -1,
            Id :  null
        },
        MyDrugSuplies: [],//function () { return this.User.DrugSuplies },
        
        Drugs: [],
        Units: [],

        SelectedSuplyId: -1,
        SelectedCount: 0,
        SelectedDrugId: -1,
        SelectedUnitId: -1,
        SelectedPrice: 0,

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
    watch: {
        SelectedDrugId: function () {
            if (this.SelectedDrugId) {
                for (let i = 0; i < this.Drugs.length; i++) {
                    if (this.Drugs[i].Id === this.SelectedDrugId) {
                        this.Units = this.Drugs[i].UnitsOfMeasurement;
                        break;
                    }
                }
            }
        },
    },
    methods: {
        fillDrugs: function () {
            var that = this;
            $.get("/api/Drugs", {}, function (data) {
                that.$data.Drugs = data;
                for (let d of that.$data.Drugs) {
                    for (let iu = 0; iu < d.UnitsOfMeasurement.length; iu++) {
                        u = d.UnitsOfMeasurement[iu];
                        if (u.$ref !== undefined) {
                            let isFindSource = false;
                            for (let _d of that.$data.Drugs) {
                                for (let _u of _d.UnitsOfMeasurement) {
                                    isFindSource = _u.$id !== undefined && _u.$id === u.$ref;
                                    if (isFindSource) {
                                        d.UnitsOfMeasurement[iu] = _u;
                                        break;
                                    }
                                    if (isFindSource) {
                                        break;
                                    }
                                }
                            }

                        }
                    }
                }
            });
        },
        setUserId: function (u) {
            var that = this;
            $.get("/api/DrugSupliers/" + u, {}, function (data) {
                that.$data.User = data;
                that.$data.MyDrugSuplies = that.$data.User.DrugSuplies;
            });
        },
        addSuply: function () {
            let s = {
                DrugSuplierId : this.User.Id,
                Price : this.SelectedPrice,
                Count : this.SelectedCount,
                DrugId : this.SelectedDrugId,
                UnitsOfMeasurementId : this.SelectedUnitId
            }
            var that = this;
            $.post("/api/DrugSuplies", s, function () {
                that.fillDrugs();
            });
        },

        startEdit: function (e) {
            this.isEdit = true;
            this.SelectedSuplyId = e.target.dataset.suplyid;
            if (this.SelectedDrugId) {
                for (let i = 0; i < this.MyDrugSuplies.length; i++) {
                    if (this.MyDrugSuplies[i] === this.SelectedSuplyId) {
                        this.SelectedCount = MyDrugSuplies[i].Count;
                        this.SelectedDrugId = MyDrugSuplies[i].DrugId;
                        this.SelectedUnitId = MyDrugSuplies[i].UnitsOfMeasurementId;
                        this.SelectedPrice = MyDrugSuplies[i].Price;
                        break;
                    }
                }
            }
        },

        cancelEdit: function () {
            this.isEdit = false;
            this.SelectedCount = 0;
            this.SelectedDrugId = -1;
            this.SelectedUnitId = -1;
            this.SelectedPrice = 0;
        }

    },

    created: function () {
        this.setUserId(loggedUserId);
        this.fillDrugs();
    }
});
