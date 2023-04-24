
$(document).ready(function () {
    console.log("document loaded");

    var consultants = getConsultantValue();

    for (var i = 0; i < 12; i++) {
        //calculate other fields when hours are added
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
    ///Calculate again whe the dropdown is selected
    $("#ConsultantId").change(function () {
        for (var i = 0; i < 12; i++) {
            calculate(i);
        }
    });

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
       /* console.log("month calculate entry", rowindex);*/
        var consultantId;
        var billingRate = 0;
        var payRate = 0;
        var netMargin = 0;
        if ($("#ConsultantId").val() == 'Please Select') {
            $("#ConsultantId").focus();
            alert("Please select consultant from dropdown.");
           
        } else {
            consultantId = $("#ConsultantId").val();
            $.each(consultants, (index, consultant) => {
                if (consultant.Id == consultantId) {
                    billingRate = consultant.BillingRate;
                    payRate = consultant.PayRate;
                    netMargin = consultant.NetMargin;
                }

            });
        }


        var monthHours = $("#MonthData_" + rowindex + "__Hours").val();
        if (monthHours == 0) return; 
        var invoiceAmount = billingRate * monthHours;
        var consultantPay = payRate * monthHours;
        var netProfit = netMargin * monthHours;

        $("#MonthData_" + rowindex + "__InvoiceAmount").val(invoiceAmount);
        $("#MonthData_" + rowindex + "__ConsultantPay").val(consultantPay);
        $("#MonthData_" + rowindex + "__NetProfit").val(netProfit);
        console.log("Calculation Complete");
    }


});

