<html>
	<head>
		<title>Search</title>
		<style>
			        body {
            font-family: Arial, sans-serif;
            text-align: center;
        }

        table {
            width: 80%;
            margin: 20px auto; /* Center the table on the page */
            border-collapse: collapse;
        }

        table, th, td {
            border: 1px solid #ddd;
        }

        th, td {
            padding: 12px;
            text-align: left;
        }

        th {
            background-color: #f2f2f2;
        }
		</style>
	</head>
	<body>
		

	<?php
	$conn=mysqli_connect("localhost","root","","bugle-crunch");
	if($conn)
		echo "Connection was successfull";
	else
	{
		echo "Connection failed";
		exit();
	}
	$edid=$_POST["editorid"];
	$q1="SELECT * FROM editor where eid='$edid'";
	$r1=mysqli_query($conn,$q1);
	echo"<table border=1>";
			echo "<tr>";
			echo "<th>"; echo "E_ID"; echo "</thn>";
			echo "<th>"; echo "NAME"; echo "</thn>";
			echo "<th>"; echo "PH_NO"; echo "</thn>";
			echo "<th>"; echo "DOJ"; echo "</thn>";
			echo "<th>"; echo "EXPERIENCE"; echo "</thn>";
			echo "<th>"; echo "DOMAIN"; echo "</thn>";
			echo "</tr>";
		while($info=mysqli_fetch_assoc($r1))
		{
				echo "<tr>";
				echo "<td>"; echo $info["eid"]; echo "</td>";
				echo "<td>"; echo $info["name"]; echo "</td>";
				echo "<td>"; echo $info["date"]; echo "</td>";
				echo "<td>"; echo $info["phone"]; echo "</td>";
				echo "<td>"; echo $info["exp"]; echo "</td>";
				echo "<td>"; echo $info["domain"]; echo "</td>";
				echo "<tr>";
		}
	echo "</table>";
	mysqli_close($conn);
?>

	</body>
</html>





