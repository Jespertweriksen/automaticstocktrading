import {GetPortfolioStocks} from "../store.js"
let getUserID = document.getElementById('userid');
console.log(getUserID);
let ctx = document.getElementById('portfolioPie');

let pieColors = [];
let dynamicColors = function() {
    let r = Math.floor(Math.random() * 255);
    let g = Math.floor(Math.random() * 255);
    let b = Math.floor(Math.random() * 255);
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
    let currentName = getUserID.innerHTML;
    const sequences = await GetPortfolioStocks(currentName);
    let [name, amount] = myIterator(sequences);
    
    for (let i in amount) {
        pieColors.push(dynamicColors());
    }

    let name_seq = {
        label: "Stock",
        data: name,
        backgroundColor: "red",
        borderColor: "red",
        borderWidth: 1
    }

    let amount_seq = {
        label: "Amount",
        data: amount,
        backgroundColor: pieColors,
        borderColor: "black",
        borderWidth: 2
    }
    const unique = (value, index, self) => {
        return self.indexOf(value) === index
    }
    
    const u = name_seq.data.filter(unique);
    
    console.log(u)
    console.log(amount_seq)
    renderChart(name_seq, amount_seq, u)
}

updateChart();



const renderChart = (name_seq, amount_seq, u ) => {
    let myChart = new Chart(ctx, {
        type: 'doughnut',
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
