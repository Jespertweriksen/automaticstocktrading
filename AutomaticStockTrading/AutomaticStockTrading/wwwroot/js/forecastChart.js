import { GetForecastData, GetLastDateOfLog } from "./store.js"


var currentStockName = document.getElementById('currentStock')

async function updateForecastChart() {
    var currentStock = currentStockName.innerHTML;
    const data = await GetForecastData(currentStock);
    const lastDateLogging = await GetLastDateOfLog(currentStock);
    var startDate = lastDateLogging;
    var dateSeries = createFutureDates(startDate);

    renderForecastChart();
    
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

const renderForecastChart = () => {
    
}
updateForecastChart()

