$(document).ready(function () {
    $('#redo').click(function () {
        $.ajax({
            url: 'api/Osoba/RedoCommand',
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                $.ajax({
                    url: 'api/Osoba/Prikaz',
                    type: 'GET',
                    contentType: 'application/json',
                    dataType: 'json',

                    success: function (data) {
                        console.log(data);
                        upisUtabelu(data);
                    },
                    error: function (err) {
                        alert(JSON.stringify(err));
                    }
                });
            },
            error: function (err) {
                alert(JSON.stringify(err));
            }
        });
    });
});