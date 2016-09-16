<?php
  if(isset($_GET['method'])){
    if($_GET['method'] == 'connect'){
      //connect bdd
      try
      {
        $bdd = new PDO('mysql:host=charentemessages.mysql.db;dbname=charentemessages;charset=utf8', 'charentemessages', 'Virtule2');
      }
      catch(Exception $e)
      {
              die('Erreur : '.$e->getMessage());
      }
      $searchUser = $bdd->prepare('SELECT * FROM users WHERE nom = :nom AND password = :psw');
      $searchUser->execute(array(
        'nom' => $_POST['username'],
        'psw' => sha1($_POST['passW'])
      ));
      $searchUser->fetch();
      $nbFound = $searchUser->rowCount();
      if($nbFound >= 1){
        //User existe
        $_SESSION['name'] = $_POST['name'];
        header('Location: crypt.php');
      }
      echo 'coucou';
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
