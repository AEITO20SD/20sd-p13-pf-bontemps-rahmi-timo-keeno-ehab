<!DOCTYPE html>
<?php $ProductsInCart = 0; ?>
<html lang="nl" dir="ltr">
  <head>
    <meta charset="utf-8">
    <link rel="stylesheet" href="style.css">
    <title>Producten - BarberTime</title>
  </head>
  <?php include "header.php"; ?>
  <body>
    <div class="allProductsBox">
      <?php
      include "productspage.php";
      ?>
    </div>
    <a href="dataview.php" style="color: black;"><img style="width: 10px;" src="images/white.png" alt=""></a>
  </body>
</html>
