
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
function place_order() {
    var place_order = document.getElementById('placeid');
    place_order.style.display = "none";

    var form_name = document.getElementById('form-div-cart');
    form_name.style.display = "block";
}

function Checkout() {
    var requestObject = {};
    requestObject.CartId = 38;
    requestObject.UserId = 1;
    $.ajax({
        type: "POST",
        url: 'https://localhost:44309/Orders/Checkout',
        data: JSON.stringify(requestObject),
       // dataType: "json",
        contentType: "application/json",
        success: function (data) {
            $("body").html(data);
        },
        error: function () {
            alert("Error ");
        }
    });
}