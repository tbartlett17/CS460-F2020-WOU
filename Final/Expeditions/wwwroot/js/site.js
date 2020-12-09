// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// This will set up a timer.  It will invoke the execute function every 5 seconds
$(document).ready(function () { window.setInterval(execute, 5000) });

function execute() {
    console.log('Running execute function');

    $.ajax({
        type: "GET",
        dataType: "json",
        url: "/Home/FetchStats",
        success: updateStats,
        error: errorOnAjax
    });
}

function errorOnAjax() {
    console.log("ERROR in ajax request");

}

function updateStats(stats) {

    console.log(stats);

    $("#stats").text(stats);
}