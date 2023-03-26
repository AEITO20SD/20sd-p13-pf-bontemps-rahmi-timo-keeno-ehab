<!DOCTYPE html>
<html lang="nl" dir="ltr">
  <head>
    <meta charset="utf-8">
    <link rel="stylesheet" href="style.css">
    <title>Bewerken - BarberTime</title>
  </head>
  <body>
 <!-- Database connection is imported and id is fetched -->
<?php include "database/connectdb.php";
$id = $_GET['id'];
$sql = "SELECT * FROM products WHERE id = $id;";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {

        include "header.php"; ?>
    <form class="formText"  method="post" enctype="multipart/form-data">
      <div class="formText">
        <label>Naam:</label><br>
        <input style="width: 100%;" type="text" name="ProductName" id="ProductName" value="<?php echo $row["Name"]; ?>">
      </div>
      <div class="formText">
        <label for="Price">Prijs</label><br>
        <b>€‎</b><input type="number" name="Euros" style="width: 30px;" id="Euros" value="<?php echo $row["Euro"]; ?>">,<input style="width: 22px;" type="number" name="Cents" name="Price" id="Cents" value="<?php echo $row["Cents"]; ?>">
      </div>
      <div class="formText">
        <label>Voorraadsniveau:</label><br>
        <input style="width: 30px;" type="number" name="InvAmount" id="InvAmount" value="<?php echo $row["InvAmount"]; ?>"> Stuks
      </div>
      <div class="formText">
        <label>Foto:</label><br>
        <input style="border: none;" type="file" name="file" id="file" accept=".png,.jpeg,.jpg,.webp">
        <p class="editText">Ondersteunde formaten: PNG, JPG, JPEG, WEBP</p>
        <p class="editText">Minimaal 160x160, Max 1MB</p>
        <p class="editText">Beste formaat: .PNG met transparante achtergrond.</p>
      </div>
      <div class="formText">
        <label>Beschrijving:</label><br>
        <textarea class="descriptionBox" name="Description" rows="16" id="Description"><?php echo $row["Description"]; ?></textarea>
      </div>
      <div class="formText">
          <input class="button addButton" type="submit" name="submit" value="Opslaan">
      </div>
        <div class="formText">
          <input class="button addButton" style="background-color: #cc0000" type="submit" name="delete" value="Delete">
        </div>
    </form>
  </body>
</html>
<?php
}
} else {
    header("location: addProduct.php");
}
if (isset($_POST['delete'])) {
    $sql = "DELETE FROM products WHERE id = $id;";

    if ($conn->query($sql) === TRUE) {
        header('Location: dataview.php');
        exit;
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }
}

// Collects all the data in the inputs and sends it to a database
if (isset($_POST['submit'])) {

  $image = ($_FILES['file']['tmp_name']);
  $Name = ($_POST['ProductName']);
  $Euro = ($_POST['Euros']);
  $Cents = ($_POST['Cents']);
  $InvAmount = ($_POST['InvAmount']);
  $Image = base64_encode(file_get_contents($image));
  //$Image = ($_POST['file']);
  $Description = ($_POST['Description']);

    // Detects if the user uploaded a new picture and determines the required connection string
    if (mb_strlen ($Image, "base64") < 40) {
        $sql = "UPDATE products SET Name = '$Name', Euro = '$Euro', Cents = '$Cents', Description = '$Description', InvAmount = '$InvAmount' WHERE id = $id;";
    } else {
        $sql = "UPDATE products SET Name = '$Name', Euro = '$Euro', Cents = '$Cents', Description = '$Description', InvAmount = '$InvAmount', Image = '$Image' WHERE id = $id;";
    }


    // Sends the connection string to the database server and checks for any errors
  if ($conn->query($sql) === TRUE) {
  header('Location: dataview.php'); exit;
} else {
  echo "Error: " . $sql . "<br>" . $conn->error;
}

} ?>
<!-- This script checks if the file size is bigger than 1MB and gives an error if it is -->
<script>
  var uploadField = document.getElementById("file");

  uploadField.onchange = function() {
    if(this.files[0].size > 1048576){
      alert("Dit bestand is te groot! Het bestand kan maximaal 1MB zijn");
      this.value = "";
    };
  };
</script>
