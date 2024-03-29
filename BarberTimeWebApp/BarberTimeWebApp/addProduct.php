<?php
session_start();

if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true){
    header("location: signIn.php");
    exit;
}
// Database connection is imported
 include "database/connectdb.php";
// Collects all the data in the inputs and sends it to a database
 if (isset($_POST['submit'])) {
     $image = ($_FILES['file']['tmp_name']);

    if (mb_strlen($image) > 10) {
        $Image = base64_encode(file_get_contents($image));
        $ImgBool = true;
    } else {
        $ImgBool = false;
    }

    $Name = ($_POST['ProductName']);
    $Euro = ($_POST['Euros']);
    $Cents = ($_POST['Cents']);
    $InvAmount = ($_POST['InvAmount']);

    //$Image = ($_POST['file']);
    $Description = ($_POST['Description']);

    if ($ImgBool === false){
        $sql = "INSERT INTO products (Name, Euro, Cents, Description, InvAmount)
        VALUES ('$Name','$Euro', '$Cents', '$Description', '$InvAmount')";
    } else {
        $sql = "INSERT INTO products (Name, Euro, Cents, Description, InvAmount, Image)
        VALUES ('$Name','$Euro', '$Cents', '$Description', '$InvAmount', '$Image')";
    }



    if ($conn->query($sql) === TRUE) {
        header('Location: dataview.php'); exit;
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }

} ?>
<!DOCTYPE html>
<html lang="nl" dir="ltr">
<head>
    <meta charset="utf-8">
    <link rel="stylesheet" href="style.css">
    <title>Bewerken - BarberTime</title>
</head>

<body>
<?php include "header.php"; ?>
<form class="formText"  method="post" enctype="multipart/form-data">
    <div class="formText">
        <label>Naam:</label><br>
        <input type="text" name="ProductName" id="ProductName">
    </div>
    <div class="formText">
        <label for="Price">Prijs</label><br>
        <b>€‎</b><input type="number" name="Euros" style="width: 30px;" id="Euros">,<input style="width: 22px;" type="number" name="Cents" name="Price" id="Cents">
    </div>
    <div class="formText">
        <label>Voorraadsniveau:</label><br>
        <input style="width: 30px;" type="number" name="InvAmount" id="InvAmount"> Stuks
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
        <textarea class="descriptionBox" name="Description" rows="16" id="Description"></textarea>
    </div>
    <div class="formText">
        <input class="button addButton" type="submit" name="submit" value="Opslaan">
    </div>
</form>
</body>
</html>

<script>
    var uploadField = document.getElementById("file");

    uploadField.onchange = function() {
        if(this.files[0].size > 1048576){
            alert("Dit bestand is te groot! Het bestand kan maximaal 1MB zijn");
            this.value = "";
        };
    };
</script>