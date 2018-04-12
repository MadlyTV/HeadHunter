<?php

$mysql_server = "";

$mysql_username = "";

$mysql_password = "";

$mysql_db = "";

$conn = new mysqli($mysql_server, $mysql_username, $mysql_password, $mysql_db);

if ($conn->connect_error){
    die("Connection failed: " . $conn->connect_error);
}

$userid = $_REQUEST['userid'];

$sql = "SELECT * FROM `warns` WHERE `UserID` = $userid";
$result = $conn->query($sql);

if ($result->num_rows > 0){
    $sql = "UPDATE `warns` SET `NumberOfWarns` = `NumberOfWarns` + 1 WHERE `UserID` = $userid";
    if ($conn->query($sql)===true){
        echo "Record updated successfully";
    } else {
        echo "Error updating record: " . $conn->error;
    }
}
else {
    $sql = "INSERT INTO `warns` (`ID`, `UserID`, `NumberOfWarns`) VALUES (NULL, $userid, '1')";

    if ($conn->query($sql) === TRUE) {
        echo "New record created successfully";
    } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
    }
}

$conn->close();

?>