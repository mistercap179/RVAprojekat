$(document).ready(function () {

    $("#formaPrijava").show();
    $("#pretraga").hide();
    $("#undo").hide();
    $("#redo").hide();
    $("#modifikacijaKorisnika").hide();
    $("#formaModifikacijeKorisnika").hide();
    $("#logout").hide();
    $("#forma").hide();
    $("#formareg").hide();
    $("#tabela").hide();
    $("#refresh").hide();
    $("#formaOsoba").hide();
    $("#createBio").hide();
    $("#create").hide();
    $("#modify").hide();
    $("#dodajOsobi").hide();
    $("#tabelaChild").hide();
    $("#tabelaParent").hide();
    $("#tabelaSpouse").hide();


    $("#formareg").click(function () {
        if ($('#forma').is(':hidden'))
            $('#forma').show();
        else
            $('#forma').hide();
    });
    $("#refresh").click(function () {
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
    });
    $('#login').click(function () {
        let username = $('#username').val();
        let password = $('#password').val();

        $.ajax({
            url: 'api/Korisnik/Login',
            type: 'POST',
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify({
                email: username,
                lozinka: password
            }),
            //// za get
            //data: $.para({
            //    // neki json
            //}, true),
            success: function (data) {
                $("#login").hide();
                $("#formaPrijava").hide();

                $("#pretraga").show();

                $("#logout").show();
                $("#modifikacijaKorisnika").show();

                sessionStorage.setItem('userEmail', data.Email);
                sessionStorage.setItem('userId', data.IdK);
                sessionStorage.setItem('userIme', data.Ime);                // zbog modifikacije korisnika
                sessionStorage.setItem('userLozinka', data.Lozinka);
                sessionStorage.setItem('userPrezime', data.Prezime);
                sessionStorage.setItem('userTip', data.Tip);
                var username = sessionStorage.getItem('userEmail');
                if (username == 'admin') {
                    $("#register").show();     //ukoliko se admin prijavi
                    $("#forma").show();
                    $("#formareg").show();
                    $("#tabela").show();
                    $("#refresh").show();
                    $("#dodajOsobi").show();
                    $("#modKorisnik").show();
                }
                else {
                    $("#tabela").show();
                    $("#refresh").show();
                    $("#dodajOsobi").show();
                    $("#modKorisnik").show();

                }
                //sessionStorage.removeItem('userEmail');
                //sessionStorage.getItem('userEmail');

                console.log(data);
            },
            error: function (err) {
                alert(JSON.stringify(err));
            }
        });
    });

    $("#logout").click(function () {
        location.reload();
    });

    $("#dodajOsobi").click(function () {
        if ($('#formaOsoba').is(':hidden')) {
            $('#formaOsoba').show();
            $('#createBio').show();
            $('#create').show();
        }
        else {
            $('#formaOsoba').hide();
            $('#createBio').hide();
            $('#create').hide();
        }
    });

    $('#modifikacijaKorisnika').click(function ()
    {
        $('#formaModifikacijeKorisnika').show();
        let imeK = sessionStorage.getItem('userIme');
        let prezimeK = sessionStorage.getItem('userPrezime');
        $('#imeM').val(imeK);
        $('#prezimeM').val(prezimeK);
    });
});


