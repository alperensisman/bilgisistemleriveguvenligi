$(document).ready(function(){
    $(".btn-login").on("click",function() {
      var uname = $("#uname").val();
      var password = $("#password").val();
      $.ajax({
            url: 'backend.php',
            type: 'POST',
            data: {'uname':uname,'password':password},
            success: function (data) {
                console.log(data);
            }
        });
    });

    $("#sendbuton").on("click",function() {
      var email = $("#email").val();
      $.ajax({
            url: 'backend.php',
            type: 'POST',
            data: {'email':email},
            success: function (data) {
               console.log(data);
            }
        });
    });



    $("#uname").on("change",function() {
      var valueThis = $.trim($(this).val());
      if(valueThis=="") {
        $("button.btn-login").removeClass("fullInput");
      } else {
        $("button.btn-login").addClass("fullInput");
      }
    });

  });
