
async function getStockData(stockName) {
    let response = await fetch(`/api/stockdata/${stockName}`);
    let data = await response.json();
    return data
}



export {
    getStockData as GetStockData
}