<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8" />
        <title>Titre</title>
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
        <center><input type="password" name="passW" placeholder="password" class="large_input"/></center>
      </form>
      <br/>
      <center><h3>Ou entrez en tant qu'invité</h3></center>
      <form action="connection.php?method=invit" method="post">

        <center><input type="submit" name="invite" value="Connection invité" class="voirPlusSmall"/></center>

      </form>
    </body>
</html>
