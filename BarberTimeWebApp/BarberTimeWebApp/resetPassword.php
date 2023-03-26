<?php
session_start();

if(!isset($_SESSION["loggedin"]) || $_SESSION["loggedin"] !== true){
    header("location: signIn.php");
    exit;
}

require_once "database/connectdb.php";

$new_password = $confirm_password = "";
$new_password_err = $confirm_password_err = "";

if($_SERVER["REQUEST_METHOD"] == "POST"){

    if(empty(trim($_POST["new_password"]))){
        $new_password_err = "Voer alstublieft het nieuwe wachtwoord in";
    } elseif(strlen(trim($_POST["new_password"])) < 6){
        $new_password_err = "Het wachtwoord moet minimaal 6 karakters bevatten";
    } else{
        $new_password = trim($_POST["new_password"]);
    }

    if(empty(trim($_POST["confirm_password"]))){
        $confirm_password_err = "Bevestig alstublieft het wachtwoord";
    } else{
        $confirm_password = trim($_POST["confirm_password"]);
        if(empty($new_password_err) && ($new_password != $confirm_password)){
            $confirm_password_err = "Het wachtwoord komt niet overeen.";
        }
    }

    if(empty($new_password_err) && empty($confirm_password_err)){
        $sql = "UPDATE brbtusers SET password = ? WHERE id = ?";

        if($stmt = mysqli_prepare($conn, $sql)){
            mysqli_stmt_bind_param($stmt, "si", $param_password, $param_id);

            $param_password = password_hash($new_password, PASSWORD_DEFAULT);
            $param_id = $_SESSION["id"];

            if(mysqli_stmt_execute($stmt)){
                session_destroy();
                header("location: signIn.php");
                exit();
            } else{
                echo "Oeps, er is iets mis gegaan. Probeer het later opnieuw";
            }

            mysqli_stmt_close($stmt);
        }
    }

    mysqli_close($conn);
}
?>

<!DOCTYPE html>
<html lang="nl">
<head>
    <meta charset="UTF-8">
    <title>Wachtwoord Veranderen - BarberTime</title>
    <link rel="stylesheet" href="style.css">
</head>
<?php require_once "header.php"; ?>
<body>
<div class="FormContainer">
    <div class="form-labels" style="border: inherit;">
        <h2>Reset Wachtwoord</h2>
        <p>Vul dit forum in om uw wachtwoord te resetten.</p>
        <form action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>" method="post">
            <label>Nieuw Wachtwoord:</label><br>
            <input type="password" name="new_password" required class="form-labels"><br>
            <span><?php echo $new_password_err; ?></span><br>
            <label>Bevestig Wachtwoord</label><br>
            <input type="password" required class="form-labels" name="confirm_password">
            <span><?php echo $confirm_password_err; ?></span><br>
            <button class="button addButton" type="submit" value="Submit">Opslaan</button><br><br>
            <a href="dataview.php">Annuleren</a>
        </form>
    </div>
</div>
</body>
</html>