<?php
if(isset($_POST['cle'])){
  $cle = $_POST['cle'];
  if($cle == "polyalpha"){
    header('Location: poly.php');
    exit;
  }else if($cle == "premier"){
    header('Location: nowhere.php');
    exit;
  }
}
?>
