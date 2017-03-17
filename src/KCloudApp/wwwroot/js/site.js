// Write your Javascript code.
$(function () {
    // See if this is a touch device
    if ('ontouchstart' in window) {
        // Set the correct body class
        $('body').removeClass('no-touch').addClass('touch');

        // Add the touch toggle to show text
        $('div.boxInner img').click(function () {
            $(this).closest('.boxInner').toggleClass('touchFocus');
        });
    }
});
