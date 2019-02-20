$(function () {
    //On membership-level select field change
    $("#membership-level").on("change", function () {

        //Get the value of the select field
        let level = $("#membership-level").val();
        let price = 0.00;

        //Determine price according to membership-level
        switch (level) {
            case "1":
                price = 45.00;
                break;
            case "2":
                price = 75.00;
                break;
            case "3":
                price = 105.00;
                break;
            default:
                break;
        }

        //Set the price field value
        $("#price").attr("value", "$"+price);
    });
});