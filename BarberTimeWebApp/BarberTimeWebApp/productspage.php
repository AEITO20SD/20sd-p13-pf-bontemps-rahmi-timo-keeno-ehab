<?php include "database/connectdb.php";

$sql = "SELECT * FROM `products`";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    ?>
    <div class="productBox"><a href="productInfo.php?Id=<?php echo $row["Id"]; ?>">
      <div class="imageBox">
        <?php if ($row['Image'] == "") {?>
          <img class="productImage" src="images/NoImage.jpg"><br>
          <?php
        } else { ?>
          <img class="productImage" src="data:image/jpg;charset=utf8;base64,<?php echo ($row['Image']); ?>"><br>
        <?php }?>        
      </div>
      <div class="lowerProductBox">
        <p class="textProductBox"><b><?php echo $row["Name"]; ?></b></p>
        <div class="priceAndCart">
        <p class="textProductBox" style="flex: 1;"><b>€‎</b><?php echo $row["Euro"]; ?>,<?php $cents = $row["Cents"];
        if ($cents == "0" || $cents == "00") {
          $cents = "-";
        }
        echo $cents; ?></p>
        <a href="#" class="addItemToCartButton"><img class="addItemToCartButton" src="images/shoppingcartbutton.png" alt=""></a>
        </div>
      </div>
    </div>
    </a>
    <?php
  }
} else {
  echo "Something went wrong...";
}
$conn->close();
?>
