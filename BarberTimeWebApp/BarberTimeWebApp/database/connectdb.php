<?php
 $conn = new mysqli('localhost', 'root', '', 's151965_BarberTime'); //localhost connectie
 ////////// Real database connection removed ///////////
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
  }
  $conn -> set_charset("utf8");
  ?>
