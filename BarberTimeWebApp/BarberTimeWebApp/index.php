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
  </body>
</html>
