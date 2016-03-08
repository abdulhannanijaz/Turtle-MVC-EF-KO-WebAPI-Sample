var ClanViewModel = function (data)
{
    
    var self = this;
    //variable to hold data and error
    self.clans = ko.observableArray();
    self.error = ko.observable();

    //api path
    var clanuri = '/api/clans/';

    //ajax request handler
    function ajaxHelper(uri, method, data)
    {
        //clear error
        self.error('');

        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });

    }

    //Get list of clans

    function getAllClans()
    {
        ajaxHelper(clanuri, 'GET').done(function (data) { self.clans(data); });
    }


    getAllClans();


};

ko.applyBindings(new ClanViewModel())