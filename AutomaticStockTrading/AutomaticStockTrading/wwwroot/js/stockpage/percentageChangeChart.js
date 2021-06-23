import { GetStockData } from "../store.js"

var currentStockName = document.getElementById('currentStock')
var ctx = document.getElementById('percentage_Chart');


const myiterator = (dataIn) => {
    var containerData = dataIn;

    var closeSequence = [];
    var dateSequence = [];

    containerData.forEach(function (item) {
        closeSequence.push(item.close);
        dateSequence.push(item.datetime);
    })

    return [dateSequence, closeSequence]
}


const getPercentageChange = (datain) => {
    var data = datain;
    var diffs = [];

    for (let i = 0; i < data.length -1; i++) {
        var difference = data[i + 1] - data[i];
        difference = (difference / data[i +1]) * 100
        diffs.push(difference);
    }
    console.log(diffs);
    return diffs;
}

async function updatePercChart() {
    var currentName = currentStockName.innerHTML;
    const data = await GetStockData(currentName);
   
    var iteratedData = myiterator(data);
    var dateSeq = iteratedData[0].reverse();
    dateSeq.shift();
    var closeSeq = iteratedData[1].reverse();
    

    const diffSeq = getPercentageChange(closeSeq)

    renderPercentageChart(dateSeq, diffSeq)
}


const renderPercentageChart = (date_sequence, close_sequence) => {
    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: date_sequence,
            datasets: [{
                label: 'Aktuel close procentforandring',
                data: close_sequence,
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
            animations: {
                tension: {
                    duration: 1000,
                    easing: 'linear',
                    from: 0,
                    to: 0,
                    loop: true
                }
            },
            scales: {
                y: {
                    beginAtZero: false
                }
            },
            plugins: {
                title: {
                    display: true,
                    text: 'Procentforandring imellem intevaller',
                    font: {
                        size: 25,
                        weight: 'bold',
                        family: 'Helvetica',
                    },
                    align: "start",
                }
            },
        }
    });

}

updatePercChart();