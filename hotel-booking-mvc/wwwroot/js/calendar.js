const myCalendar = new TavoCalendar('#my-calendar', {
    // settings here
    date: moment(),
    selected: ['2020-03-20', '2020-03-21'],
    date_start: "2020-12-20",
    date_end: "2020-12-25",
    range_select: true,
    format: "MM-DD-YYYY"
});