var startYear = 2010;
var currentYear = moment().format('YYYY');
var currentMonth = moment().format('MMMM');
var years = [];
var years1 = [];
var year = document.getElementById('year');
var month = document.getElementById('month');
var endYear = document.getElementById('endYear');
var endMonth = document.getElementById('endMonth');
for (let i = startYear; i <= parseInt(currentYear); i++) {
    years.push(i);
}

years.forEach((c) => {
    var newEl = document.createElement('option');
    newEl.value = c;
    newEl.innerHTML = c;
    year.appendChild(newEl);
});

for (let i = startYear; i <= parseInt(currentYear); i++) {
    years1.push(i);
}

years1.forEach((c) => {
    var newEl = document.createElement('option');
    newEl.value = c;
    newEl.innerHTML = c;
    endYear.appendChild(newEl);
});

var start = {
    month: month.value,
    year: year.value
}
var end = {
    month: endMonth.value,
    year: endYear.value
}

const displayDate = () => {
    return {
        start: moment(start.month + " " + start.year).format(),
        end: moment(end.month + " " + end.year).format()
    }
}

const updateStart = (name, value) => {
    start[name] = value;
    displayDate();
}

const updateEnd = (name, value) => {
    end[name] = value;
    displayDate();
}

year.onchange = () => {
    updateStart("year", year.value);
}

month.onchange = (e) => {
    updateStart("month", month.value);
}

endYear.onchange = () => {
    updateEnd("year", endYear.value);
}

endMonth.onchange = () => {
    updateEnd("month", endMonth.value);
}

displayDate();