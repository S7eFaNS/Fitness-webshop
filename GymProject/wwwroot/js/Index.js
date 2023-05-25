function decreaseQuantity() {
    var quantityElement = document.getElementById("itemQuantity");
    var currentQuantity = parseInt(quantityElement.innerText);

    if (currentQuantity > 1) {
        currentQuantity--;
        quantityElement.innerText = currentQuantity;
        var totalPriceOfItems = document.getElementById("ItemPrice");
        var pricePerItem = document.getElementById("PricePerItem");

        var priceOfItems = parseInt(totalPriceOfItems.innerText)
        priceOfItems = currentQuantity * pricePerItem;
        totalPriceOfItems.innerText = priceOfItems;
    } else {
        var itemContainer = document.getElementById("itemContainer");
        itemContainer.remove();
    }
}

function increaseQuantity() {
    var quantityElement = event.target.parentNode.querySelector("#itemQuantity");
    var currentQuantity = parseInt(quantityElement.innerText);

    if (currentQuantity < 99) {
        currentQuantity++;
        quantityElement.innerText = currentQuantity;

        var totalPriceOfItems = event.target.parentNode.parentNode.querySelector("#ItemPrice");
        var pricePerItem = event.target.parentNode.parentNode.querySelector("#PricePerItem");

        var priceOfItems = parseFloat(totalPriceOfItems.innerText.replace(/[^0-9.-]+/g, ""));
        var pricePerItemValue = parseFloat(pricePerItem.innerText.replace(/[^0-9.-]+/g, ""));
        priceOfItems = currentQuantity * pricePerItemValue;
        totalPriceOfItems.innerText = "$" + priceOfItems.toFixed(2);
    }
}