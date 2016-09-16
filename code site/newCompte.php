<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8" />
        <title>Crypto-TPE</title>
        <link rel="stylesheet" href="css.css" />
    </head>
    <?php
      if(isset($_GET['error'])){
        if($_GET['error'] == 'missing'){
          echo 'Champs manquants';
        }else if($_GET['error'] == 'unsame'){
          echo 'Les mots de passes ne sont pas les mêmes';
        }
      }
    ?>

    <body>
      <br/><br/>
      <center><h2>Créer un compte : </h2></center>
      <br/>
      <form action="#" method="post">
        <center><input type="text" name="name" placeholder="Nom d'utilisateur" class="large_input" /></center>
        <center><input type="password" name="pw1" placeholder="mot de passe" class="large_input" /></center>
        <center><input type="password" name="pw2" placeholder="retapez le mot de passe" class="large_input" /></center><br/>
        <center><input type="submit" name="sub" value="Créer un compte" class="voirPlusSmall" /></center>
      </form>
    </body>

    <?php
      if(isset($_POST['name']) AND isset($_POST['pw1']) AND isset($_POST['pw2'])){
        if($_POST['pw1'] == $_POST['pw2']){
          //On peut ajouter l'user
          try
          {
            $bdd = new PDO('mysql:host=charentemessages.mysql.db;dbname=charentemessages;charset=utf8', 'charentemessages', 'Virtule2');
          }
          catch(Exception $e)
          {
                  die('Erreur : '.$e->getMessage());
          }

          $addUser = $bdd->prepare('INSERT INTO users (id, nom, password) VALUES (NULL, :nom, :psw)');
          $addUser->execute(array(
            'nom' => $_POST['name'],
            'psw' => sha1($_POST['pw1'])
          ));
          session_start();
          $_SESSION['nom'] = $_POST['name'];
          header('Location: crypt.php');
          exit();
        }else{
          //erreur psw

          echo '<center>Les mots de passe ne correspondent pas</center>';

        }
      }else{
        //tout les champs ne sont pas remplis.
        echo '<center>Tout les champs ne sont pas remplis</center>';
      }
    ?>
</html>
