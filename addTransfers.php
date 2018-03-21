<?php
/**
 * Created by PhpStorm.
 * User: Jacob Simms
 * Date: 3/1/2018
 * Time: 8:40 PM
 */
//include 'db_connection.php';
include 'phpFunctions.php';
require 'fpdf/wordwrap.php';

//DB Connection
$dbCon=connectToDB();

//tblTransTemp
$Tech = ''; //tech making the move
$Date = ''; //date of transaction
$Tag = ''; //Pellissippi Asset tag number
$Model = ''; //model number
$From = ''; //previous room
$Previous = ''; //previous owner
$DeptFrom = ''; //previous department
$To = ''; //new room
$New = ''; //new owner
$NewOwnerPnum = ''; //new owners P number
$DeptTo = ''; //new department
$Notes = ''; //Notes
$Instance = ''; //transfer number ????? maybe serial number
$InstanceID = ''; //??????
$Submit = ''; //????????
$Hold = ''; // YES or NO are the only answers allowed

//JSON Parsing and SQL insert statement string creator.
   if (isset($_GET['json'])){
     $json=json_decode($_GET['json'], true);
     if ( is_array( $json )) {
         $arraySize = count($json);
         for ($i = 0; $i < $arraySize; $i++) 
		 {

             $Tech = 'You are';
             //$Date = date(date_timestamp_get())      // figure out how to get data and time
             $Tag = $json[$i]['itemID'];
             $Model = $json[$i]['model'];
             $From = $json[$i]['preRoom'];
             $Previous = $json[$i]['preOwner'];
             $DeptFrom = $json[$i]['preDept'];
             $To = $json[$i]['newRoom'];
             $New = $json[$i]['newOwner'];
             $NewOwnerPnum = '';    //pnumLookUp($dbCon, $json[$i]['newOwner']);
             $DeptTo = $json[$i]['newDept'];
             $Notes = $json[$i]['notes'];
             $Instance = $i + 1;
             $InstanceID = $i + 1;
             $Submit = '';
             $Hold = 'Yes';

             $sql =  "INSERT INTO tblTransTemp(Tech, Tag, Model, [From], Previous, DeptFrom, [To], New, NewOwnerPnum, DeptTo, Notes, Instance, InstanceID, Submit, Hold) VALUES ('".$Tech."', '".$Tag."','".$Model."','".$From."','".$Previous."','".$DeptFrom."','".$To."','".$New."','".$NewOwnerPnum."','".$DeptTo."','".$Notes."','".$Instance."','".$InstanceID."','".$Submit."',".$Hold.");";

             //echo $New . '    '.$NewOwnerPnum;

             insertTransfers($dbCon, $sql);
			 generatePDF($json);
         }
     } else {
         echo "ERROR in the is_array if statement.";
     }
   } else {
       echo "No transfers to add";
}

function insertTransfers($con, $insertString) {

    //echo $insertString;
    odbc_exec($con, $insertString);
    if (odbc_error())
        echo odbc_errormsg($con);
	
	else echo "Records added successfully";
}

function pnumLookUp($con, $newName) {

       $pNumNew = "SELECT [ID] FROM dbo_tblCustodians where [NAME] = '".$newName."';";
       $pNumAnsr = odbc_exec($con, $pNumNew);

       //for ($i = 1; $i <= 6; $i++)
		   
	   
       echo $pNumAnsr[0]['ID'];
	   
       //print_r( $pNumAnsr[1]);
	   
       return $pNumAnsr;
}

function generatePDF($jsonArr)
{
	$pdf = new FPDF();
	$pdf->AddPage();
	$pdf->SetFont('Arial','B',6);
	
	$header = array('Tag', 'Model', 'From', 'Previous', 'DeptFrom', 'To', 'New', 'DeptTo', 'Notes');
	
	FancyTable($pdf, $header, $jsonArr);
	
	$pdf->Output("transferlist.pdf", "F");
	
	if(!file_exists("transferlist.pdf"))
	{
		echo "Failed to create pdf file.";
	}
}

function FancyTable($pdf, $header, $data)
{
    // Colors, line width and bold font
    $pdf->SetFillColor(0,75,142);
    $pdf->SetTextColor(255);
    $pdf->SetDrawColor(128,0,0);
    $pdf->SetLineWidth(.3);
    $pdf->SetFont('','B');
	
    // Header
    $w = array(40, 35, 40, 45);
    for($i=0;$i<count($header);$i++)
        $pdf->Cell(20,7,$header[$i],1,0,'C',true);
    $pdf->Ln();
	
    // Color and font restoration
    $pdf->SetFillColor(224,235,255);
    $pdf->SetTextColor(0);
    $pdf->SetFont('');
	
    // Data
    $fill = false;
    foreach($data as $row)
    {
		foreach($row as $col)
			$pdf->Cell(20,6,WordWrap($col, 1),'LRB',0,'L',$fill);
			
		$pdf->Ln();
		$fill = !$fill;
    }
    // Closing line
    $pdf->Cell(array_sum($w),0,'','T');
}


?>