<?php
        $servername="localhost";
        $username="root";
        $password="";
        $dbname="bugle-crunch";

        $query = "select * from article";

        $count = 3;

        $conn=new mysqli($servername,$username,$password,$dbname);

        if($conn->connect_error){
            die("Connectin failed : ".$conn->connect_error);
        }

        $result = $conn->query($query);
        $i=0;
        $rows = [];

        if($result->num_rows>0 && $count<=$result->num_rows){
            while($i<$count){
                $row=$result->fetch_assoc();
                array_push($rows,$row);
                $i=$i+1;
            }
        }else{
            echo "null";
        }

        
        echo json_encode($rows);

        $conn->close();

?>