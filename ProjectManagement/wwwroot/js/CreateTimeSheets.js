//MonthData_0__Hours
//for
//document.getElementById("TeamLeadFee").addEventListener("blur", function () {
//    calculateNetMargin();

//});

//$().ready(function () {
//    console.log("document loaded");
//});

$(document).ready(function () {
    console.log("document loaded");

    var consultants = getConsultantValue();

    for (var i = 0; i < 12; i++) {
        $("#MonthData_" + i + "__Hours").bind('blur', {
            id: i
        }, function (event) {
            var data = event.data;
            calculate(data.id);
        });

        $("#MonthData_"+i+"__PaidAmount").bind('blur', { id: i }, function (event) {
            calculateVariation(event.data.id);
        });
    }

    function calculateVariation(rowindex) {
        var variation = 0;
        var consultantPay = 0;
        var paidAmount = 0;

        consultantPay = $("#MonthData_" + rowindex + "__ConsultantPay").val();
        paidAmount = $("#MonthData_" + rowindex + "__PaidAmount").val();

        variation = consultantPay - paidAmount;
        $("#MonthData_"+rowindex+"__Variation").val(variation);
    }

    function calculate(rowindex) {
        console.log("month calculate entry", rowindex);
        var consultantId;
        var billingRate = 0;
        var payRate = 0;
        if ($("#ConsultantId").val() == 'Please Select') {
            alert("Please select consultant from dropdown.");
        } else {
            consultantId = $("#ConsultantId").val();
            $.each(consultants, (index, consultant) => {
                if (consultant.Id == consultantId) {
                    console.log("Found!", consultant.Name);
                    billingRate = consultant.BillingRate;
                    payRate = consultant.PayRate;

                    console.log("Billing", billingRate);
                    console.log("payrate", payRate);
                }

            });
        }


        var monthHours = $("#MonthData_" + rowindex + "__Hours").val();
        var invoiceAmount = billingRate * monthHours;
        var consultantPay = payRate * monthHours;
        console.log("month", rowindex);
        console.log(monthHours);
        console.log(invoiceAmount);
        console.log(consultantPay);

        $("#MonthData_" + rowindex + "__InvoiceAmount").val(invoiceAmount);
        $("#MonthData_" + rowindex + "__ConsultantPay").val(consultantPay);
        //console.log($("#ConsultantId").val());
    }

    //var test = $("#ConsultantsList").val();
    //var test = $('#consultantslist').val();
    //console.log(test[1].Name)
});

//var test = document.getElementById('ConsultantsList').value;
//var myValue = '@ViewBag.ConsultantsList';
//alert(test[1].Name)