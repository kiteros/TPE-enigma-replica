<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8" />
        <title>Titre</title>
        <link rel="stylesheet" href="css.css" />
        <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/sweetalert2/4.2.7/sweetalert2.min.css">

    </head>

    <script src="http://code.jquery.com/jquery-1.7.2.min.js"></script>
    <script src="assets/js/jquery.complexify.js"></script>
    <script src="assets/js/script.js"></script>
    <script src="https://cdn.jsdelivr.net/sweetalert2/4.2.7/sweetalert2.min.js"></script>

    <body>

      <form action="" method="post">
        <input type="text" name="tocrypt" placeholder="Message a crypter"/><br/>
        <input type="text" name="cle" placeholder="Cle de cryptage"/>
        <input type="submit" value="Crypter et envoyer"/>
      </form>
      <?php
      try
      {
        $bdd = new PDO('mysql:host=localhost;dbname=crypt;charset=utf8', 'root', '');
      }
      catch(Exception $e)
      {
              die('Erreur : '.$e->getMessage());
      }
      if(isset($_GET['mess'])){
        $messagesGet = $bdd->prepare('SELECT * FROM messages WHERE id = :id');
        $messagesGet->execute(array(
          'id' => $_GET['mess']
        ));
        $messagesGet->fetch();
      ?>
      <script>
      message = S_GET('text');
      var cle_ = 0;
      alphabet = 'abcdefghijklmnopqrstuvwxyz'.split('');
      swal({
        title: 'Entrez la clé de décryptage pour ce message:' + message,
        input: 'text',
        showCancelButton: true,
        inputValidator: function(value) {
          return new Promise(function(resolve, reject) {
            if (value) {
              cle_ = value;
              resolve();
            } else {
              reject('LA clé ne peut pas être vide');
            }
          });
        }
        }).then(function(result) {
        swal({
          type: 'success',
          html: 'message décrypté: ' + decrypt(cle_)
        });

      })

      function S_GET(id){
          var a = new RegExp(id+"=([^&#=]*)");
          return decodeURIComponent(a.exec(window.location.search)[1]);
      }

      function decrypt(cle){
        decrypted = '';
        tabMessage = message.split('');
        cle = 26 - (cle % 26);
        for (i = 1; i < tabMessage.length; i++) {
          var pos = alphabet.indexOf(tabMessage[i]);
          var newPos = (pos + cle) % 26;
          decrypted += alphabet[newPos];
        }
        return decrypted;
      }

      function genCharArray(charA, charZ) {
          var a = [], i = charA.charCodeAt(0), j = charZ.charCodeAt(0);
          for (; i <= j; ++i) {
              a.push(String.fromCharCode(i));
          }
          return a;
      }
			</script>
      <?php
        }
      ?>
      <?php

      if(isset($_POST['tocrypt']) && isset($_POST['cle'])){
        $messageACrypter = $_POST['tocrypt'];
        $cleCrypt = $_POST['cle'];
        $alphas = range('a', 'z');


        $tabCrypt = str_split($messageACrypter);
        $messageTotal = " ";
        echo "Votre message crypté : <br/>";
        for ($i = 0; $i < count($tabCrypt); $i++) {
          $positionDansAlphabet= array_search($tabCrypt[$i], $alphas);
          $nouvellePosition = ($positionDansAlphabet + $cleCrypt) % 26;
          if($tabCrypt[$i] == " "){
            $messageTotal = $messageTotal . " ";

          }else{
            $messageTotal = $messageTotal . $alphas[$nouvellePosition];

          }

        }
        echo "<span>" . $messageTotal . "</span>";
        //On stocke le message dans la bdd
        $addMessage = $bdd->prepare('INSERT INTO messages (id, message, date_) VALUES (NULL, :message, CURRENT_DATE())');
        $addMessage->execute(array(
          'message' => $messageTotal
        ));
      }else{
        echo "<span>Tout les champs ne sont pas remplis</span>";
      }


      echo "<br/><br/><br/>";
      $messages = $bdd->prepare('SELECT * FROM messages ORDER BY id DESC');
      $messages->execute(array());

      while($messageDon = $messages->fetch()){

        ?>
        <p>
        <form action="?mess=<?php echo $messageDon['id'];?>&text=<?php echo $messageDon['message'];?>" method="post">
           <?php echo "--> " . $messageDon['message'] . "<span> écrit le " . $messageDon['date_'] . "</span>"?>;
           <input type="hidden" value="<?php echo $messageDon['id'];?>"/>
          <input type="submit" value="Décrypter" class="voirPlusSmall"/>
        </form></p>
        <?php
      }


      ?>

  </body>
</html>
