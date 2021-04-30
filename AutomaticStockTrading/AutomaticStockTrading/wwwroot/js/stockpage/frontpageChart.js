import { GetFrontpageStocks } from "../store.js"
var currentStockName = document.getElementById('frontpageStock')
var ctx = document.getElementById('frontpageChart');



const myIterator = (alist, glist, mlist) => {
    let datetime = []
    let appleClose = []
    let googleClose = []
    let microsoftClose = []
    
    alist.forEach(function (item) {
        datetime.push(item.datetime)
        appleClose.push(item.close);
    });

    glist.forEach(function (item) {
        googleClose.push(item.close);
    });

    mlist.forEach(function (item) {
        microsoftClose.push(item.close);
    });

    // We reverse our arrays 
    datetime = datetime.reverse();
    appleClose = appleClose.reverse();
    googleClose = googleClose.reverse();
    microsoftClose = microsoftClose.reverse();
    return [datetime, appleClose, googleClose, microsoftClose]
}


async function currentChart() {
    var appleStock = "apple"//currentStockName.innerHTML;
    var googleStock = "google"
    var microsoftStock = "microsoft"
    const appleSequences = await GetFrontpageStocks(appleStock); //await GetFrontpageStocks(currentName);
    const googleSequences = await GetFrontpageStocks(googleStock);
    const microsoftSequences = await GetFrontpageStocks(microsoftStock);
    var [datetime, appleClose, googleClose, microsoftClose] = myIterator(appleSequences, googleSequences, microsoftSequences) //myIterator(sequences);
    
    var apple_seq = {
        label: 'Apple',
        data: appleClose,
        backgroundColor: "blue",
        borderColor: "blue",
        borderWidth: 1
    }

    var google_seq = {
        label: 'Google',
        data: googleClose,
        backgroundColor: "green",
        borderColor: "green",
        borderWidth: 1
    }

    var microsoft_seq = {
        label: 'Microsoft',
        data: microsoftClose,
        backgroundColor: "yellow",
        borderColor: "yellow",
        borderWidth: 1
    }
    
    renderChart(datetime, apple_seq, google_seq, microsoft_seq)
}
/*
async function googleChart() {
    var googleStock = "google";
    const sequences = await GetFrontpageStocks(googleStock);
    var [datetime, close] = myGoogleIterator(sequences);

    
    renderChart(datetime, google_seq)
}*/

currentChart();
//googleChart();


const renderChart = (datetime, apple_sequence, google_sequence, microsoft_sequence) => {
    var myChart = new Chart(ctx, {
        type: 'line',

        data: {
            labels: datetime,
            datasets: [apple_sequence, google_sequence, microsoft_sequence]
        },
        options: {

            plugins: {
                title: {
                    display: true,
                    text: 'Klik på den aktie du vil have vist',
                    font: {
                        size: 25,
                        weight: 'bold',
                    },
                    align: "middle",
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
