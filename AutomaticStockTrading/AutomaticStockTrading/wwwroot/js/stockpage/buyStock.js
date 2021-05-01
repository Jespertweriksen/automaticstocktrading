

var currentAmount = document.getElementById("currentBuyingAmount");
var incrementButton = document.getElementById("increment");
var decreaseButton = document.getElementById("decrease");

var count = 0;

currentAmount.innerHTML = count;

function incrementAmount() {  
    count++;
    console.log(count)
}

function decreaseAmount() {
    if (count > 0) {
        count--;
        console.log(count);
    }
    
}

function updateDisplay() {
    currentAmount.innerHTML = count;
}

decreaseButton.onclick = () => {
    decreaseAmount();
    updateDisplay();
}

incrementButton.onclick = () => {
    incrementAmount();
    updateDisplay();
}
