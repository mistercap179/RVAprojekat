$(document).ready(function () {
    $('#izmjenaKorisnika').click(function () {
        let imeK = $('#imeM').val();
        let prezimeK = $('#prezimeM').val();
        let idK = sessionStorage.getItem('userId');
        let lozinkaK = sessionStorage.getItem('userLozinka');
        let emailK = sessionStorage.getItem('userEmail');
        let tipK = sessionStorage.getItem('userTip');
        $.ajax({
            url: 'api/Korisnik/Izmjena',
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({
                idK: idK,
                ime: imeK,
                prezime: prezimeK,
                lozinka: lozinkaK,
                email: emailK,
                tip: tipK
            }),

            success: function (data) {
                //sessionStorage.removeItem('userEmail');
                //sessionStorage.getItem('userEmail');
                $('#formaModifikacijeKorisnika').hide();
                console.log(data);
            },
            error: function (err) {
                alert(JSON.stringify(err));
            }

        });
    });
});