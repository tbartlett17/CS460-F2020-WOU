// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$("input").click(function (e) {

    var table = document.getElementById("commitsTable");
    while (table.rows.length > 0) {
        table.deleteRow(0);
    }

    var idClicked = e.target.id;
    //console.log(idClicked);

    let address = "/api/commits?" + idClicked;
    console.log(address);


    $.ajax({
        type: "GET",
        dataType: "json",
        url: address,
        success: displayCommits,
        error: errorOnAjax
    });
});

function errorOnAjax() {
    console.log("ERROR in ajax request");

}

function displayCommits(data) {
    console.log(data);

    var table = document.getElementById("commitsTable");
    var header = table.createTHead();
    var body = table.createTBody();

    var headRow = header.insertRow(0);
    var hcell1 = headRow.insertCell(); //SHA
    var hcell2 = headRow.insertCell(); //Timestamp
    var hcell3 = headRow.insertCell(); //Committer
    var hcell4 = headRow.insertCell(); //Commit Message
    hcell1.innerHTML = "SHA".bold();
    hcell2.innerHTML = "Timestamp".bold(); 
    hcell3.innerHTML = "Committer".bold();
    hcell4.innerHTML = "Commit Message".bold();


    for (var i = 0, d; d = data[i]; i++) {

        var bodyRow = body.insertRow(0);
        var bcell1 = bodyRow.insertCell(); //SHA
        var bcell2 = bodyRow.insertCell(); //Timestamp
        var bcell3 = bodyRow.insertCell(); //Committer
        var bcell4 = bodyRow.insertCell(); //Commit Message

        bcell1.innerHTML = d.sha;
        bcell2.innerHTML = d.commit.author.date;
        bcell3.innerHTML = d.commit.author.name;
        bcell4.innerHTML = d.commit.message;
    }


}