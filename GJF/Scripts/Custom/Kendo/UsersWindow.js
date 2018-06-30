function onClose() {
    $("#undo").show();
    $("#UsersGrid").data("kendoGrid").dataSource.read();
    
}

function onAddOpen() {
    var window = $("#users-window").data("kendoWindow");
    window.refresh('/User/CreateUser');
    window.center().open();
    $("#undo").hide();
}

function onEditOpen(id) {
    var window = $("#users-window").data("kendoWindow");
    window.refresh('/User/EditUser?id='+id);
    window.center().open();
    $("#undo").hide();
}
