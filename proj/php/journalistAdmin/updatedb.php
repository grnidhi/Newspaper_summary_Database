<?php
	$conn=mysqli_connect("localhost","root","","bugle-crunch");
	if($conn)
		echo "Connection was successfull";
	else
	{
		echo "Connection failed";
		exit();
	}
	$n=$_POST["name"];
	$a=$_POST["age"];
	$em=$_POST["email"];
	$phn=$_POST["phnone"];
	$lang=$_POST["lang"];
	$exper=$_POST['expertise'];
	$exper1=implode("," ,$exper);
	$quali=$_POST["qual"];
	$i=$_POST["id"];
	$q1="UPDATE journalist set j_name='$n',age='$a',email_id='$em',phone_no='$phn',language='$lang',expertise='$exper1',qualification='$quali' where jid=$i";
	$r1=mysqli_query($conn,$q1);
	if($r1)
		echo "<br>Updation successfull";
	else
	{
		echo "<br>Updation unsuccessfull";
	}
	mysqli_close($conn);
	

?>