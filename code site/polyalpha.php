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
      <div class="conteneur">
        <div class="left">
          <center><h2>Envoyer des messages</h2></center>
          <br/>
          <form action="envoyerMessage.php" method="post">
            <textarea name="messageToCrypt" placeholder="Message à crypter">
            </textarea>
            <br/>
            <input type="text" name="cleCrypt" placeholder="Clé de cryptage"/>
            <input type="radio" name="pp" value="private"> private<br/>
            <input type="radio" name="pp" value="public"> public<br/>
          <form>
        </div>
        <div class="right">
          <center><h2>Envoyer des messages</h2></center>
          <br/>
        </div>
      </div>

    </body>
</html>
