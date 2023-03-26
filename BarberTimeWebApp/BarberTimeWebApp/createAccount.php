<?php
session_start();

if(isset($_SESSION["loggedin"]) && $_SESSION["loggedin"] === true){
    header("location: dataview.php");
    exit;
}

require_once "database/connectdb.php";

$username = $password = $confirm_password = "";
$username_err = $password_err = $confirm_password_err = $admin_code_err = "";
$admincodevalidated = false;

if($_SERVER["REQUEST_METHOD"] == "POST"){

    if(empty(trim($_POST["username"]))){
        $username_err = "Voer alstublieft een Gebruikersnaam in.";
    } else{
        $sql = "SELECT id FROM brbtusers WHERE username = ?";

        if($stmt = mysqli_prepare($conn, $sql)){
            mysqli_stmt_bind_param($stmt, "s", $param_username);

            $param_username = trim($_POST["username"]);

            if(mysqli_stmt_execute($stmt)){
                mysqli_stmt_store_result($stmt);

                if(mysqli_stmt_num_rows($stmt) == 1){
                    $username_err = "Deze Gebruikersnaam is al in gebruik.";
                } else{
                    $username = trim($_POST["username"]);
                }
            } else{
                echo "Oeps, er is iets mis gegaan. Probeer het later opnieuw";
            }

            mysqli_stmt_close($stmt);
        }
    }

    if(empty(trim($_POST["password"]))){
        $password_err = "Voer alstublieft een wachtwoord in";
    } elseif(strlen(trim($_POST["password"])) < 6){
        $password_err = "Het wachtwoord moet minimaal 6 karakters bevatten.";
    } else{
        $password = trim($_POST["password"]);
    }

    if(empty(trim($_POST["confirm_password"]))){
        $confirm_password_err = "Bevestig alstublieft het wachtwoord.";
    } else{
        $confirm_password = trim($_POST["confirm_password"]);
        if(empty($password_err) && ($password != $confirm_password)){
            $confirm_password_err = "Het wachtwoord komt niet overeen.";
        }
    }

    if(empty(trim($_POST["admin_code"]))){
        $admin_code_err = "Voer alstublieft de admin code in.";
    } else{
        $admincode = trim($_POST["admin_code"]);
        if ($admincode == '20232023'){
            $admincodevalidated = true;
        } else {
            $admin_code_err = "Verkeerde admin code.";
        }
    }

    if(empty($username_err) && empty($password_err) && empty($confirm_password_err) && ($admincodevalidated == true)){

        $sql = "INSERT INTO brbtusers (username, password) VALUES (?, ?)";

        if($stmt = mysqli_prepare($conn, $sql)){
            mysqli_stmt_bind_param($stmt, "ss", $param_username, $param_password);

            $param_username = $username;
            $param_password = password_hash($password, PASSWORD_DEFAULT);

            if(mysqli_stmt_execute($stmt)){
                header("location: signIn.php");
            } else{
                echo "Er is iets mis gegaan. Probeer het later opnieuw";
            }

            mysqli_stmt_close($stmt);
        }
    }

    mysqli_close($conn);
}
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Register - BarberTime</title>
    <link rel="stylesheet" href="style.css">
</head>
<?php require_once "header.php"; ?>
<body>

<div class="FormContainer" style="margin-bottom: 160px;">
    <form action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>" method="post">
        <div class="form-labels" style="border: inherit">
            <b><label for="username">Gebruikersnaam:</label></b><br>
            <input type="text" name="username" required class="form-labels" value="<?php echo $username; ?>">
            <span class="errorcodes"><?php echo $username_err; ?></span><br>
            <b><label for="email">Email:</label></b><br>
            <input type="email" name="email" required class="form-labels"><br>
            <b><label for="password">Wachtwoord:</label></b><br>
            <input type="password" name="password" required class="form-labels" value="<?php echo $password; ?>">
            <span class="errorcodes"><?php echo $password_err; ?></span><br>
            <b><label for="confirm_password">Bevestig wachtwoord:</label></b>
            <input type="password" name="confirm_password" required class="form-labels" value="<?php echo $confirm_password; ?>">
            <p>Helaas is het momenteel alleen mogelijk om een account aan te maken voor werknemers. (voor demonstratie: gebruik code 20232023)</p>
            <b><label for="admin_code">Administrator code:</label></b>
            <input type="password" name="admin_code" required class="form-labels">
            <span class="errorcodes"><?php echo $admin_code_err; ?></span><br><br>
            <button class="button addButton" type="submit" name="submit" value="Registreer">Registreer</button><br><br>
            <label for="klik hier">Heb je al een account? <a style="color: dodgerblue" href="signIn.php">klik hier</a></label><br>
        </div>
    </form>
</div>
</body>
</html>