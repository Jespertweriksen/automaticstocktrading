import {GetPortfolioStocks} from "../store.js"
var getUserID = document.getElementById('userid');
console.log(getUserID);
var ctx = document.getElementById('portfolioPie');

var pieColors = [];
var dynamicColors = function( i, total) {
    var r = 100+i* 155/total;
    var g = i* 255/total;
    var b = i* 255/total;
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
    console.log(currentName);
    const sequences = await GetPortfolioStocks(currentName);
    var [name, amount] = myIterator(sequences);
    
    for (var i in amount) {
        pieColors.push(dynamicColors(i, amount.length));
    }

    var name_seq = {
        label: 'Stock Name',
        data: name,
        backgroundColor: "red",
        borderColor: "red",
        borderWidth: 1
    }

    var amount_seq = {
        label: 'Amount',
        data: amount,
        backgroundColor: pieColors,
        borderColor: "black",
        borderWidth: 2
    }
    renderChart(name_seq, amount_seq)
}

updateChart();


const renderChart = (name_sequence, amount_sequence) => {
    var myChart = new Chart(ctx, {
        type: 'pie',

        data: {
            labels: name_sequence, amount_sequence,
            datasets: [name_sequence, amount_sequence]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                },
            }
        }
    });
}
