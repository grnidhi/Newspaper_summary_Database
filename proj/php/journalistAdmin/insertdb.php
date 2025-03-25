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

	$q1="INSERT INTO journalist (J_name,age,email_id,phone_no,language,expertise,qualification) VALUES ('$n',$a,'$em','$phn','$lang','$exper1','$quali')";
	$r1=mysqli_query($conn,$q1);
	if($r1)
		echo "<br>Insertion successfull";
	else
	{
		echo "<br>Insertion unsuccessfull";
	}
	mysqli_close($conn);
	

?>