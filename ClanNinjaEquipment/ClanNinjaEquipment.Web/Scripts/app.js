// ReSharper disable once UnusedParameter
var ClanViewModel = function (data)
{
    
    var self = this;
    //variable to hold data and error
    self.clans = ko.observableArray();
    self.error = ko.observable();

    self.detail = ko.observable();
    console.log(self.detail);

    self.newclan = {
        Name: ko.observable(),
        IsEvil: ko.observable(),
        SymbolPic: ko.observable()
      
    };
    self.success = ko.observable();


    //api path
    var clanuri = "/api/clans/";

    //ajax request handler
    function ajaxHelper(uri, method, data)
    {
        //clear error
        self.error("");

        return $.ajax({
            type: method,
            url: uri,
            dataType: "json",
            contentType: "application/json",
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXhr, textStatus, errorThrown) {
            self.error(errorThrown);
        });

    }

    //Get list of clans

    function getClansList()
    {
        ajaxHelper(clanuri, "GET").done(function (data) { self.clans(data); });
    }


    self.getClanDetail = function(item) {
        ajaxHelper(clanuri + item.ClanID, "GET").done(function (data) { self.detail(data); });
    }


    self.addClan = function (formElement) {
                var clan = {
                        Name: self.newclan.Name(),
                        IsEvil: self.newclan.IsEvil(),
                        SymbolPic: self.newclan.SymbolPic(),
                        CreatedBy: 1,
                        ClanGUID: "",
                        ClanID: 1,
                        IsDeleted: "",
                        CreatedOn: ""

                };

                ajaxHelper(clanuri, 'POST', clan).done(function(item) {
                    self.clans.push(item);
                   /// self.success("Good!");
                });
        }


    getClansList();
};
ko.applyBindings(new ClanViewModel());
