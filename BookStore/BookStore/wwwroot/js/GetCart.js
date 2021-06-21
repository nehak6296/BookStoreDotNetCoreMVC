
function increment() {
    document.getElementById('demoInput').stepUp();
}
function decrement() {
    document.getElementById('demoInput').stepDown();
}
function Remove_Cart(CartId) {
    var removeFromCart = "remove-".concat(CartId);
    var requestObject = {};
    requestObject.cartId = CartId;

    $.ajax({
        type: "POST",
        url: 'https://localhost:44309/Cart/RemoveFromCart',
        data: JSON.stringify(requestObject.cartId),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success:
            function () {
                //Onclick REMOVE button hide AddToCart button
                var RemoveButton = document.getElementById('placeid');
                RemoveButton.style.display = "none";
                window.location.reload();
            },
        error: function () {
            alert("Error while REMOVING data");
        }
    });
}
var customerList;
function getCustomers() {
    var customers = {};
    var userId = 1;
    //int userId = ;
    //console.log(JSON.stringify(customers));
    $.ajax({
        type: "GET",
        url: 'https://localhost:44309/Customer/GetAllCustomerDetails?UserId=' + userId,
        //  data: userId,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            console.log("response=" + response);
            customerList = response.Data;
            //continue_order()
        },
        error: function () {
            alert("Error while inserting data");
        }
    });
}
function place_order() {
    getCustomers();
    var place_order = document.getElementById('placeid');
    place_order.style.display = "none";

    var form_name = document.getElementById('form-div-cart');
    form_name.style.display = "block";
}