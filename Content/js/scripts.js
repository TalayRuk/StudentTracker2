

$(function() {

  $("table").stupidtable();

  //For Example popupoverlay
  $('#example_popup').popup({
    color: 'white',
    opacity: .8,
    transition: '0.5s',
    scrolllock: true
  });

  //For popup slider
  $('#slide').popup({
  outline: false, // optional
  focusdelay: 400, // optional
  vertical: 'top', //optional
  blur: true
  });
});
