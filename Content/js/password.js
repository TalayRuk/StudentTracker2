$(document).ready(function(){
  $(".signUpForm").hide();

$(".signUp").click(function() {
  $( ".signInForm" ).hide("slow");
  $( ".signUpForm" ).show("slow");
  $(".label").text("SIGN UP");

});

$(".signIn").click(function() {
  $( ".signUpForm" ).hide("slow");
  $( ".signInForm" ).show("slow");
    $(".label").text("LOGIN");

});
});
