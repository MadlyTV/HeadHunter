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
    while($row = $result->fetch_assoc()){
        echo "[ID] " . $row["ID"] . "<br>";
        echo " [NumberOfWarns] " . $row["NumberOfWarns"];
    }
}
else {
    echo "0 results";
}

$conn->close();

?>