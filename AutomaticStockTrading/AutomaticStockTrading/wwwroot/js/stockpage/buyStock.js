import { PostOrder} from "../store.js"

var currentAmount = document.getElementById("currentBuyingAmount");
var incrementButton = document.getElementById("increment");
var decreaseButton = document.getElementById("decrease");
var buyButton = document.getElementById("buyStock");

var selectedBuyAmount = 0;

var count = 0;

currentAmount.innerHTML = count;

function incrementAmount() {  
    count++;
    console.log(count)

    // testing

    updateTotalBuyingAmount();
}

function decreaseAmount() {
    if (count > 0) {
        count--;
        console.log(count);
    }
    updateTotalBuyingAmount();
}

function updateDisplay() {
    currentAmount.innerHTML = count;
}

function updateTotalBuyingAmount() {

    var currentPrice = document.getElementById("currentPrice").textContent;
    currentPrice = currentPrice.trim();
    currentPrice = currentPrice.replace("$", "");
    currentPrice = parseFloat(currentPrice);

    var selectedAmount = count;
    
    var totalPrice = (selectedAmount * currentPrice);
    console.log(totalPrice)

    var totalAmount = document.getElementById("totalPrice");

    selectedBuyAmount = totalPrice;
    console.log("hi" + selectedBuyAmount)

    // set global variable to totalamount for buy function

    totalAmount.innerHTML = totalPrice.toFixed(2);
}

const buy = () => {
    console.log(selectedBuyAmount)
    var userId = sessionStorage.getItem("")
    var orderAmount = selectedBuyAmount;
    var stockName = document.getElementById("currentStock").innerHTML;

    var currentPrice = document.getElementById("currentPrice").textContent;
    currentPrice = currentPrice.trim();
    currentPrice = currentPrice.replace("$", "");
    currentPrice = parseFloat(currentPrice);

    console.log(currentPrice, orderAmount, stockName)

    

    if (confirm(`Bekræft køb: ${orderAmount} $`)) {
        // POST METODE FRA STORE
        PostOrder({ amount: count, name: stockName, price: currentPrice }).
            then(data => { console.log(data) })
        alert("Du har nu købt aktien")
    } else {
        alert("Du har aflyst handlen")
    }
}

buyButton.onclick = () => {
    buy()
}

decreaseButton.onclick = () => {
    decreaseAmount();
    updateDisplay();
}

incrementButton.onclick = () => {
    incrementAmount();
    updateDisplay();
}