function upisUtabelu(data) {
    $("#tabelabody").html("");

    for (let i = 0; i < data.length; i++) {
        let tr = document.createElement('tr');

        $('#tabelabody').append(tr);

        let o = data[i];

        let td1 = document.createElement('td');
        $(tr).append(td1);
        td1.innerHTML = o.Ime;

        let td2 = document.createElement('td');
        $(tr).append(td2);
        td2.innerHTML = o.Prezime;

        let td3 = document.createElement('td');
        $(tr).append(td3);
        td3.innerHTML = o.Email;

        let td4 = document.createElement('td');
        $(tr).append(td4);
        td4.innerHTML = o.BrojTelefona;

        let td5 = document.createElement('td');
        $(tr).append(td5);
        td5.innerHTML = o.Adresa;

        let td6 = document.createElement('td');
        $(tr).append(td6);
        td6.innerHTML = o.m_Biography.Obrazovanje;

        let td7 = document.createElement('td');
        $(tr).append(td7);
        td7.innerHTML = o.m_Biography.RadnoIskustvo;

        let td8 = document.createElement('td');
        $(tr).append(td8);
        td8.innerHTML = o.m_Biography.Vjestine;

        let td9 = document.createElement('td');
        $(tr).append(td9);

        let btnChild = document.createElement('button');
        btnChild.id = "dugmeChild" + o.Id;
        btnChild.innerHTML = "Dijete";
        $(td9).append(btnChild);
        btnChild.onclick = function () {
            $("#tabelaSpouse").hide();
            $("#tabelaParent").hide();
            $("#tabelaChild").show();

            $.ajax({
                url: 'api/Osoba/PrikazDjece',
                type: 'POST',
                contentType: 'application/json',
                dataType: 'json',
                data: JSON.stringify(
                    o, o
                ),
                success: function (data) {
                    console.log(data);
                    upisUtabeluChild(data);
                },
                error: function (err) {
                    alert(JSON.stringify(err));
                }
            });
        }
        let btnParent = document.createElement('button');
        btnParent.id = "dugmeParent" + o.Id;
        btnParent.innerHTML = "Roditelj";
        $(td9).append(btnParent);
        btnParent.onclick = function () {
            $("#tabelaChild").hide();
            $("#tabelaSpouse").hide();
            $("#tabelaParent").show();

            $.ajax({
                url: 'api/Osoba/PrikazRoditelj',
                type: 'POST',
                contentType: 'application/json',
                dataType: 'json',
                data: JSON.stringify(
                    o, o
                ),
                success: function (data) {
                    console.log(data);
                    upisUtabeluParent(data);
                },
                error: function (err) {
                    alert(JSON.stringify(err));
                }
            });
        }
        let btnSpouse = document.createElement('button');
        btnSpouse.id = "dugmeSpouse" + o.Id;
        btnSpouse.innerHTML = "Supruznik";
        $(td9).append(btnSpouse);
        btnSpouse.onclick = function () {
            $("#tabelaChild").hide();
            $("#tabelaParent").hide();
            $("#tabelaSpouse").show();

            $.ajax({
                url: 'api/Osoba/PrikazSupruznik',
                type: 'POST',
                contentType: 'application/json',
                dataType: 'json',
                data: JSON.stringify(
                    o, o
                ),
                success: function (data) {
                    console.log(data);
                    upisUtabeluSpouse(data);
                },
                error: function (err) {
                    alert(JSON.stringify(err));
                }
            });
        }


        let td10 = document.createElement('td');
        $(tr).append(td10);


        let btnDel = document.createElement('button');
        btnDel.id = "dugmeDel" + o.Id;
        btnDel.innerHTML = "Obrisi";
        $(td10).append(btnDel);

        btnDel.onclick = function () {

            $.ajax({
                url: 'api/Osoba/Delete',
                type: 'DELETE',
                contentType: 'application/json',
                dataType: 'json',
                data: JSON.stringify(
                    o,o
                ),
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
        }

        let td11 = document.createElement('td');
        $(tr).append(td11);


        let btnMod = document.createElement('button');
        btnMod.id = "dugmeMod";
        btnMod.innerHTML = "Izmijeni";
        $(td11).append(btnMod);

        btnMod.onclick = function () {

            $('#formaOsoba').show();
            $('#modify').show();
            $('#create').hide();
            $('#createBio').hide();


            $('#imeO').val(o.Ime);
            $('#prezimeO').val(o.Prezime);
            $('#emailO').val(o.Email);
            $('#telefonO').val(o.BrojTelefona);
            $('#adresaO').val(o.Adresa);
            $('#obrazovanje').val(o.m_Biography.Obrazovanje);
            $('#radnoIskustvo').val(o.m_Biography.RadnoIskustvo);
            $('#vjestine').val(o.m_Biography.Vjestine);

            sessionStorage.setItem('idBio', o.m_Biography.IdB);
                //sessionStorage.removeItem('userEmail');
                //sessionStorage.getItem('userEmail');
            localStorage.setItem('id', JSON.stringify(o.IdP));
            //localStorage.setItem('idBio', JSON.stringify(o.m_Biography.IdB));
        }

    }
}


function upisUtabeluChild(data) {
    $("#tabelaChildbody").html("");
    let tr = document.createElement('tr');

    $('#tabelaChildbody').append(tr);

    let c = data;

    let td1 = document.createElement('td');
    $(tr).append(td1);
    td1.innerHTML = c.ime;

    let td2 = document.createElement('td');
    $(tr).append(td2);
    td2.innerHTML = c.prezime;

    let td3 = document.createElement('td');
    $(tr).append(td3);
    td3.innerHTML = c.email;

    let td4 = document.createElement('td');
    $(tr).append(td4);
    td4.innerHTML = c.telefon;

    let td5 = document.createElement('td');
    $(tr).append(td5);
    td5.innerHTML = c.adresa;
}

function upisUtabeluParent(data) {
    $("#tabelaParentbody").html("");
    let tr = document.createElement('tr');

    $('#tabelaParentbody').append(tr);

    let c = data;

    let td1 = document.createElement('td');
    $(tr).append(td1);
    td1.innerHTML = c.ime;

    let td2 = document.createElement('td');
    $(tr).append(td2);
    td2.innerHTML = c.prezime;

    let td3 = document.createElement('td');
    $(tr).append(td3);
    td3.innerHTML = c.email;

    let td4 = document.createElement('td');
    $(tr).append(td4);
    td4.innerHTML = c.telefon;

    let td5 = document.createElement('td');
    $(tr).append(td5);
    td5.innerHTML = c.adresa;
}
function upisUtabeluSpouse(data) {
    $("#tabelaSpousebody").html("");
    let tr = document.createElement('tr');

    $('#tabelaSpousebody').append(tr);

    let c = data;

    let td1 = document.createElement('td');
    $(tr).append(td1);
    td1.innerHTML = c.ime;

    let td2 = document.createElement('td');
    $(tr).append(td2);
    td2.innerHTML = c.prezime;

    let td3 = document.createElement('td');
    $(tr).append(td3);
    td3.innerHTML = c.email;

    let td4 = document.createElement('td');
    $(tr).append(td4);
    td4.innerHTML = c.telefon;

    let td5 = document.createElement('td');
    $(tr).append(td5);
    td5.innerHTML = c.adresa;
}