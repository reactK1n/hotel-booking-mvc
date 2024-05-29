
var ctx = document.getElementById('pieChart').getContext('2d');
var pieChart = new Chart(ctx, {
    type: 'pie',
    data: {
        labels: ['Lagos', 'Abuja'],
        datasets: [{
            label: 'Location',
            data: [86, 14],
            backgroundColor: [
                '#2067A1',
                '#FFBB33'
            ],
        }]
    },
    options: {
        maintainAspectRatio: false,
        tooltips: {
            backgroundColor: "rgb(255,255,255)",
            bodyFontColor: "#858796",
            borderColor: '#dddfeb',
            borderWidth: 1,
            xPadding: 15,
            yPadding: 15,
            displayColors: false,
            caretPadding: 10,
            offset: 20
            
        },
        legend: {
            display: false
        },
    }   
});
