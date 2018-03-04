<?php
/**
 * Created by PhpStorm.
 * User: Jacob Simms
 * Date: 3/1/2018
 * Time: 8:40 PM
 */
include 'db_connection.php';

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
         foreach($json as $string) {
             $i=0;
             $Tech = 'You are';
             //$Date = date(date_timestamp_get())      // figure out how to get data and time
             $Tag = $json[$i]['itemID'];
             $Model = $json[$i]['model'];
             $From = $json[$i]['preRoom'];
             $Previous = $json[$i]['preOwner'];
             $DeptFrom = $json[$i]['preDept'];
             $To = $json[$i]['newRoom'];
             $New = $json[$i]['newOwner'];
             $NewOwnerPnum = '';
             $DeptTo = $json[$i]['newDept'];
             $Notes = $json[$i]['notes'];
             $Instance = $i + 1;
             $InstanceID = $i + 1;
             $Submit = '';
             $Hold = 'Yes';

             $sql =  "INSERT INTO tblTransTemp(Tech, Tag, Model, [From], Previous, DeptFrom, [To], New, NewOwnerPnum, DeptTo, Notes, Instance, InstanceID, Submit, Hold) VALUES ('".$Tech."', '".$Tag."','".$Model."','".$From."','".$Previous."','".$DeptFrom."','".$To."','".$New."','".$NewOwnerPnum."','".$DeptTo."','".$Notes."','".$Instance."','".$InstanceID."','".$Submit."',".$Hold.")";

             insertTransfers($sql);
         }
     } else {
         echo "ERROR in the is_array if statement.";
     }
   } else {
       echo "No transfers to add";
}

function insertTransfers($uname) {
    $con=connectToDB();

    //$sql = "INSERT INTO dbo_tblCustodians(ID, NAME, FFBMAST_CUSTODIAN_PIDM) VALUES ('P1234567', '" . $uname ."', 12345)";
echo $uname;
    odbc_exec($con,$uname);

}

?>