<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Bilgi Sistemleri ve Güvenliği 4.Ödev</title>
        <link rel="stylesheet" type="text/css" href="engine/Vendors/bulmaio/bulma.min.css"/>
        <link rel="stylesheet" type="text/css" href="engine/Vendors/fontawesome/css/all.min.css"/>

    </head>
    <body>
      <div class="container">
        <br><br>
        <div class="notification is-primary">

            <div class="field">
             <label class="label">AD SOYAD</label>
             <div class="control has-icons-left has-icons-right">
             <input class="input" type="text" size="20" name="username" placeholder="Ad soyad">
             <span class="icon is-small is-left">
             <i class="fas fa-user"></i>
             </span>
             </div>
            </div>
            <div class="field">
             <label class="label">Telefon</label>
             <div class="control has-icons-left has-icons-right">
             <input class="input" type="text" name="tel" placeholder="tel">
             <span class="icon is-small is-left">
             <i class="fas fa-phone"></i>
             </span>
             </div>
            </div>
            <div class="field">
             <label class="label">Adres</label>
             <div class="control has-icons-left has-icons-right">
             <input class="input" type="text" name="adres" placeholder="adres">
             <span class="icon is-small is-left">
             <i class="fas fa-user"></i>
             </span>
             </div>
            </div>
            <div class="field">
             <label class="label"></label>
             <p class="control has-icons-left imagefiled">
             </p>
             <button class="button" onclick="$.capthaCreate()">
               <span class="icon is-small">
                 <i class="fas fa-sync"></i>
               </span>
             </button>
            </div>
            <div class="field">
             <label class="label">CAPTCHA</label>
             <p class="control has-icons-left">
              <input class="input" type="text" name="captcha" placeholder="captcha">
              <span class="icon is-small is-left">
               <i class="fas fa-certificate"></i>
              </span>
             </p>
            </div>
            <div class="field">
              <button class="button is-warning">Login</button>
            </div>
          </div>
        </div>
        <script type="text/javascript" src="engine/Js/jquery.min.js"></script>
        <script type="text/javascript" src="engine/Vendors/fontawesome/js/all.min.js" ></script>
        <script>
          $(document).ready(function(){
            $.capthaCreate=function() {
             $.ajax({
                 url: 'captha.php',
                 dataType: 'json',
                 type: 'POST',
                 data: "{}",
                 contentType: 'application/json; charset=utf-8',
                 complete: function ($xhr) {
                   $random = Math.floor((Math.random() * 1222259157) + 1);
                   $(".imagefiled").html('<img src="engine/Images/captchaimage.png?'+$random+'" width="150px" id="capt">');
                   $("input[name=captcha]").val($xhr.responseText);
                 }
             });
            };
            $.capthaCreate();

          });
        </script>
      </body>
</html>
