




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
                                }
                                if (isFindSource) {
                                    break;
                                }
                            }
                        }
                    }
                }
            });
        },

        fillSuplyOffers() {
            var that = this;
            $.get("/Supliers/GetDrugSupliesOffers", { suplierId: that.User.Id }, function (data) {
                let suplies = JSON.parse(data);
                setRefs(suplies);
                that.MyDrugSuplies = suplies;
            })
        },
        setUserId: function (u) {
            var that = this;
            $.get("/api/DrugSupliers/" + u, {}, function (data) {
                that.$data.User = data;

                that.fillSuplyOffers();
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
            $.post("/api/DrugSuplyOffers", s, function () {
                that.fillSuplyOffers();
            });
        },

        startEdit: function (suplyId) {
            this.isEdit = true;
            this.SelectedSuplyId = suplyId;
            if (this.SelectedDrugId) {
                for (let i = 0; i < this.MyDrugSuplies.length; i++) {
                    if (this.MyDrugSuplies[i].Id === this.SelectedSuplyId) {
                        this.SelectedCount = this.MyDrugSuplies[i].Count;
                        this.SelectedDrugId = this.MyDrugSuplies[i].DrugId;
                        this.SelectedUnitId = this.MyDrugSuplies[i].UnitsOfMeasurementId;
                        this.SelectedPrice = this.MyDrugSuplies[i].Price;
                        break;
                    }
                }
            }
        },
        editSuply() {
            var that = this;
            var editableSuply = null;
            for (let s of this.MyDrugSuplies) {
                if (s.Id === this.SelectedSuplyId) {
                    editableSuply = s;
                    break;
                }
            }
            editableSuply.Id = that.SelectedSuplyId;
            editableSuply.Count= that.SelectedCount;
            editableSuply.DrugId= that.SelectedDrugId;
            editableSuply.UnitsOfMeasurementId= that.SelectedUnitId;
            editableSuply.Price= that.SelectedPrice;
            $.ajax({
                url: "/api/DrugSuplyOffers/" + that.SelectedSuplyId,
                type: "PUT",
                data: editableSuply,
                success: function (data) {
                    that.fillSuplyOffers();
                }
            });
            isEdit = false;
        },
        cancelEdit: function () {
            this.isEdit = false;
            this.SelectedCount = 0;
            this.SelectedDrugId = -1;
            this.SelectedUnitId = -1;
            this.SelectedPrice = 0;
        },

        removeSuply(suplyId) {
            var that = this;
            $.ajax({
                url: "/api/DrugSuplyOffers/" + suplyId,
                type: "Delete",
                success: function (data) {
                    that.fillSuplyOffers();
                }
            });
        }




    },

    created: function () {
        this.setUserId(loggedUserId);
        this.fillDrugs();
    }
});
