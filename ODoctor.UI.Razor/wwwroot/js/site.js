$(document).ready(function () {
  $(function () {
    $('.multiselect-ui').multiselect({
      includeSelectAllOption: true
    });
  });
  $('[data-toggle=collapse]').mouseover(function () {
    $(this).trigger('click');
  }).mouseoout(function () {

  });
});