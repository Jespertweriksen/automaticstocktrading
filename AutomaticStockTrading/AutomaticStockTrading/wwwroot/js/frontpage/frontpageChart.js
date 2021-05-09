import { GetFrontpageStocks } from "../store.js"
let currentStockName = document.getElementById('frontpageStock')
let ctx = document.getElementById('frontpageChart');
let ctxBar = document.getElementById('frontpageBarChart')



const myIterator = (alist, glist, mlist, nlist, naslist, tlist) => {
    let datetime = []
    
    let appleClose = []
    let appleVolume = [] 
    
    let googleClose = []
    let googleVolume = []
    
    let microsoftClose = []
    let microsoftVolume = []
    
    let nasdaqClose = []
    let nasdaqVolume = []

    let netflixClose = []
    let netflixVolume = []

    let twitterClose = []
    let twitterVolume = []
    
    
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

    nlist.forEach(function (item) {
        netflixClose.push(item.close);
        netflixVolume.push(item.volume);
    });

    naslist.forEach(function (item) {
        nasdaqClose.push(item.close);
        nasdaqVolume.push(item.volume);
    });

    tlist.forEach(function (item) {
        twitterClose.push(item.close);
        twitterVolume.push(item.volume);
    });

    // We reverse our arrays 
    datetime = datetime.reverse();
    appleClose = appleClose.reverse();
    googleClose = googleClose.reverse();
    microsoftClose = microsoftClose.reverse();
    netflixClose = netflixClose.reverse()
    nasdaqClose = nasdaqClose.reverse()
    twitterClose = twitterClose.reverse()
    
    appleVolume = appleVolume.reverse();
    googleVolume = googleVolume.reverse();
    microsoftVolume = microsoftVolume.reverse();
    netflixVolume = netflixVolume.reverse()
    nasdaqVolume = nasdaqVolume.reverse()
    twitterVolume = twitterVolume.reverse()
    return [datetime, appleClose, googleClose, microsoftClose, netflixClose, nasdaqClose, twitterClose, 
        appleVolume, googleVolume, microsoftVolume, netflixVolume, nasdaqVolume, twitterVolume]
}


async function currentChart() {
    let appleStock = "Apple"
    let googleStock = "Google"
    let microsoftStock = "Microsoft"
    let nasdaqStock = "NASDAQ";
    let netflixStock = "Netflix Inc";
    let twitterStock = "Twitter Inc";
    const appleSequences = await GetFrontpageStocks(appleStock);
    const googleSequences = await GetFrontpageStocks(googleStock);
    const microsoftSequences = await GetFrontpageStocks(microsoftStock);
    const nasdaqSequences = await GetFrontpageStocks(nasdaqStock);
    const netflixSequences = await GetFrontpageStocks(netflixStock);
    const twitterSequences = await GetFrontpageStocks(twitterStock);
    let [datetime, appleClose, googleClose, microsoftClose, netflixClose, nasdaqClose, twitterClose,
        appleVolume, googleVolume, microsoftVolume, netflixVolume, nasdaqVolume, twitterVolume] = myIterator(appleSequences, googleSequences, microsoftSequences, netflixSequences, nasdaqSequences, twitterSequences) //myIterator(sequences);

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

    let netflix_seq = {
        label: 'Netflix',
        data: netflixClose,
        backgroundColor: "orange",
        borderColor: "orange",
        borderWidth: 1
    }

    let nasdaq_seq = {
        label: 'NASDAQ',
        data: nasdaqClose,
        backgroundColor: "black",
        borderColor: "black",
        borderWidth: 1
    }

    let twitter_seq = {
        label: 'Twitter',
        data: twitterClose,
        backgroundColor: "yellow",
        borderColor: "yellow",
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

    let netflix_vol = {
        label: 'Netflix',
        data: netflixVolume,
        backgroundColor: "orange",
        borderColor: "orange",
        borderWidth: 1
    }

    let nasdaq_vol = {
        label: 'NASDAQ',
        data: nasdaqVolume,
        backgroundColor: "black",
        borderColor: "black",
        borderWidth: 1
    }

    let twitter_vol = {
        label: 'Twitter',
        data: twitterVolume,
        backgroundColor: "yellow",
        borderColor: "yellow",
        borderWidth: 1
    }
        
    renderChart(datetime, apple_seq, google_seq, microsoft_seq, netflix_seq, nasdaq_seq, twitter_seq, 
        apple_vol, google_vol, microsoft_vol, netflix_vol, nasdaq_vol, twitter_vol)
}

currentChart();


const renderChart = (datetime, apple_sequence, google_sequence, microsoft_sequence, netflix_sequence, nasdaq_sequence, twitter_sequence,
                     apple_volume, google_volume, microsoft_volume, netflix_volume, nasdaq_volume, twitter_volume) => {
    let myChart = new Chart(ctx, {
        type: 'line',

        data: {
            labels: datetime,
            datasets: [apple_sequence, google_sequence, microsoft_sequence, netflix_sequence, nasdaq_sequence, twitter_sequence]
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
            datasets: [apple_volume, google_volume, microsoft_volume, netflix_volume, nasdaq_volume, twitter_volume]
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
