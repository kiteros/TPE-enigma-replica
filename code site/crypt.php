<!DOCTYPE html>
<html>
    <head>
        <meta charset="utf-8" />
        <title>Titre</title>
        <link rel="stylesheet" href="css.css" />
    </head>

    <body>
      <form action="redirect.php" method="post">

        <input type="radio" name="cle" value="polyalpha" id="polyalpha" /> <label for="polyalpha">Cryptage polyalphabetique</label><br />
        <input type="radio" name="cle" value="premier" id="premier" /> <label for="premier">Cryptage RSA</label><br />
        <input type="radio" name="cle" value="quantic" id="quantic" /> <label for="quantic">Cryptage quantique</label><br />
        <input type="radio" name="cle" value="enigma" id="enigma" /> <label for="enigma">Cryptage avec Enigma</label><br />
        <input type="submit" value="Valider le texte"/>
      </form>

    </body>
</html>
