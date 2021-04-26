import { GetForecastData } from "./store.js"


var currentStockName = document.getElementById('currentStock')

async function updateForecastChart() {
    var currentStock = currentStockName.innerHTML;
    const data = await GetForecastData(currentStock);
    createFutureDates(1);
    renderForecastChart();
    console.log(data);
}

function createFutureDates(day) {
    var today = new Date();
    var dd = String(today.getDate() + day).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = yyyy + '-' + mm + '-' + dd;
    return today
}

function generateArray(inputData) {
    dateList = [];
    closeList = [];



    inputData.forEach(function (item){
        closeList.Push(item.close);

    })
}

const renderForecastChart = () => {
    
}
updateForecastChart()

