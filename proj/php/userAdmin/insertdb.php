<?php

    $servername="localhost";
    $username="root";
    $password="";
    $dbname="bugle-crunch";

    $name=$_POST["name"];
    $email=$_POST["email"];
    $pass=$_POST["password"];
    $date=$_POST["date"];
    $pno=$_POST["pno"];
    $pref=implode(",",$_POST["pref"]);
    $gender=$_POST["gender"];

    $query="insert into user (name,email,password,dob,phone_no,preferences,gender) values ('$name','$email','$pass','$date','$pno','$pref','$gender')";

    $conn = new mysqli($servername,$username,$password,$dbname);


    if(!$conn){
        die("error");
        exit(0);
    }else{
        $result=$conn->query($query);
        if($result){
            echo "success!";
        }
        else{
            echo "failure";
        }

    }
        // Check if image file is a actual image or fake image

    $conn->close();

?>