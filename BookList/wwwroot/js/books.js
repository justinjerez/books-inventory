var dataTable;

$(document).ready(() => {
    loadDataTable();
});

const loadDataTable = () => {
    dataTable = $('#dt_load').DataTable({
        "ajax": {
            "url": "/api/books",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "author", "width": "15%" },
            { "data": "description", "width": "40%" },
            { "data": "isbn", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="text-center">
                            <a href="/Books/Edit?id=${data}" class="btn btn-success text-white">Edit</a>
                            &nbsp;
                            <a class="btn btn-danger text-white">Delete</a>
                        </div>
                    `
                },
                "width": "15%"
            }
        ],
        "language": {
            "emptyTable": "No data found."
        },
        "width": "100%"
    });
}