(function ($, kendo) {
    
    $.extend(true, kendo.ui.validator, {
        validateOnBlur: false,
        rules: {
            //define custom validation rule to match remote validation:
            mvcremotevalidation: function (input) {
                if (input.is("[data-val-remote]") && input.val() !== "") {
                    var remoteURL = input.attr("data-val-remote-url");
                    var valid = false;

                    $.ajax({
                        async: false,
                        global: false,
                        url: remoteURL,
                        type: "POST",
                        dataType: "json",
                        data: validationData(input, this.element),
                        success: function (result) {
                            valid = result;
                        },
                        error: function () {
                            valid = false;
                        }
                    });

                    return valid;
                }

                return true;
            }
        },
        messages: {
            mvcremotevalidation: function (input) {
                return input.attr("data-val-remote");
            }
        }
    });

    function validationData(input, context) {
        var fields = input.attr("data-val-remote-additionalFields").split(",");
        var name = input.prop("name");
        var prefix = name.substr(0, name.lastIndexOf(".") + 1);
        var fieldName;
        var data = {};

        for (var i = 0; i < fields.length; i++) {
            fieldName = fields[i].replace("*.", prefix);
            if (fieldName !== "Id") {
                data[fieldName] = $("[name='" + fieldName + "']", context).val();


                data["Id"] = $(context).find("#Id").val();
            }

        }
        return data;
    }

})(jQuery, kendo);