<?php

    $servername="localhost";
    $username="root";
    $password="";
    $dbname="bugle-crunch";   
    
    $query = "select * from journalist where jid=".$_POST["jid"];

    $conn=new mysqli($servername,$username,$password,$dbname);

    if($conn->connect_error){
        die("Connectin failed : ".$conn->connect_error);
    }

    $result = $conn->query($query);
    
    if($result->num_rows>0){
        while($row=$result->fetch_assoc()){
            echo json_encode(array("code"=>"1","body"=>$row));
        }

    }else{
        echo json_encode(array("code"=>"0","message"=>"There is no person with jid = ".$_POST['jid']));
    }

?>

