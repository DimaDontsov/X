# CoffeeScript

var SupliesTable = new Vue({
    el : '#suplies-table';
    data : 
        suplies : []
    methods : {
        loadData : () -> {
            const that = this;
            
            $.ajax({
                contentType: "application/json",
                dataType: "json",
                url: window.ServerUrl + "/api/Suplies",
                method: "GET",
                success: (data) -> {
                    console.log(data);
                  that.$data.suplies = data;
                },
                error: () -> {
                    console.log("Oops");
                }
            });
        }
    }
})