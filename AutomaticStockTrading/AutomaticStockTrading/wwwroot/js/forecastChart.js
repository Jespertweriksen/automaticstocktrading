import { GetForecastData, GetLastDateOfLog } from "./store.js"


var currentStockName = document.getElementById('currentStock')
var ctx = document.getElementById('forecast_Chart');

async function updateForecastChart() {
    var currentStock = currentStockName.innerHTML;
    const data = await GetForecastData(currentStock);
    const lastDateLogging = await GetLastDateOfLog(currentStock);
    var startDate = lastDateLogging;
    var dateSeries = createFutureDates(startDate);

    var closeSeries = []
    data.forEach(function (item) {
        closeSeries.push(item.close)
    })
    console.log(closeSeries)
    console.log(dateSeries)

    renderForecastChart(dateSeries, closeSeries);
    
}

function createFutureDates(day) {
    var today = new Date(day);
    var thirtyFromToday = new Date();
    thirtyFromToday.setDate(thirtyFromToday.getDate() + 26);

   
    var sequenceDate = getDateSequence(today, thirtyFromToday)
    return sequenceDate;
}

function getDateSequence(startDate, endDate) {
    var dates = [],
        currentDate = startDate,
        addDays = function (days) {
            var date = new Date(this.valueOf());
            date.setDate(date.getDate() + days);
            return date;
        };
    while (currentDate <= endDate) {
        dates.push(dateFormat(currentDate));
        currentDate = addDays.call(currentDate, 1);
    }
    dates.shift();
    return dates;
}

function dateFormat(dateObject) {
    var containerDate = dateObject;
    var dd = String(containerDate.getDate()).padStart(2, '0');
    var mm = String(containerDate.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = containerDate.getFullYear();
    var containerDate = yyyy + '-' + mm + '-' + dd;
    return containerDate
}

const renderForecastChart = (date_sequence, close_sequence) => {
    var myChart = new Chart(ctx, {
        type: 'line',
        data: {
            labels: date_sequence,
            datasets: [{
                label: 'Forecast close værdi',
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
                    from: 1.2,
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
                    text: 'Forecast',
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

updateForecastChart()

