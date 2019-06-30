//POSTBACK LOADING MESSAGE
$(window).on('load', function () {
    $("#coverScreen").hide();
});
window.onbeforeunload = function (e) {
    $("#coverScreen").show();
};

//TRATAMENTO DE BUG FACEBOOK
if (window.location.hash && window.location.hash == '#_=_') {
    window.location.hash = '';
}

