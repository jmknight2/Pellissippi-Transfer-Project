<?php

function connectToDB()
{
	//make odbc connection to MSaccess DB
	$con = odbc_connect("ProjDB", "", "");

	if(!($con))
	{
		echo "Failed to connect to Access DB<br/><br/>";
		return false;
	}
	
	else return $con;
}

function queryDB($con, $query)
{	
	$result=odbc_exec($con, $query);
	$rows = array();
	
	while ($row=odbc_fetch_array($result)) 
	{
		$rows[] = $row;
	}
	
	return $rows;
}

function testQuery($con, $query)
{
	$result=odbc_exec($con, $query);
	$rows = array();
	
	while ($row=odbc_fetch_array($result)) 
	{
		$rows[] = $row;
	}
	
	foreach($rows as $row1)
		foreach($row1 as $value)
			echo $value;
}

function getInfo($id)
{
	// lookup all hints from array if $q is different from "" 
	if ($id !== "") 
	{
		$query= "SELECT * FROM [Complete Active inventory list 52914] WHERE TAG = '$id'";
		echo "this is a test";
	}
}

function checkForID($id, $con)
{
	// lookup all hints from array if $q is different from "" 
	if ($id !== "") 
	{
		$query = "SELECT * FROM [Complete Active inventory list 52914] WHERE TAG = '$id'";
		$result = queryDB($con, $query);
		
		if(count($result) > 0)
		{
			echo $result[0]['Model'] . "," . $result[0]['Location'] . "," . $result[0]['Custodian'];
		}
		
		else echo "error";
	}
	
	else echo false;
}

$con1 = connectToDB();

if(isset($_REQUEST["q"]))
{
	$id = $_REQUEST["q"];
	checkForID($id, $con1);
}

?>



