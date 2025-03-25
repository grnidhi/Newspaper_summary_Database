<?php
	$conn=mysqli_connect("localhost","root","","bugle-crunch");
	if($conn)
		echo "Connection was successfull";
	else
	{
		echo "Connection failed";
		exit();
	}
	$q1="SELECT * FROM journalist";
	$r1=mysqli_query($conn,$q1);
	$n=mysqli_num_rows($r1);
	if($n!=0)
	{
		echo "<br>Total no of rows are:".$n;
	}
	else
	{
		echo "<br>No records Found";
	}
	$i=1;
	if($r1)
	{
		echo "<table border=1>";
		echo "<tr>";
		echo "<th>"; echo "Journalist_name"; echo "</thn>";
		echo "<th>"; echo "Age"; echo "</thn>";
		echo "<th>"; echo "Email_id"; echo "</thn>";
		echo "<th>"; echo "Phone_no"; echo "</thn>";
		echo "<th>"; echo "Language"; echo "</thn>";
		echo "<th>"; echo "Expertise"; echo "</thn>";
		echo "<th>"; echo "Qualification"; echo "</thn>";
		echo "</tr>";
		while($info=mysqli_fetch_assoc($r1))
		{
			echo "<tr>";
			echo "<td>"; echo $info["j_name"]; echo "</td>";
			echo "<td>"; echo $info["age"]; echo "</td>";
			echo "<td>"; echo $info["email_id"]; echo "</td>";
			echo "<td>"; echo $info["phone_no"]; echo "</td>";
			echo "<td>"; echo $info["language"]; echo "</td>";
			echo "<td>"; echo $info["expertise"]; echo "</td>";
			echo "<td>"; echo $info["qualification"]; echo "</td>";
            echo "</tr>";
		}
		echo "</table>";
	}
	mysqli_close($conn);
?>