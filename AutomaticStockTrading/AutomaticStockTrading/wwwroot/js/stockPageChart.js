import { GetStockData } from "./store.js"


var ctx = document.getElementById('myChart');



const myIterator = (alist) => {
    let datetime = []
    let open = []
    let close = []
    let volume = []
    let high = []
    let low = []

    alist.forEach(function (item) {
        datetime.push(item.datetime)
        open.push(item.open);
        close.push(item.close);
        volume.push(item.volume);
        high.push(item.high);
        low.push(item.low);
    });
    return [open, close, volume, high, low]
}

async function updateChart() {
    const sequences = await GetStockData("microsoft");
    console.log(sequences)
    var [datetime, open, close, volume, high, low]  = myIterator(sequences);
    console.log(open)
    renderChart(datetime, open)
    
}

updateChart();


const renderChart = (date_sequence, open_sequence) => {
    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: date_sequence,
            datasets: [{
                label: 'open',
                data: open_sequence,
                backgroundColor: [
                    'rgba(255, 99, 132, 0.2)',
                    'rgba(54, 162, 235, 0.2)',
                    'rgba(255, 206, 86, 0.2)',
                    'rgba(75, 192, 192, 0.2)',
                    'rgba(153, 102, 255, 0.2)',
                    'rgba(255, 159, 64, 0.2)'
                ],
                borderColor: [
                    'rgba(255, 99, 132, 1)',
                    'rgba(54, 162, 235, 1)',
                    'rgba(255, 206, 86, 1)',
                    'rgba(75, 192, 192, 1)',
                    'rgba(153, 102, 255, 1)',
                    'rgba(255, 159, 64, 1)'
                ],
                borderWidth: 1
            }]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}



console.log("hej")