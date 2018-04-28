


vDistributorPage = new Vue({
    el: "#v-distributor-page",
    data: {
        User: {
            Name: "",
            Balance: -1,
            Id : null
        },
        DrugSuplies: [],
        MyDrugSuplies: function () {
            return this.User.BoughtDrugSuplies;
        },
        Packs: function () {
            let ps = [];
            for (let s of MyDrugSuplies) {
                for (let p of s.DrugPacks) {
                    ps.push(p);
                }
            }
            return ps;
        }
    },
    methods: {
        fillDrugSuplies: function () {
            var that = this;
            $.get("/api/DrugSupliers", {}, function (data) {
                for (let suplier of data) {
                    for (let suply of suplier.DrugSuplies) {
                        that.$data.DrugSuplies.push(suply);
                    }
                }
            });
        },
        setUserId: function (u) {
            var that = this;
            $.get("/api/DrugDistributors/" + u, {}, function (data) {
                that.$data.User = data;
            });
        },

        addDragPack: function (pack) {
            var that = this;
            var p = pack;
            $.ajax({
                url: "/api/DrugPack",
                type: 'PUT',
                success: function (data) {
                    for (let s of MyDrugSuplies) {
                        if (s.Id === p.BoughtDrugSupliesId) {
                            s.DrugPacks.push(s);
                        }
                    }
                }
            });
        }
    },
    created: function () {
        this.setUserId(loggedUserId);
        this.fillDrugSuplies();
        
    }
});
