$(document).ready(function () {
    $('#createBio').click(function () {

        let obrazovanje = $('#obrazovanje').val();
        let radnoIskustvo = $('#radnoIskustvo').val();
        let vjestine = $('#vjestine').val();

        $.ajax({
            url: 'api/Osoba/DodajBio',
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({
                obrazovanje: obrazovanje,
                radnoIskustvo: radnoIskustvo,
                vjestine: vjestine
            }),

            success: function (data) {
                $("#createBio").hide();
                localStorage.setItem('bio', JSON.stringify(data));
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