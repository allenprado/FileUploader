$('.action').on('click', function subimitJS() {

    $('#submit').hide();
    $('#back').hide();
    $("#spinner").show();

    //Validation field file is empty
    if ($('#file').val() == '') {
        window.location.href = '/Upload/Error';
    } else {
        $('#form').submit();
    }

});