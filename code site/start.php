<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8" />
        <title>Crypto-TPE</title>
        <link rel="stylesheet" href="css.css" />
    </head>

    <body>
      <br/><br/>
      <center><h2>Bienvenue sur ce site d'échange de messages cryptés!</h2></center>
      <br/>
      <center><h3>Connectez vous</h3></center>
      <br/>
      <form action="connection.php?method=connect" method="post">

        <center><input type="text" name="username" placeholder="username" class="large_input"/></center>
        <center><input type="password" name="passW" placeholder="password" class="large_input"/></center><br/>
        <center><input type="submit" value="Se connecter" class="voirPlusSmall"/></center>
      </form>
      <br/>
      <center><h3>Ou entrez en tant qu'invité</h3></center>
      <form action="connection.php?method=invit" method="post">

        <center><input type="submit" name="invite" value="Connection invité" class="voirPlusSmall"/></center>

      </form>
      <center><h3>Si vous ne possédez pas de compte, vous pouvez en créer un ici:</h3></center>
      <form action="newCompte.php" method="post">
        <center><input type="submit" value="Créer compte" class="voirPlusSmall"/>
      </form>
    </body>
</html>
