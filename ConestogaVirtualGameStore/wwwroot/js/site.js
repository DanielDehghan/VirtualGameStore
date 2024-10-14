
$(document).ready(function () {
    console.log("jQuery is working!");
});


$(document).ready(function () {
    $('#releaseDatePicker').datepicker({
        format: 'yyyy-mm-dd',   // Format of the date
        todayHighlight: true,   // Highlights today's date
        autoclose: true,        // Closes the picker once a date is selected
        clearBtn: true,         // Adds a clear button to reset the date
        orientation: "bottom auto",  // Adjusts the dropdown orientation
        templates: {
            leftArrow: '<i class="fas fa-arrow-left"></i>',
            rightArrow: '<i class="fas fa-arrow-right"></i>'
        }
    });
});