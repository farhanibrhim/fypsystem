var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/lecturer/getall' },
        "columns": [
            { "data": "name", "width": "20%" },
            {
                "data": "isCommitteeMember",
                "render": function (data, type, row) {
                    return data ? 'Yes' : 'No';
                },
                "width": "5%"
            },
            {
                "data": "programs",
                "render": function (data, type, row) {
                    return data.join(', ');
                },
                "width": "20%"
            },
            {
                "data": { id: "id", lecturerId: "lecturerId" },
                "render": function (data) {
                    return `<div class="text-center">
                                <a href="/Admin/Lecturer/ChangeCommitteeStatus?Id=${data.lecturerId}" class="btn btn-primary text-white" style="cursor:pointer; width:150px;">
                                    <i class="bi bi-pencil-square"></i> Change Role
                                </a>
                                <a href="/Admin/Lecturer/AssignProgram?Id=${data.lecturerId}" class="btn btn-success text-white" style="cursor:pointer; width:200px;">
                                    <i class="bi bi-pencil-square"></i> Manage Program
                                </a>
                                <a onclick="deleteConfirmation('${data.lecturerId}')" class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                                    <i class="bi bi-trash-fill"></i> Delete
                                </a>
                            </div>`;
                },
                "width": "55%"
            }
        ]
    });
}

function deleteConfirmation(id) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: '/admin/lecturer/delete/' + id,
                success: function (data) {
                    if (data.success) {
                        Swal.fire({
                            title: "Deleted!",
                            text: "Your file has been deleted.",
                            icon: "success"
                        });
                        dataTable.ajax.reload();
                    } else {
                        Swal.fire({
                            title: "Error!",
                            text: data.message,
                            icon: "error"
                        });
                    }
                }
            });
        }
    });
}
