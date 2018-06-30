$(function () {

    var boardHub = $.connection.boardHub;


    //sportsman one

    boardHub.client.addSportsmanOneWazariPoint = function (message) {

        $('#sportsman1_wazari_point').html(message);

    };

    boardHub.client.removeSportsmanOneWazariPoint = function (message) {

        $('#sportsman1_wazari_point').html(message);

    };

    boardHub.client.addSportsmanOneIpponPoint = function (message) {

        $('#sportsman1_ippon_point').html(message);

    };

    boardHub.client.removeSportsmanOneIpponPoint = function (message) {

        $('#sportsman1_ippon_point').html(message);
    };

    boardHub.client.addSportsmanOneFinePoint = function (message) {
        $("#sportsman1_reload_fine_point").load(" #sportsman1_reload_fine_point");
        $('#sportsman1_fine').html(message);
       

    };

    boardHub.client.removeSportsmanOneFinePoint = function (message) {
        $("#sportsman1_reload_fine_point").load(" #sportsman1_reload_fine_point");
        $('#sportsman1_fine').html(message);
       

    };

    boardHub.client.addSportsmanTwoFinePoint = function (message) {
        $("#sportsman2_reload_fine_point").load(" #sportsman2_reload_fine_point");
        $('#sportsman2_fine').html(message);


    };

    boardHub.client.removeSportsmanTwoFinePoint = function (message) {
        $("#sportsman2_reload_fine_point").load(" #sportsman2_reload_fine_point");
        $('#sportsman2_fine').html(message);
    };

    boardHub.client.autoWinSportsmanOne = function () {
        location.href = '#modal';
        
    };


    //sportsman two

    boardHub.client.addSportsmanTwoWazariPoint = function (message) {

        $('#sportsman2_wazari_point').html(message);

    };

    boardHub.client.removeSportsmanTwoWazariPoint = function (message) {

        $('#sportsman2_wazari_point').html(message);

    };

    boardHub.client.addSportsmanTwoIpponPoint = function (message) {

        $('#sportsman2_ippon_point').html(message);

    };

    boardHub.client.removeSportsmanTwoIpponPoint = function (message) {

        $('#sportsman2_ippon_point').html(message);
    };

    boardHub.client.autoWinSportsmanTwo = function () {
        location.href = '#modal2';

    };

    /////////////////timer/////////////////////////////
    boardHub.client.timer = function (message) {
        
        $('#timer').html(message);
    };

    ////////////////////////////////////////////////////////////////////////

    $.connection.hub.start().done(function () {
        var id = $("#wrestleId").val();
        boardHub.server.addClientToWrestle(id);
        ///////////////////timer/////////////////////////////
        $('#start_counter').click(function () {

            setInterval(function () {
                var id = $("#wrestleId").val();
                boardHub.server.timer($('#timer').html(), id);
            }, 1000);
           
        });
        // sportsman one
        $('#sportsman1_add_ippon_point').click(function () {
            var id = $("#wrestleId").val();
            boardHub.server.addSportsmanOneIpponPoint($('#sportsman1_ippon_point').html(),id);
        });

        $('#sportsman1_remove_ippon_point').click(function () {
            var id = $("#wrestleId").val();
            boardHub.server.removeSportsmanOneIpponPoint($('#sportsman1_ippon_point').html(),id);
        });

        $('#sportsman1_add_wazari_point').click(function () {
            var id = $("#wrestleId").val();
            boardHub.server.addSportsmanOneWazariPoint($('#checkTime').html(),$('#sportsman1_wazari_point').html(),id);
        });

        $('#sportsman1_remove_wazari_point').click(function () {
            var id = $("#wrestleId").val();
            boardHub.server.removeSportsmanOneWazariPoint($('#sportsman1_wazari_point').html(), id);
        });

        $('#sportsman1_add_fine_point').click(function () {
            var id = $("#wrestleId").val();
            boardHub.server.addSportsmanOneFinePoint($('#sportsman1_fine').html(), id);
        });

        $('#sportsman1_remove_fine_point').click(function () {
            var id = $("#wrestleId").val();
            boardHub.server.removeSportsmanOneFinePoint($('#sportsman1_fine').html(), id);

        });

        $('#sportsman2_add_fine_point').click(function () {
            var id = $("#wrestleId").val();
            boardHub.server.addSportsmanTwoFinePoint($('#sportsman2_fine').html(), id);
        });

        $('#sportsman2_remove_fine_point').click(function () {
            var id = $("#wrestleId").val();
            boardHub.server.removeSportsmanTwoFinePoint($('#sportsman2_fine').html(), id);
        });

        $('#sportsman1_auto_win').click(function () {
            var id = $("#wrestleId").val();
            boardHub.server.autoWinSportsmanOne(id);
        });

        //sportsman two
        $('#sportsman2_add_ippon_point').click(function () {
            var id = $("#wrestleId").val();
            boardHub.server.addSportsmanTwoIpponPoint($('#sportsman2_ippon_point').html(), id);
        });

        $('#sportsman2_remove_ippon_point').click(function () {
            var id = $("#wrestleId").val();
            boardHub.server.removeSportsmanTwoIpponPoint($('#sportsman2_ippon_point').html(), id);
        });

        $('#sportsman2_add_wazari_point').click(function () {
            var id = $("#wrestleId").val();
            boardHub.server.addSportsmanTwoWazariPoint($('#checkTime').html(),$('#sportsman2_wazari_point').html(), id);
        });

        $('#sportsman2_remove_wazari_point').click(function () {
            var id = $("#wrestleId").val();
            boardHub.server.removeSportsmanTwoWazariPoint($('#sportsman2_wazari_point').html(), id);
        });

        $('#sportsman2_auto_win').click(function () {
            var id = $("#wrestleId").val();
            boardHub.server.autoWinSportsmanTwo(id);
        });
        
    });
});

