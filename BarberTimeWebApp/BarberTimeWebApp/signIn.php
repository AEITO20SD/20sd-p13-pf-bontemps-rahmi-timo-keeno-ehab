<?php
session_start();

if(isset($_SESSION["loggedin"]) && $_SESSION["loggedin"] === true){
    header("location: dataview.php");
    exit;
}

require_once "database/connectdb.php";

$username = $password = "";
$username_err = $password_err = "";

if($_SERVER["REQUEST_METHOD"] == "POST"){

    if(empty(trim($_POST["username"]))){
        $username_err = "Voer alstublieft een Gebruikersnaam in.";
    } else{
        $username = trim($_POST["username"]);
    }

    if(empty(trim($_POST["password"]))){
        $password_err = "Voer alstublieft uw Wachtwoord in.";
    } else{
        $password = trim($_POST["password"]);
    }

    if(empty($username_err) && empty($password_err)){
        $sql = "SELECT id, username, password FROM brbtusers WHERE username = ?";

        if($stmt = mysqli_prepare($conn, $sql)){
            mysqli_stmt_bind_param($stmt, "s", $param_username);

            $param_username = $username;

            if(mysqli_stmt_execute($stmt)){
                mysqli_stmt_store_result($stmt);

                if(mysqli_stmt_num_rows($stmt) == 1){

                    mysqli_stmt_bind_result($stmt, $id, $username, $hashed_password);
                    if(mysqli_stmt_fetch($stmt)){
                        if(password_verify($password, $hashed_password)){
                            session_start();

                            $_SESSION["loggedin"] = true;
                            $_SESSION["id"] = $id;
                            $_SESSION["username"] = $username;

                            header("location: dataview.php");
                        } else{
                            $password_err = "Het Wachtwoord is incorrect";
                        }
                    }
                } else{
                    $username_err = "Er is geen account gevonden met deze Gebruikersnaam.";
                }
            } else{
                echo "Oeps, er is iets mis gegaan. Probeer het later opnieuw.";
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
    <title>Login - BarberTime</title>
    <link rel="stylesheet" href="style.css">
</head>
<?php require_once "header.php"; ?>
<body>

<div class="FormContainer" style="margin-bottom: 280px;">
    <div class="form-labels" style="border: inherit">
        <form action="<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?>" method="post">
            <label for="username"><b>Gebruikersnaam:</b></label><br>
            <input type="text" name="username" required class="form-labels" value="<?php echo $username; ?>"><br><br>
            <span class="errorcodes"><?php echo $username_err; ?></span><br>
            <b><label for="password">Wachtwoord:</label></b><br>
            <input type="password" name="password" required class="form-labels"><br>
            <span class="errorcodes"><?php echo $password_err; ?></span><br>
            <button class="button addButton" type="submit" value="Inloggen">Inloggen</button><br><br>
            <label for="klik hier">Heeft u nog geen account? <a style="color: dodgerblue" href="createAccount.php">Registreer</a></label><br>
        </form>
    </div>
</div>
</body>
</html>
