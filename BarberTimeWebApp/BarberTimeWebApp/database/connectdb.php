<?php
 $conn = new mysqli('localhost', 'root', '', 's151965_BarberTime'); //localhost connectie
//$conn = new mysqli('localhost', 's151965', 'Jaden88', 's151965_barbertime'); //Ao-Alkmaar connectie
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
  }
  //echo "Connected successfully";
  $conn -> set_charset("utf8");
  ?>
