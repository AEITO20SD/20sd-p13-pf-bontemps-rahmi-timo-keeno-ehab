<?php
if (isset($_SESSION["loggedin"]) && $_SESSION["loggedin"] === false){
header("location: index.php");
exit;
}
?>
<!DOCTYPE html>
<html lang="nl" dir="ltr">
  <head>
    <meta charset="utf-8">
    <title>Producten Toevoegen - BarberTime</title>
    <link rel="stylesheet" href="style.css">
  </head>
  <body>
    <?php include "header.php"; ?>
    <div class="changeAccountSettings">
        <b style="flex: 1; text-align: center;">Account</b>
        <a style="flex: 2; color: dodgerblue; text-align: center;" href="resetPassword.php">Verander Wachtwoord</a>
        <a style="flex: 1; color: #cc0000; text-align: center;" href="logout.php">Uitloggen</a>
    </div>
    <div class="allProductsBox">
      <a class="addButton" href="addProduct.php"><button class="button" type="button" name="button">Product Toevoegen</button></a>
    </div>
    <table>
      <tr>
        <th>Naam</th>
        <th>Prijs</th>
        <th>Inv</th>
        <th>Foto</th>
        <th>Optie</th>
      </tr>
    <?php include "database/connectdb.php";

    $sql = "SELECT * FROM `products`";
    $result = $conn->query($sql);

    if ($result->num_rows > 0) {
      // output data of each row
      while($row = $result->fetch_assoc()) {
        ?>
        <tr>
          <td><?php echo $row["Name"]; ?></td>
          <td><?php echo $row["Euro"]; ?>,<?php echo $row["Cents"]; ?></td>
          <td><?php echo $row["InvAmount"]; ?></td>
          <?php if ($row['Image'] == "") {?>
            <td style="padding: 1px; text-align: center;"><img class="columnImage" src="images/NoImage.jpg" alt=""></td>
            <?php
          } else { ?>
            <td style="padding: 1px; text-align: center;"><img class="columnImage" src="data:image/jpg;charset=utf8;base64,<?php echo ($row['Image']); ?>" alt=""></td>
          <?php }?>
          <td><a style="color: dodgerblue" href="editProduct.php?id=<?php echo $row["Id"]; ?>">Edit</a></td>
        </tr>
        <?php
      }
    } else {
      echo "Something went wrong...";
    }
    $conn->close();
    ?>
    </table>
  </body>
</html>
