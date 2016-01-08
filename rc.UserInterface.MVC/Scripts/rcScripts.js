$(function () {

    // will trigger when the document is ready
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy'
    }); //Initialise any date pickers
    //$('#myTab a:first').tab('show')    $('a[href=#profile]').tab('show')


    $.validator.methods.date = function (value, element) {
        if ($.browser.webkit) {

           // ES - Chrome does not use the locale when new Date objects instantiated:
            var d = new Date();

            return this.optional(element) || !/Invalid|NaN/.test(new Date(d.toLocaleDateString(value)));
        }
        else {

            return this.optional(element) || !/Invalid|NaN/.test(new Date(value));
        }
    };


   
    });
