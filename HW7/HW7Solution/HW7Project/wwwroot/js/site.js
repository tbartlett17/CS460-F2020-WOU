// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$("input").click(function (e) {
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

    for (var i = 0, d; d = data[i]; i++) {

        var row = table.insertRow(i + 1);
        var cell1 = row.insertCell(); //SHA
        var cell2 = row.insertCell(); //Timestamp
        var cell3 = row.insertCell(); //Committer
        var cell4 = row.insertCell(); //Commit Message

        cell1.innerHTML = d.sha;
        cell2.innerHTML = d.commit.author.date;
        cell3.innerHTML = d.commit.author.name;
        cell4.innerHTML = d.commit.message;
    }


}