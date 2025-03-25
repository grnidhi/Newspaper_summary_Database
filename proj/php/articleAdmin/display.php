<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Oswald:wght@300;500&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="./styles/global.css">
    <style>
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
            border:var(--primary-dark) 2px solid;
            text-align:center;
            height:100px;
            padding-inline:10px;

        }
        table th{
            border:var(--primary-dark) 2px solid;
            text-align:center;
            font-weight:800;
            padding-inline:20px;

        }
        footer{
            position:fixed;
            bottom:0;
        }
    </style>
    <title>Display Article</title>
</head>
<body>
<?php include("./components/header.php")
    ?>
    <section class="main-display">
    <table class="display-table">
        <tr>
            <th>Article ID</th>
            <th>Title</th>
            <th>Description</th>
            <th>Date</th>
            <th>Category</th>
            <th>Journalist Id</th>
            <th>Approved</th>
            <th>Editor Id</th>
            <th>PhotoURL</th>
        </tr>
    <?php
            $servername="localhost";
            $username="root";
            $password="";
            $dbname="bugle-crunch";
            $tablename="article";
            $query="select * from $tablename";

            $conn=new mysqli($servername,$username,$password,$dbname);

            if($conn){
                $res=$conn->query($query);
                while($row=$res->fetch_array()){
                    $eid=$row[7]?"$row[7]":"not checked";
                    echo "<tr>";
                    echo "<td>$row[0]</td>";
                    echo "<td>$row[1]</td>";
                    echo "<td>$row[2]</td>";
                    echo "<td>$row[3]</td>";
                    echo "<td>$row[4]</td>";
                    echo "<td>$row[5]</td>";
                    echo "<td>$row[6]</td>";
                    echo "<td>$eid</td>";
                    echo "<td>$row[8]</td>";
                    echo "</tr>";

                }
            }
            $conn->close();
    ?>
    </table>

    </section>

<?php include("./components/footer.php")
    ?>
</body>
</html>