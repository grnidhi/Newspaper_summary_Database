<?php

    $servername="localhost";
    $username="root";
    $password="";
    $dbname="bugle-crunch";
    $tablename="article";

    $title = $_POST['title'];
    $desc = $_POST['desc'];
    $category = $_POST['category'];
    $approved = "0";
    $photoURL = "";
    $jid = $_POST['jid-post'];

    //file upload
    $target_dir = "./../uploads/";  // location of the file
    $target_file = $target_dir . basename($_FILES["photo"]["name"]);
    $filename = basename($_FILES["photo"]["name"]);
    $uploadOk = 1;
    $imageFileType = strtolower(pathinfo($target_file,PATHINFO_EXTENSION));
    $size_limit = 5000000;

    $conn = new mysqli($servername,$username,$password,$dbname);

        // Check if image file is a actual image or fake image
    if(isset($_POST["submit"])) {
      $check = getimagesize($_FILES["photo"]["tmp_name"]);
      if($check !== false) {
        $uploadOk = 1;
      } else {
        $uploadOk = 0;
      }
    }

    if (file_exists($target_file)) {
        echo "Sorry, file already exists.";
        $uploadOk = 0;
    }

    if ($_FILES["photo"]["size"] > $size_limit) {
        echo "Sorry, your file is too large.";
        $uploadOk = 0;
    
    }
    if($uploadOk==0){
        echo "File upload error";
    }
    else{
        if(move_uploaded_file($_FILES["photo"]["tmp_name"], $target_file)){
            $query="insert into $tablename (title,description,category,jid,approved,photoURL) values('$title','$desc','$category','$jid',$approved,'./../uploads/$filename')";
            if($conn->query($query)){
                header("Location:http://localhost/proj/php/articleAdmin/display.php");
            }
            else{
                echo "failure!";
            }
        }
        else{
            echo "file error";
        }
    }
    $conn->close();

?>