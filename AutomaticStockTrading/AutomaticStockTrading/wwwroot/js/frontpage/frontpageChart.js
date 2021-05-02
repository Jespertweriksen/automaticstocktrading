import { GetFrontpageStocks } from "../store.js"
let currentStockName = document.getElementById('frontpageStock')
let ctx = document.getElementById('frontpageChart');
let ctxBar = document.getElementById('frontpageBarChart')



const myIterator = (alist, glist, mlist) => {
    let datetime = []
    
    let appleClose = []
    let appleVolume = [] 
    
    let googleClose = []
    let googleVolume = []
    
    let microsoftClose = []
    let microsoftVolume = []
    
    
    alist.forEach(function (item) {
        datetime.push(item.datetime)
        appleClose.push(item.close);
        appleVolume.push(item.volume);
    });

    glist.forEach(function (item) {
        googleClose.push(item.close);
        googleVolume.push(item.volume);
    });

    mlist.forEach(function (item) {
        microsoftClose.push(item.close);
        microsoftVolume.push(item.volume);
    });

    // We reverse our arrays 
    datetime = datetime.reverse();
    appleClose = appleClose.reverse();
    googleClose = googleClose.reverse();
    microsoftClose = microsoftClose.reverse();
    
    appleVolume = appleVolume.reverse();
    googleVolume = googleVolume.reverse();
    microsoftVolume = microsoftVolume.reverse();
    return [datetime, appleClose, googleClose, microsoftClose, appleVolume, googleVolume, microsoftVolume]
}


async function currentChart() {
    let appleStock = "apple"//currentStockName.innerHTML;
    let googleStock = "google"
    let microsoftStock = "microsoft"
    const appleSequences = await GetFrontpageStocks(appleStock); //await GetFrontpageStocks(currentName);
    const googleSequences = await GetFrontpageStocks(googleStock);
    const microsoftSequences = await GetFrontpageStocks(microsoftStock);
    let [datetime, appleClose, googleClose, microsoftClose, appleVolume, googleVolume, microsoftVolume] = myIterator(appleSequences, googleSequences, microsoftSequences) //myIterator(sequences);

    let apple_seq = {
        label: 'Apple',
        data: appleClose,
        backgroundColor: "blue",
        borderColor: "blue",
        borderWidth: 1
    }

    let google_seq = {
        label: 'Google',
        data: googleClose,
        backgroundColor: "green",
        borderColor: "green",
        borderWidth: 1
    }

    let microsoft_seq = {
        label: 'Microsoft',
        data: microsoftClose,
        backgroundColor: "red",
        borderColor: "red",
        borderWidth: 1
    }
    
    let apple_vol = {
        label: 'Apple',
        data: appleVolume,
        backgroundColor: "blue",
        borderColor: "blue",
        borderWidth: 1
    }

    let google_vol = {
        label: 'Google',
        data: googleVolume,
        backgroundColor: "green",
        borderColor: "green",
        borderWidth: 1
    }

    let microsoft_vol = {
        label: 'Microsoft',
        data: microsoftVolume,
        backgroundColor: "red",
        borderColor: "red",
        borderWidth: 1
    }
        
    renderChart(datetime, apple_seq, google_seq, microsoft_seq, apple_vol, google_vol, microsoft_vol)
}

currentChart();


const renderChart = (datetime, apple_sequence, google_sequence, microsoft_sequence, apple_volume, google_volume, microsoft_volume) => {
    let myChart = new Chart(ctx, {
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

    let myBar = new Chart(ctxBar, {
        type: 'bar',
        data: {
            labels: datetime,
            datasets: [apple_volume, google_volume, microsoft_volume]
        },
        options: {

            plugins: {
                title: {
                    display: true,
                    text: 'Antallet af handlede aktier',
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
