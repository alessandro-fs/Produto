//POSTBACK LOADING MESSAGE
$(window).on('load', function () {
    $("#coverScreen").hide();
});
window.onbeforeunload = function (e) {
    $("#coverScreen").show();
};

