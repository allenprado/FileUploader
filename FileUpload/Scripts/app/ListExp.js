$(document).ready(function () {
    //Block second date until select the first one 
    $("#mydate2").prop('disabled', true);

    //Enable secound  Date after choose first one
    $("#mydate").on("changeDate", function (e) {
        $("#mydate2").prop('disabled', false);
    });


    //Set First DatePiker
    var _datepicker = $("#mydate").datepicker({
        format: "dd/mm/yyyy"
    });

    //Set Second DatePiker
    var _datepicker2 = $('#mydate2').datepicker({
        format: "dd/mm/yyyy"
    });



    //Get by API date from controller Reports
    $("#list").on("click", function (e) {
        e.preventDefault();
        $.ajax({
            type: "Post",
            url: "/Reports/ListExp",
            data: { DateStart: $("#mydate").val(), DateEnd: $("#mydate2").val() },
            success: function (result) {
                $(".list-data").html(result);
                BindGraphycs();
            },
            error: function () {
                alert("Error");
            }
        });

    });

});
function BindGraphycs() {
    //Get by API date for bind graph
    $.ajax({
        type: "Post",
        url: "/Reports/BindGraphycsExp",
        dataType: "json",
        data: { DateStart: $("#mydate").val(), DateEnd: $("#mydate2").val() },
        success: function (data) {

            var Dates = [];
            var MaxPrice = [];
            var MinPrice = [];

            //Feed the arrays with date from API
            $.each(data, function (index, obj) {

                Dates.push(obj.DateStr);
                MaxPrice.push(obj.MaxPrice);
            });

            //Bind the graphic
            Highcharts.chart('container', {
                chart: {
                    type: 'column'
                },
                title: {
                    text: 'Most Expensive Hour'
                },
                subtitle: {
                    text: 'Source: GridBeyond Web Developer Assignment'
                },
                xAxis: {
                    categories: Dates,
                    crosshair: true
                },
                yAxis: {
                    min: 0,
                    title: {
                        text: 'Prices (€)'
                    }
                },
                tooltip: {
                    headerFormat: '<span style="font-size:10px">{point.key}</span><table>',
                    pointFormat: '<tr><td style="color:{series.color};padding:0">{series.name}: </td>' +
                        '<td style="padding:0"><b>{point.y:.1f} €</b></td></tr>',
                    footerFormat: '</table>',
                    shared: true,
                    useHTML: true
                },
                plotOptions: {
                    column: {
                        pointPadding: 0.2,
                        borderWidth: 0
                    }
                },
                series: [{
                    name: 'Most Expensive Hour',
                    data: MaxPrice

                }]
            });



        }
    });
}