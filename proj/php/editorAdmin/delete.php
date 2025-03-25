<?php
	$i=$_POST["id"];
	
	
	echo"<br>editor id:".$i;
	
	$conn=mysqli_connect("localhost","root","","bugle-crunch");
	if($conn)
	echo"connetion to db successfull";
	else
	{
		echo"connetion failed";
		exit(0);
	}
	
	$q1="delete from editor where eid=$i";
	$r1=mysqli_query($conn,$q1);
	if($r1)
		echo"deletion successfull";
	else
		echo"<br>deletion failed:";
	
	mysqli_close($conn);
?>