<?php
	$conn=mysqli_connect("localhost","root","","bugle-crunch");
	if($conn)
		echo "Connection was successfull";
	else
	{
		echo "Connection failed";
		exit();
	}
	$i=$_POST["uid"];
    
	$q1="DELETE FROM user where uid=$i";
	$r1=mysqli_query($conn,$q1);
	if($r1)
		echo "<br>Deletion successfull";
	else
	{
		echo "<br>Deletion unsuccessfull";
		exit();
	}
	mysqli_close($conn);
	
?>