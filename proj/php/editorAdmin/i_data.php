<?php
	$conn=mysqli_connect("localhost","root","","bugle-crunch");
	if($conn)
		echo "Connection was successfull";
	else
	{
		echo "Connection failed";
		exit();
	}
	$fname=$_POST["fname"];
    $lname=$_POST["lname"];
    $nameArr =array($fname,$lname);

    $name=implode(" ",$nameArr);
    $date=$_POST["date"];
    $phone=$_POST["phone"];
    $exp=$_POST["exp"];
    $domain=$_POST["domain"];


	$q1="INSERT INTO editor (name,date,phone,exp,domain) VALUES ('$name','$date','$phone','$exp','$domain')";
	$r1=mysqli_query($conn,$q1);
	if($r1)
		echo "<br>Insertion successfull";
	else
	{
		echo "<br>Insertion unsuccessfull";
	}
	mysqli_close($conn);
	

?>