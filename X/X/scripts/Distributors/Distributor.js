

function clear( arr) {
    while (arr.length) {
        arr.pop();
    }
}

function newPackPlacemark(pack) {
    var mark = new ymaps.Placemark([pack.CoordX, pack.CoordY], {
        balloonContentHeader: pack.DrugName,
        balloonContentBody: pack.Count + " " + pack.UnitsOfMeasurement + " За " + pack.Price + "у.д.е."
    });
    return mark;
}

vDistributorPage = new Vue({
    el: "#v-distributor-page",
    data: {
        isAddPack: false,
        packGeo: null,
        packSuplyId: null,
        packCoords: null,
        packSuply: null,
        packDrugsCount: 0,
        packPrice:0,
        isBuySuply: false,
        User: {
            Name: "",
            Balance: -1,
            Id : null
        },
        DrugSuplies: [],
        MyDrugSuplies: [], 
        Packs:  []


    },
    methods: {
        fillDrugSuplies: function () {
            var that = this;
            clear(this.DrugSuplies);
            $.get("/api/DrugSupliers", {}, function (data) {
                for (let suplier of data) {
                    for (let suply of suplier.DrugSuplyOffers) {
                        that.DrugSuplies.push(suply);
                    }
                }
            });
        },
        fillPacks() {
            var that = this;
            clear(this.Packs);
            $.get("/Distributors/GetPacks", { distrId: that.User.Id }, function (data) {

                let packs = $.parseJSON(data);
                setRefs(packs);

                for (let p of packs) {
                    
                }
                for (let p of packs) {
                    if (myMap != null) {
                        p.Geo = newPackPlacemark(p);
                    }
                    that.Packs.push(p);
                }
            });
        },
        fillBoughtSuplies() {
            var that = this;
            clear(this.MyDrugSuplies);
            $.get("/Distributors/GetBoughtDrugSuplies", { distrId: that.User.Id }, function (data) {
                let suplies = JSON.parse(data);
                setRefs(suplies);
                for (let s of suplies) {
                    if (s.Count > 0) {
                        that.MyDrugSuplies.push(s);
                    }
                }
            });

        },
        setUserId: function (u) {
            var that = this;
            $.get("/api/DrugDistributors/" + u, {}, function (data) {
                that.$data.User = data;

                that.fillBoughtSuplies();
                that.fillPacks();
            });
        },

        addDragPack: function () {
            var that = this;
            var p =  {};
            p.BoughtDrugSuplyId = this.packSuplyId;
            p.CoordX = this.packCoords[0];
            p.CoordY = this.packCoords[1];
            p.Count = this.packDrugsCount;
            p.Price = this.packPrice;
            this.isAddPack = false;
            $.ajax({
                url: "/Distributors/AddDrugPack/",
                type: 'POST',
                data: p,
                success: function (data) {
                    let pack = JSON.parse(data);
                    setRefs(pack);
                    that.fillPacks();
                    that.fillBoughtSuplies();
                }
            });
        },

        buySuply: function (id) {
            var that = this;
            $.post("/Distributors/BuyDrugSuply", { suplyId: id, distrId: that.User.Id }, function (data) {
                var suply = JSON.parse(data);
                that.fillBoughtSuplies();
                that.fillDrugSuplies();
                that.User.Balance -= suply.Price;
            });
        },
        cancelAddPack: function () {
            this.isAddPack = false;
            myMap.geoObjects.remove(this.packGeo);
            packGeo = null;
        },
        showPack: function (packId) {
            for (let p of this.Packs) {
                if (p.Id === packId) {
                    myMap.setCenter([p.CoordX, p.CoordY], 12);
                    break;
                }
            }
        },
        returnPack: function (packId) {
            var that = this;
            $.post("/Distributors/ReturnDrugPack", { packId: packId }, function (data) {
                that.fillPacks();
                that.fillBoughtSuplies();
            });
        } 
    },
    watch: {
        packSuplyId: function () {
            for (s of this.MyDrugSuplies) {
                if (s.Id === this.packSuplyId) {
                    this.packSuply = s;
                    break;
                }
            }
        },
        Packs: function () {
            if (myMap !== null) {
                myMap.geoObjects.removeAll();
                for (let i = 0; i < this.Packs.length; i++) {
                    myMap.geoObjects.add(this.Packs[i].Geo);
                }
            }
        }
    },
    created: function () {
        this.setUserId(loggedUserId);
        this.fillDrugSuplies();
    }
});



ymaps.ready(init);
var myMap = null;

function init() {
    myMap = new ymaps.Map("map", {
        center: [55.76, 37.64],
        zoom: 7
    });

    myMap.events.add('click', function (e) {
        // Получение координат щелчка
        var coords = e.get('coords');
        vDistributorPage.isAddPack = true;
        vDistributorPage.packCoords = coords;
        myMap.geoObjects.remove(vDistributorPage.packGeo);

        var myPlacemark = new ymaps.Placemark(coords);
        myMap.geoObjects.add(myPlacemark);
  
        vDistributorPage.packGeo = myPlacemark;
        alert(coords.join(', '));
    });

    let coordss = [];
    for (p of vDistributorPage.Packs) {
        p.Geo = newPackPlacemark(p);
        coordss.push([p.CoordX, p.CoordY]);
        myMap.geoObjects.add(p.Geo);
    }
    //myMap.panTo(coordss);
}