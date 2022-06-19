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
                            <a href="/Books/Upsert?id=${data}" class="btn btn-success text-white">Edit</a>
                            &nbsp;
                            <a onclick="Delete('api/books?id=' + ${data})" class="btn btn-danger text-white">Delete</a>
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

const Delete = (url) => {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not able to recover this book information.",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((res) => {
        if (res) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: (data) => {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}