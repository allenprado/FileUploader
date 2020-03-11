$(document).ready(function () {


    var _datepicker = $("#mydate").datepicker({
        format: "dd/mm/yyyy"
    });

    var _datepicker2 = $('#mydate2').datepicker({
        format: "dd/mm/yyyy"
    });

    _datepicker2.on("changeDate", function (e) {
        e.preventDefault();
        Loading(true);
        $.ajax({
            type: "Post",
            url: "/Reports/ListMax",
            data: { DateStart: $("#mydate").val(), DateEnd: $("#mydate2").val()},
            success: function (result) {
                $(".list-data").html(result);
                //BindGraphycs();
            },
            error: function () {
                alert("Error");
            }
        });

    });
});

