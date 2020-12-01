// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$("input").click(function (e) {
    if (e.target.id.substring(0,5) == "chbx_")
    {
        //var thing = e;
        //alert(thing);
        
        var idClicked = e.target.id.substring(5);
        console.log(idClicked);

        $.ajax({
            type: "POST",
            dataType: "json",
            data: { assignmentId: idClicked },
            url: "/Home/CompleteAssignment",
            success: updateTable,
            error: errorOnAjax
        });
    }
});

function errorOnAjax() {
    console.log("ERROR in ajax request");

}

function updateTable(data) {
    //hide the row on the table
    var table = document.getElementById("assignmentsTable");
    table.deleteRow($("#chbx_" + data).closest("tr").prop("rowIndex"));
    //var myRow = 
    

    //alert($("#chbx_" + data).closest("tr").prop("rowIndex"));
    //console.log(data);

}

$("#newAssSubBtn").click(function (e) {
    var tagList = [];
    $(':checkbox[name="tag"]:checked').each(function () {
        tagList.push(this.value);
    });
    //console.log(tagList);
    alert(tagList);

    $.ajax({
        type: "POST",
        dataType: "json",
        data: { tagList: tagList },
        url: "/Home/AddAssignmentPage",
        success: updateTable,
        error: errorOnAjax
    });
});