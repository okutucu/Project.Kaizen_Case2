
$(document).ready(function () {

    var cookieValue = getCookie("selectedLanguageCookie");

    if (cookieValue != null)
    {
        $("#" + cookieValue).attr("selected", true);
    }
    

    $('#language-select').on('change', function () {

        let selectedLanguage = $(this).val();

         $('#language-select').val(selectedLanguage);
         document.cookie = "selectedLanguageCookie=" + selectedLanguage;

         var cookieValue = getCookie("selectedLanguageCookie");
          $("#" + selectedLanguage).attr("selected", true);
          location.reload();
       
    });
});

function getCookie(name) {
    var value = "; " + document.cookie;
    var parts = value.split("; " + name + "=");
    if (parts.length == 2) return parts.pop().split(";").shift();
}

