var donutChart;
$(document).ready(function () {
    donutChart = c3.generate({
        bindto: '#chart',
        data: {
            url: 'http://localhost:57087/Api/PieChart',
            mimeType: 'json',
            type: 'donut',
            onclick: function (d, i) { console.log("onclick", d, i); },
            onmouseover: function (d, i) { console.log("onmouseover", d, i); },
            onmouseout: function (d, i) { console.log("onmouseout", d, i); }
        },
        donut: {
            title: ""
        }
    });
});
