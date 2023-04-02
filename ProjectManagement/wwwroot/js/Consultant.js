

var billingrate = document.getElementById("BillingRate");
var payRate = document.getElementById("PayRate");
var teamLeadFee = document.getElementById("TeamLeadFee");
var marketingFee = document.getElementById("MarketingFee");
var referralFees = document.getElementById("ReferralFees");
var placementFee = document.getElementById("PlacementFee");
var creditCardCost = document.getElementById("CreditCardCost");



billingrate.addEventListener("blur", function () {
    calculateNetMargin();
    
});

payRate.addEventListener("blur", function () {
    calculateNetMargin();
});

teamLeadFee.addEventListener("blur", function () {
    calculateNetMargin();
});

marketingFee.addEventListener("blur", function () {
    calculateNetMargin();
});

referralFees.addEventListener("blur", function () {
    calculateNetMargin();
});

placementFee.addEventListener("blur", function () {
    calculateNetMargin();
});

creditCardCost.addEventListener("blur", function () {
    calculateNetMargin();
});

function calculateNetMargin() {
    
    var netMargin = document.getElementById("NetMargin");
    let teamLeadFeeValue = isNumeric(teamLeadFee.value) ? parseFloat(teamLeadFee.value) : 0;
    let marketingFeeValue = isNumeric(marketingFee.value) ? parseFloat(marketingFee.value) : 0;
    let referralFeesValue = isNumeric(referralFees.value) ? parseFloat(referralFees.value) : 0;
    let placementFeeValue = isNumeric(placementFee.value) ? parseFloat(placementFee.value) : 0;
    let creditCardCostValue = isNumeric(creditCardCost.value) ? parseFloat(creditCardCost.value) : 0;

    netMargin.value = billingrate.value - (teamLeadFeeValue + marketingFeeValue + referralFeesValue + placementFeeValue + creditCardCostValue);
    return
}

function isNumeric(str) {
    if (typeof str != "string") return false // we only process strings!  
    return !isNaN(str) && // use type coercion to parse the _entirety_ of the string (`parseFloat` alone does not do this)...
        !isNaN(parseFloat(str)) // ...and ensure strings of whitespace fail
}