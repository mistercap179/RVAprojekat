$(document).ready(function () {
    $('#pretragaOsoba').click(function () {
        $.ajax({
            url: 'api/Osoba/Prikaz',
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            success: function (data) {
                console.log(data);
                pretraga(data);
                
            },
            error: function (err) {
                alert(JSON.stringify(err));
            }
        });
    });
});

function pretraga(data) {
    let imeO = $('#imeP').val();
    let prezimeO = $('#prezimeP').val();
    var osobeProlaze = [];
    for (let i = 0; i < data.length; i++) {
        let osoba = data[i];
        if (osoba.Ime.toLowerCase().includes(imeO.toLowerCase()) && osoba.Prezime.toLowerCase().includes(prezimeO.toLowerCase())) {
            osobeProlaze.push(osoba);
        }
    }

    upisUtabelu(osobeProlaze);
}