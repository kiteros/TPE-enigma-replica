<?php
  session_start();
  if(!isset($_SESSION['nom'])){
    header('Location: start.php?error=e');
    exit;
  }

 ?>

<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8" />
        <title>Crypto-TPE</title>
        <link rel="stylesheet" href="css.css" />
    </head>

    <body>

      <form action="redirect.php" method="post">
        <input type="hidden" name="cle" value="polyalpha"/>
        <input type="submit" value="Cryptage polyalphabétique" class="voirPlusSmall"/>
      </form>
      <form action="redirect.php" method="post">
        <input type="hidden" name="cle" value="rsa"/>
        <input type="submit" value="Cryptage RSA" class="voirPlusSmall"/>
      </form>
      <form action="redirect.php" method="post">
        <input type="hidden" name="cle" value="enigma"/>
        <input type="submit" value="Cryptage Enigma" class="voirPlusSmall"/>
      </form>
      <form action="redirect.php" method="post">
        <input type="hidden" name="cle" value="quantique"/>
        <input type="submit" value="Cryptage quantique" class="voirPlusSmall"/>
      </form>

    </body>
</html>
