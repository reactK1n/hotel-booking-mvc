
var months = document.currentScript.getAttribute('months');
var revenues = document.currentScript.getAttribute('revenues');

let date = new Date();
let currentMonth = date.getMonth();

var ctx_line = document.getElementById("myLineChart").getContext("2d");
var transactionChart = new Chart(ctx_line, {
	type: 'line',
	data: {
		labels: RearrangeMonths(months, currentMonth),
		datasets: [{
			data: RearrangeMonths(revenues, currentMonth),
			backgroundColor: [
				'#FFBB33',
			],
			borderColor: [
				'#2067A1',
			],
			borderWidth: 1,
			fill: true
		}]
	},
	options: {
		scale: {
			y: {
				beginAtZero: true
			}
		},
		legend: {
			display: false
		},
		plugins: {
			title: {
				display: true
			},
		}
	}
});