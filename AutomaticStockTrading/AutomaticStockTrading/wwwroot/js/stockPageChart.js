import { GetStockData } from "./store.js"

var currentStockName = document.getElementById('currentStock')
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

    // We reverse our arrays 
    datetime = datetime.reverse();
    open = open.reverse();
    close = close.reverse();
    volume = volume.reverse();
    high = high.reverse();
    low = low.reverse();
    return [datetime, open, close, volume, high, low]
}

async function updateChart() {
    var currentName = currentStockName.innerHTML;
    const sequences = await GetStockData(currentName);
    console.log(sequences)
    var [datetime, open, close, volume, high, low] = myIterator(sequences);

    var open_seq = {
        label: 'open',
        data: open,
        backgroundColor: "red",
        borderColor: "red",
        borderWidth: 1
    }

    var close_seq = {
        label: 'close',
        data: close,
        backgroundColor: "blue",
        borderColor: "blue",
        borderWidth: 1
    }

    var high_seq = {
        label: 'high',
        data: high,
        backgroundColor: "green",
        borderColor: "green",
        borderWidth: 1
    }

    var low_seq = {
        label: 'low',
        data: low,
        backgroundColor: "yellow",
        borderColor: "yellow",
        borderWidth: 1
    }

    console.log(datetime)
    renderChart(datetime, open_seq, close_seq, high_seq, low_seq)
    
}



updateChart();


const renderChart = (date_sequence, open_sequence, close_sequence, high_sequence, low_sequence) => {
    var myChart = new Chart(ctx, {
        type: 'line',
        
        data: {
            labels: date_sequence,
            datasets: [open_sequence, close_sequence, high_sequence, low_sequence]
        },
        options: {
            plugins: {
                title: {
                    display: true,
                    text: 'Historisk data for aktie',
                    font: {
                        size: 25,
                        weight: 'bold'
                    },
                    align: "start",
                }
            },
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
}



console.log("hej")