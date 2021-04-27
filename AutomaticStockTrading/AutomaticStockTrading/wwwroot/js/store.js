
async function getStockData(stockName) {
    let response = await fetch(`/api/stockdata/${stockName}`);
    let data = await response.json();
    console.log("SUCCES: STOCKDATA LOADED")
    return data
}

async function getForecastData(stockName) {
    let response = await fetch(`/api/forecastdata/${stockName}`);
    let data = await response.json();
    console.log("SUCCES: FORECAST LOADED")
    
    return data;
}

async function getLastDateOfLog(stockName) {
    let response = await fetch(`/api/stockdata/date/${stockName}`);
    let data = await response.json();
    console.log("SUCCES: DATE LOADED");
    return data;
}

export {
    getStockData as GetStockData,
    getForecastData as GetForecastData,
    getLastDateOfLog as GetLastDateOfLog,
}