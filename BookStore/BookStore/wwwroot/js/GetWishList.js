function Remove_WishList(WishListId) {
    var removeFromCart = "remove-".concat(WishListId);
    var requestObject = {};
    requestObject.WishListId = WishListId;

    $.ajax({
        type: "POST",
        url: 'https://localhost:44309/WishList/RemoveFromWishList',
        data: JSON.stringify(requestObject.WishListId),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            console.log("REMOVED from WishList");
            window.location.reload();
        },

        error: function () {
            alert("Error while REMOVING data");
        }
    });
}
