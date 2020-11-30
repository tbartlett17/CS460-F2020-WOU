// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("input").click(function (e) {
    var idClicked = e.target.id;
    console.log(idClicked);

    $.ajax({
        type: "POST",
        dataType: "json",
        data: "{ 'AssignmentId': '" + idClicked + "' }",
        url: "/Home/CompleteAssignment",
        success: updateTable,
        error: errorOnAjax
    });
});


function errorOnAjax() {
    console.log("ERROR in ajax request");

}

function updateTable(data) {
    //hide the row on the table
    var table = document.getElementById("assignmentsTable");

    alert('we got a success?');
    console.log(data);

}