<?php
     $servername="localhost";
     $username="root";
     $password="";
     $dbname="bugle-crunch";
     $tablename="article";
     $aid=$_POST["aid"];
     $photoURL="";

     $check="select aid,photoURL from $tablename where aid=$aid";
     $query="delete from $tablename where aid=$aid";

     $conn=new mysqli($servername,$username,$password,$dbname);

     if(!$conn){
        die("Server error");
     }else{
        $res=$conn->query($check);
        if($res->num_rows==0){
                echo "Article id $aid does not exist";
        }else{
            //get the file name to delete from the uploads folder
            $photoURL=$res->fetch_assoc()["photoURL"];
            $filename=basename($photoURL);

            $r=$conn->query($query);
            if($r){
                unlink("./../uploads/$filename");
                header("Location:http://localhost/proj/php/articleAdmin/display.php");
            }else{
                echo "error from server";
            }
        }

     }
     $conn->close();
?>