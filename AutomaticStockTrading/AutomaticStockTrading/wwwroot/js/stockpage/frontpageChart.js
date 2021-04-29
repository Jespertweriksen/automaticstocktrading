import { GetFrontpageStocks } from "../store.js"
var currentStockName = document.getElementById('frontpageStock')
var ctx = document.getElementById('frontpageChart');



const myIterator = (alist) => {
    let datetime = []
    let close = []

    alist.forEach(function (item) {
        datetime.push(item.datetime)
        close.push(item.close);
    });

    // We reverse our arrays 
    datetime = datetime.reverse();
    close = close.reverse();
    return [datetime, close]
}


async function currentChart() {
    var currentName = currentStockName.innerHTML;
    const sequences = await GetFrontpageStocks(currentName);
    var [datetime, close] = myIterator(sequences);
    
    var current_seq = {
        label: currentName,
        data: close,
        backgroundColor: "blue",
        borderColor: "blue",
        borderWidth: 1
    }
    renderChart(datetime, current_seq)
}
/*
const myGoogleIterator = (alist) => {
    let datetime = []
    let close = []

    alist.forEach(function (item) {
        datetime.push(item.datetime)
        close.push(item.close);
    });

    // We reverse our arrays 
    datetime = datetime.reverse();
    close = close.reverse();
    return [datetime, close]
}

async function googleChart() {
    var googleStock = "google";
    const sequences = await GetFrontpageStocks(googleStock);
    var [datetime, close] = myGoogleIterator(sequences);

    var google_seq = {
        label: 'close',
        data: close,
        backgroundColor: "green",
        borderColor: "green",
        borderWidth: 1
    }
    renderChart(datetime, google_seq)
}*/

currentChart();
//googleChart();


const renderChart = (date_sequence, current_seq) => {
    var myChart = new Chart(ctx, {
        type: 'line',

        data: {
            labels: date_sequence,
            datasets: [current_seq]
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
            },

        }
    });
}
