<?php
    $servername="localhost";
    $username="root";
    $password="";
    $dbname="bugle-crunch";
    $tablename="article";

    $category=$_POST["category"];
    $searchStr=$_POST["search-str"];

    $query="select * from article where $category like '*$searchStr*'";
    $conn=new mysqli($servername,$username,$password,$dbname);

    if($conn){
        echo json_encode(array("code"=>0,"body":array()));
        exit(0);
    }else{
        $res=$conn->query($query);
        $body;
        while($r=$res->fetch_assoc()){
            array_push($body,$r);
        }
        echo json_encode(array("code"=>1,"body"=>"hello"));
    }
?>