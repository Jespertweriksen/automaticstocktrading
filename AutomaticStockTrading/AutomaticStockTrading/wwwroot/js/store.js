
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

async function getPortfolioStocks(id){
    let response = await fetch(`/api/stocktypes/${id}`);
    let data = await response.json();
    console.log("SUCCES: ORDERS LOADED")
    return data;
}

async function getFrontpageStocks(stockName) {
    let response = await fetch(`/api/stockdata/${stockName}`);
    let data = await response.json();
    console.log("SUCCES: WE GOT IT");
    return data;
}

async function postOrder(data = {}) {
    const response = await fetch('/api/order/buy', {
        method: 'POST',
        cache: 'no-cache',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    })
    var jsonstring = JSON.stringify(data)
    console.log(jsonstring);
    return response;
}

export {
    getStockData as GetStockData,
    getForecastData as GetForecastData,
    getLastDateOfLog as GetLastDateOfLog,
    getPortfolioStocks as GetPortfolioStocks,
    getFrontpageStocks as GetFrontpageStocks,
    postOrder as PostOrder,
}