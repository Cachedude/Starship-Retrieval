//$(document).ready(function () {
//    $('#starShipSelect').change(function (value) {
//        var starShipID = $(this).val();
//        LoadStarShip(value);
//    })
//});

//function LoadStarShip(starShipID) {
//    var 

//    $.ajax({
//        url: '/Home/SetStarShip?id=' + starShipID,
//        success: function (response) {

//        },
//        error: function (error) {
//            alert(error);
//        }
//    });
//}

const selectElement = document.querySelector("#starShipSelect");

selectElement.addEventListener("change", (event) => {
    //LoadStarShip(event.target.value);
    var selectedID = event.target.value;
    var url = "/Home/SetStarShip?id=" + selectedID;

    //window.location.href = '@Url.Action("SetStarShipAsync", "Home")' + '?id=' + selectedID;
    window.location.href = url;
    //$.ajax({
    //    method: "POST",
    //    dataType: "json",
    //    url: url,
    //    data: {
    //        id: selectedID
    //    }
    //});
});