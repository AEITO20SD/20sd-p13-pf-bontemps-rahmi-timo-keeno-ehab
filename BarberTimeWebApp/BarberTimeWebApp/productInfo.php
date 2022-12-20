<!DOCTYPE html>
<html lang="nl" dir="ltr">
  <head>
    <meta charset="utf-8">
    <link rel="stylesheet" href="style.css">
  </head>
  <body>
    <?php include "header.php";
        $productId = $_GET['Id'];

         include "database/connectdb.php";

         $sql = "SELECT * FROM `products` WHERE `Id` LIKE $productId";
         $result = $conn->query($sql);

         if ($result->num_rows > 0) {
           // output data of each row
           while($row = $result->fetch_assoc()) {
             ?>
             <div class="fullProductInfoBox">
               <div class="productImageDetails">
               <?php if ($row['Image'] == "") {?>
                 <img class="productImageDetails" src="images/NoImage.jpg"><br>
                 <?php
               } else { ?>
                 <img class="productImageDetails" src="data:image/jpg;charset=utf8;base64,<?php echo ($row['Image']); ?>">
               <?php } ?>
               </div>
               <div class="ProductDetails">
                 <h3><?php echo $row["Name"]; ?></h3>
                 <p><b>€</b>‎<?php echo $row["Euro"];?>,<?php echo $row["Cents"]; ?></p>
                 <a href="#" class="addItemToCartButton"><img class="addItemToCartButton" src="images/shoppingcartWhite.png" alt=""></a>
               </div>
             </div>
             <div class="ProductExtendedDetails">
               <h3>Beschrijving</h3>
               <?php echo $row["Description"]; ?>
             </div>
             <title><?php echo $row['Name'] ?> - BarberTime</title>
            <?php
          }
        } else {
          echo "Something went wrong...";
        }
        $conn->close();
        ?>
  </body>
</html>
