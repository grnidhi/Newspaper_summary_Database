<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Oswald:wght@300;500&display=swap" rel="stylesheet">
    <style>
        body{
            background-color:#F1E6D6;
        }
        .main-display{
            padding-top:100px;
            padding-bottom:200px;
            display:flex;
            justify-content:center;
        }
        table{
            width:80%;
        }
        table td{
            border:black 2px solid;
            text-align:center;
            height:100px;
            padding-inline:10px;

        }
        table th{
            border:black 2px solid;
            text-align:center;
            font-weight:800;
            padding-inline:20px;

        }


    </style>
    <title>Display Users</title>
</head>
<body>

    <section class="main-display">
    <table class="display-table">
        <tr>
            <th>UID</th>
            <th>NAME</th>
            <th>EMAIL</th>
            <th>PASSWORD</th>
            <th>DOB</th>
            <th>PHONE_NO</th>
            <th>PREFERENCES</th>
            <th>GENDER</th>
        </tr>
    <?php
            $servername="localhost";
            $username="root";
            $password="";
            $dbname="bugle-crunch";
            $tablename="user";
            $query="select * from $tablename";

            $conn=new mysqli($servername,$username,$password,$dbname);

            if($conn){
                $res=$conn->query($query);
                while($row=$res->fetch_array()){

                    echo "<tr>";
                    echo "<td>$row[0]</td>";
                    echo "<td>$row[1]</td>";
                    echo "<td>$row[2]</td>";
                    echo "<td>$row[3]</td>";
                    echo "<td>$row[4]</td>";
                    echo "<td>$row[5]</td>";
                    echo "<td>$row[6]</td>";
                    echo "<td>$row[7]</td>";
                    echo "</tr>";

                }
            }
            $conn->close();
    ?>
    </table>

    </section>


</body>
</html>