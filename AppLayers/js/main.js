
$(document).ready(function () {
  $("#menu_slide").click(function () {
    $("#navbar").slideToggle('normal');
  });

  $('#navbar > ul > li:has(ul)').addClass("has-sub");
  $('#navbar > ul > li > a').click(function () {
    var checkElement = $(this).next();
    $('#navbar li').removeClass('dropdown');
    $(this).closest('li').addClass('dropdown');
    if ((checkElement.is('ul')) && (checkElement.is(':visible'))) {
      $(this).closest('li').removeClass('dropdown');
      checkElement.slidseUp('normal');
    }
    if ((checkElement.is('ul')) && (!checkElement.is(':visible'))) {
      $('#navbar ul ul:visible').slideUp('normal');
      checkElement.slideDown('normal');
    }
    if (checkElement.is('ul')) {
      return false;
    } else {
      return true;
    }
  });
  
  $("#navbar").on("click", function (event) {
    event.stopPropagation();
  });
  $(".dropdown-menu").on("click", function (event) {
    event.stopPropagation();
  });
  $(document).on("click", function (event) {
    $(".dropdown-menu").slideUp('normal');
  });

  $(".navbar-header").on("click", function (event) {
    event.stopPropagation();
  });
  $(document).on("click", function (event) {
    $("#navbar").slideUp('normal');
  });
  $("main").load("./pages/home.html");
  $("#navbar ul li").click(function(a){
    //console.log($(this).text());
    let link = $(this).text();
    $("main").html("");
    $("main").load("./pages/"+ link.toLowerCase() + ".html");
  });

});

