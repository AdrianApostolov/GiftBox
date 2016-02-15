(function () {
    $('#searchInput').on('input', (function () {
        var controller = '/Home';
        var url = controller + '/Search';
        if (this.value.length >= 2) {
            var query = $('#searchInput').val();

            $.get(url, { searchInput: query }, function (data) {
                $("#all-homes").hide();
                console.log(url);
                $("#ajax-search-results").html(data)
                    .show();

                if (data !== 'No pages found') {
                    $("#ajax-search-results").append("Press search for more results");
                }
            });
        }

        if (this.value.length === 0) {
            $("#all-homes").show();
            $("#ajax-search-results").hide();
        }
    }));
})();