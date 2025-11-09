var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/user/getall' },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "role", "width": "5%" },
            { "data": "streetAddress", "width": "15%" },
            { "data": "nationality", "width": "5%" },
            { "data": "icNumber", "width": "10%" },
            { "data": "gender", "width": "1%" },
            {
                data: { id:"id", lockoutEnd:"lockoutEnd"},
                "render": function (data) {
                    var today = new Date().getTime();
                    var lockout = new Date(data.lockoutEnd).getTime();

                    if (lockout > today) {
                        return `
                        <div class="text-center">
                            <a onclick=LockUnlock('${data.id}') class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                                <i class="bi bi-unlock-fill"></i> Lock
                            </a>
                            <a onclick="deleteConfirmation('${data.id}')" class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                                    <i class="bi bi-trash-fill"></i> Delete
                            </a>
                        </div>  
                        `
                    }
                    else
                    {
                        return `
                        <div class="text-center">
                            <a onclick=LockUnlock('${data.id}')  class="btn btn-success text-white" style="cursor:pointer; width:100px;">
                                <i class="bi bi-unlock-fill"></i> UnLock
                            </a>
                            <a onclick="deleteConfirmation('${data.id}')" class="btn btn-danger text-white" style="cursor:pointer; width:100px;">
                                    <i class="bi bi-trash-fill"></i> Delete
                            </a>
                        </div>  
                        `
                    }
                    
                },
                "width": "45%"
            }
        ]
    });
}


function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/User/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
        }
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
                url: '/admin/User/delete/' + id,
                success: function (data) {
                    if (data.success) {
                        Swal.fire({
                            title: "Deleted!",
                            text: "Account has been deleted.",
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