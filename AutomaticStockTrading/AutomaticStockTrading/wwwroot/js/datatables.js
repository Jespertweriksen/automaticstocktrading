// Importing jQuery in ES6 style
//import $ from "jquery"; //lkj: no need to import here

// We need to expose jQuery as global variable
//window.jQuery = window.$ = $; //lkj: default behavior

// ES6 import does not work it throws error: Missing jQuery 
// using Node.js style import works without problems
//require('bootstrap'); //lkj: no need to import here

//import { DataTable } from "simple-datatables"
const dataTable = new DataTable("#table", {
    searchable: false,
    fixedheight: false,
    perPageSelect: false
});



document.getElementById('perPage5').addEventListener('click', function (e) {
    dataTable.options.perPage = 5;
    dataTable.refresh();
});
document.getElementById('perPage10').addEventListener('click', function (e) {
    dataTable.options.perPage = 10;
    dataTable.refresh();
});
document.getElementById('perPage15').addEventListener('click', function (e) {
    dataTable.options.perPage = 15;
    dataTable.refresh();
});
document.getElementById('perPage20').addEventListener('click', function (e) {
    dataTable.options.perPage = 20;
    dataTable.refresh();
});
document.getElementById('perPage25').addEventListener('click', function (e) {
    dataTable.options.perPage = 25;
    dataTable.refresh();
});


document.getElementById('exampleInputIconLeft').addEventListener('keyup', function (e) {
    var value = document.getElementById('exampleInputIconLeft').value;
    dataTable.search(value);
});

