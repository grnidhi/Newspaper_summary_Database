<?php

    $servername="localhost";
    $username="root";
    $password="";
    $dbname="bugle-crunch";
    $tablename="article";

    $uid=$_POST["uid"];
    $name=$_POST["name"];
    $email=$_POST["email"];
    $pass=$_POST["password"];
    $date=$_POST["date"];
    $pno=$_POST["pno"];
    $pref=implode(",",$_POST["pref"]);
    $gender=$_POST["gender"];

    $query="update user set name='$name',email='$email',password='$pass',dob='$date',phone_no='$pno',preferences='$pref',gender='$gender' where uid=$uid";

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