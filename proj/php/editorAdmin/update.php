<?php
	
	$conn=mysqli_connect("localhost","root","","bugle-crunch");
	if($conn)
		echo"connetion successfull";
	else
	{                              
		echo"connetion failed";
		exit(0);
	}
	$n=$_POST["name"];
	$p=$_POST["Phone"];
	$ex=$_POST["exp"];
	$do=$_POST["domain"];
    $date=$_POST["date"];
    $edid=$_POST["editorid"];
	
	echo  "<br>";
	
	
	$q1="UPDATE editor SET name='$n',phone=$p,exp='$ex',date='$date',domain='$do' WHERE eid=$edid";

	$r1=mysqli_query($conn,$q1);
	if($r1)
		echo"Updated successfully";
	else
		echo"search failed";

?>





