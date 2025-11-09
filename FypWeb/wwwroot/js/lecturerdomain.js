var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/lecturer/domain/getall' },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "program", "width": "30%" },
            { "data": "domain", "width": "10%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Lecturer/Domain/Edit/${data}" class="btn btn-secondary text-white" style="cursor:pointer;">
                                    <i class="bi bi-pencil-square"></i> Assign domain
                                </a>
                            </div>`;
                },
                "width": "10%"
            }
        ]
    });
}




