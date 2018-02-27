/* ********************************************************
* By Abel S. Salvatierra
* @2017 - Real Breeze Travel & Tours
* 
*********************************************************** */


var sMsg = "";

$(document).ready(function () {

    $('#btnSubmit1').on('click', function () {
        if (checkvalues() != 1) {
            $('#FormMsg').html(sMsg);
            event.preventDefault();
        }
    });

    $('#btnSubmit2').on('click', function () {
        if (checkvalues() != 1) {
            $('#FormMsg').html(sMsg);
            event.preventDefault();
        }
    });


    InitDatePicker();
    initFieldEvents();
})


function InitDatePicker() {

    $('input[name="JobStart"]').daterangepicker(
    {
        singleDatePicker: true,
        showDropdowns: true,
        locale: {
            format: 'MM/DD/YYYY'
        }
    },
    function (start, end, label) {
        //alert(start.format('YYYY-MM-DD h:mm A'));
        checkvalues();
    }
    );
}

//unused block
function initFieldEvents() {
    $('#LeadGuest').on('change', function () {
        checkvalues();
    });
    $('#NoOfAdult').on('change', function () {
        checkvalues();
    });
    $('#Email').on('change', function () {
        checkvalues();
    });

    $('#ContactNo').on('change', function () {
        checkvalues();
    });
    $('#NoOfChild').on('change', function () {
        checkvalues();
    });
    $('#Message').on('change', function () {
        checkvalues();
    });
}
//end of unused block

function checkvalues() {
    var isOK = 0;
    

    var leadguest = $('#LeadGuest').val();
    if (leadguest.trim().length > 0) isOK = 1;
    else {
        isOK = 0;
        sMsg = "Lead Guest is Required";
    }

    if (isOK == 1) {
        var email = $('#Email').val();
        if (email.trim().length > 0) {
            if (ValidateEmail(email)) isOK = 1;
            else {
                isOK = 0;
                sMsg = "Valid Email is required!";
            }
        }
        else {
            isOK = 0;
            sMsg = "Valid Email is required!";
        }
    }

    if (isOK == 1) {
        var NoAdults = $('#NoOfAdult').val();
        if (NoAdults > 0) isOK = 1;
        else {
            isOK = 0;
            sMsg = "Adult is required ( acceptable values: 1 - 999 )";
        }
    }

    return isOK;
}

function ValidateEmail(mail) {

    var x = mail;
    var atpos = x.indexOf('@');
    var dotpos = x.lastIndexOf(".");
    if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {
        //alert("Not a valid e-mail address");
        return (false);
    }

    return (true);
}

