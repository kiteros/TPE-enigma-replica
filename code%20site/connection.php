<?php
  if(isset($_GET['method'])){
    if($_GET['method'] == 'connect'){
      //connect bdd
      try
      {
        $bdd = new PDO('mysql:host=mysql.hostinger.fr;dbname=u678318874_crypt;charset=utf8', 'u678318874_jules', 'juju101970');
      }
      catch(Exception $e)
      {
              die('Erreur : '.$e->getMessage());
      }
    }else if($_GET['method'] == 'invit'){
      //invit
      session_start();
      $_SESSION['name'] = 'anonymous';
      //On passe directement au choix du type de cryptage :
      header('Location: crypt.php');
      exit;
    }else{
      echo 'error';
    }
  }
 ?>
