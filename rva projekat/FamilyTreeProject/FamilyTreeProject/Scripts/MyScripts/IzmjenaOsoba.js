$(document).ready(function () {
    $('#modify').click(function () {
        let Biografija = {};
        let id = JSON.parse(localStorage.getItem('id'));
        let idB = sessionStorage.getItem('idBio');
        let ime = $('#imeO').val();
        let prezime = $('#prezimeO').val();
        let email = $('#emailO').val();
        let telefon = $('#telefonO').val();
        let adresa = $('#adresaO').val();
        Biografija.idB = idB;
        Biografija.obrazovanje = $('#obrazovanje').val();
        Biografija.radnoIskustvo = $('#radnoIskustvo').val();
        Biografija.vjestine = $('#vjestine').val();
        
        /*
        var bio = JSON.parse(localStorage.getItem('biografija'));
        localStorage.clear();
        */
        $.ajax({
            url: 'api/Osoba/Izmijeni',
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({
                idP: id,
                ime: ime,
                prezime: prezime,
                email: email,
                brojTelefona: telefon,
                adresa: adresa,
                m_Biography: Biografija
            }),
            success: function (data) {
                $('#modify').hide();
                $('#create').show();
                $('#createBio').show();
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