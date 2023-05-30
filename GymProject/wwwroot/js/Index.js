$("#buttonIncrease").on("click", () => {
    $("#itemQuantity").value((_, oldVal) => {
        return oldVal + 1;
    })
})

$("#buttonDecrease").on("click", () => {
    $("#itemQuantity").value((_, oldVal) => {
        return oldVal - 1;
    })
})