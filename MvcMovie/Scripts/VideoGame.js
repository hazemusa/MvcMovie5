var platform = 0;

showGameSelect = function (platform) {
    if (platform == 1)
    {
        $("#ps4game").hide();
        $("#xb1game").show();
    }
    else if (platform == 2)
    {
        $("#ps4game").show();
        $("#xb1game").hide();
    }
    else if (platform == 0)
    {
        $("#ps4game").hide()
        $("#xb1game").hide()
    }
}