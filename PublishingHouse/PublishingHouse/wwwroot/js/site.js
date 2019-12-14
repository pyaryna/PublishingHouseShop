function confirmDelete(uniqueId, isDeleteClicked) {
    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}

function chooseDeliver(value) {
    if (value == "доставка") {
        $('#' + 'deliverAddress').show();
    }
    else {
        $('#' + 'deliverAddress').hide();
    }
}

function chooseAmount(price, amount) {
    $('#' + 'deliverAddress').text = price * amount;
}

function calculate(id, x, y) {
    var sum = 'sum' + id;
    $('#' + sum).value = x * y;
}