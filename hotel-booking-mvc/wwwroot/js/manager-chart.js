
    var ctx = document.getElementById('managerChart').getContext('2d');
    var managerChart = new Chart(ctx, {
        type: 'line',
        data: {
        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'],
            datasets: [{
                fill:true,
                borderColor: 'rgb(32, 103, 161)',
                data: [ 8.5, 9.3, 6.0, 8.0, 8.5, 5.0, 5.5, 7.0, 5.0, 3.0, 4.5, 3.5],

                borderWidth: 3
            }]
        },
        options: {
            backgroundColor: 'rgba(32, 103, 161, 0.1)',
            elements: {
                point: {
                    radius: 0
                }
            },
            scales: {
                y: {
                    beginAtZero: true
                }
            },
            legend: {
                display: true
            },
        }
    });

