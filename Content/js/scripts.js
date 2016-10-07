function courseActive(int){
  var phrase = "Error";
  if (int == 0 ){phrase = "Complete"; }
  if (int == 1){phrase = "Current";}
  if (int == 2){phrase = "Future";}
  return phrase;
}


$(function() {

  $("table").stupidtable();

  //For Example popupoverlay
  $('#example_popup').popup({
    color: 'white',
    opacity: .8,
    transition: '0.5s',

  });

  //For popup slider
  $('#slide').popup({
  outline: false, // optional
  focusdelay: 400, // optional
  vertical: 'top', //optional
  scrolllock: true,
  blur:true
  });

  //For course popup slider
  $('#slide1').popup({
  outline: false, // optional
  focusdelay: 400, // optional
  vertical: 'top', //optional
  scrolllock: true,
  blur:true
  });

  //For course popup slider
  $('#slide2').popup({
  outline: false, // optional
  focusdelay: 400, // optional
  vertical: 'top', //optional
  scrolllock: true,
  blur:true
  });
});
