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


/*
funtion errorOnAjax() {
    console.log("ERROR in ajax request");
}

funtion displayCommmits(commitsReq) {
    console.log(commitsReq);
}
*/