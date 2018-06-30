$(document).ready(function () {

    $("body").on("click", ".RecordDeleteButton", function (e) {
        e.preventDefault();
        var $deleteBtn = $(this);

        var orderId = $deleteBtn.data("user-id");
        var gridId = $deleteBtn.data("grid-id");

        var warningText = "ნამდვილად გსურთ წაშლა ?!";
        var confim = confirm(warningText);

        if (confim === true) {
            var grid = $("#" + gridId).data("kendoGrid");

            var dataItem = grid.dataItem($deleteBtn.closest("tr"));

            var ds = grid.dataSource;
            ds.remove(dataItem);
            ds.sync();
        }

    });
});