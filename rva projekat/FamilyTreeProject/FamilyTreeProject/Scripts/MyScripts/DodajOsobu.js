$(document).ready(function () {
    $('#create').click(function () {
        var bio = JSON.parse(localStorage.getItem('bio'));
        let ime = $('#imeO').val();
        let prezime = $('#prezimeO').val();
        let email = $('#emailO').val();
        let kontakt = $('#telefonO').val();
        let adresa = $('#adresaO').val();
        $.ajax({
            url: 'api/Osoba/Dodaj',
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({
                ime: ime,
                prezime: prezime,
                email: email,
                brojTelefona: kontakt,
                adresa: adresa,
                m_Biography : bio
            }),

            success: function (data) {
                $("#create").hide();
                //sessionStorage.removeItem('userEmail');
                //sessionStorage.getItem('userEmail');
                console.log(data);
                $.ajax({
                    url: 'api/Osoba/Prikaz',
                    type: 'GET',
                    contentType: 'application/json',
                    dataType: 'json',

                    success: function (data) {
                        console.log(data);
                        upisUtabelu(data);

                        $("#undo").show();
                        $("#redo").show();
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