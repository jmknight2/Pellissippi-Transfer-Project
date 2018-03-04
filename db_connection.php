<?php
/**
 * Created by PhpStorm.
 * User: Jacob Simms
 * Date: 3/1/2018
 * Time: 8:37 PM
 */

function connectToDB()
{
    //make odbc connection to MSaccess DB
    $con = odbc_connect("PPDB", "", "");

    if(!($con))
    {
        echo "Failed to connect to Access DB<br/><br/>";
        return false;
    }

    else return $con;
}
?>