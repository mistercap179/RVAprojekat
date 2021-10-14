$(document).ready(function () {
    $('#register').click(function () {

        let ime = $('#ime').val();
        let prezime = $('#prezime').val();
        let lozinka = $('#lozinka').val();
        let email = $('#email').val();

        $.ajax({
            url: 'api/Korisnik/Register',
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({
                ime: ime,
                prezime: prezime,
                lozinka: lozinka,
                email: email,
                tip: 1
            }),

            success: function (data) {
                $("#register").hide();
                $("#forma").hide();
                sessionStorage.setItem('userEmail', data.email);
                //sessionStorage.removeItem('userEmail');
                //sessionStorage.getItem('userEmail');
                console.log(data);
            },
            error: function (err) {
                alert(JSON.stringify(err));
            }

        });
    });
});