import {GetPortfolioStocks} from "../store.js"
var getUserID = document.getElementById('userid');
console.log(getUserID);
var ctx = document.getElementById('portfolioPie');

var pieColors = [];
var dynamicColors = function() {
    var r = Math.floor(Math.random() * 255);
    var g = Math.floor(Math.random() * 255);
    var b = Math.floor(Math.random() * 255);
    return "rgb(" + r + "," + g + "," + b + ")";
};

const myIterator = (alist) => {
    let name = []
    let amount = []

    alist.forEach(function (item) {
        name.push(item.name)
        amount.push(item.amount);
    });
    
    return [name, amount]
}

async function updateChart() {
    var currentName = getUserID.innerHTML;
    const sequences = await GetPortfolioStocks(currentName);
    var [name, amount] = myIterator(sequences);
    
    for (var i in amount) {
        pieColors.push(dynamicColors());
    }

    var name_seq = {
        label: "Stock",
        data: name,
        backgroundColor: "red",
        borderColor: "red",
        borderWidth: 1
    }

    var amount_seq = {
        label: "Amount",
        data: amount,
        backgroundColor: pieColors,
        borderColor: "black",
        borderWidth: 2
    }
    console.log(amount_seq)
    console.log(name_seq)
    console.log(name)
    
    renderChart(name_seq, amount_seq)
}

updateChart();



const renderChart = (name_seq, amount_seq) => {
    console.log("kekw")
    console.log(name_seq.data);
    
    var myChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: name_seq.data, 
            datasets: [amount_seq]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                },
                title:{
                    display: true,
                    text: "Din Beholdning"
                }
            }
        }
    });
}
