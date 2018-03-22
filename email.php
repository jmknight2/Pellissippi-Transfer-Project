<?php
//Author: Zachary Mitchell
/*this is designed to be a flexible method of constructing a custom html file with a truckload of json values :P
It also saves this to a specified file, then sends it off as an email with the help of an external program.
*/

$GLOBALS['fileName'] = './emailClient/default.html';
$GLOBALS['emailCommand'] = 'cd emailClient && cliEmail.exe';

function sendEmail($json,$usePdf = true){
    //The three parts of the message: the head and foot are the top and bottom of the page, and the body is generated for each transfer object in the json string.
    $head = file('./emailClient/head.html');
    $body = file('./emailClient/body.html');
    $foot = file('./emailClient/foot.html');
    $json = json_decode($json,true);
    $total='';
    $longestKeyLength = 0;

    if($usePdf)
        $GLOBALS['emailCommand'].=' -files transferlist.pdf';

    //Lets find the longest key so that the searching process can go faster:
    //(We assume that all json files are the same)
    foreach($json[0] as $key => $element){
        if(strlen($key) > $longestKeyLength)
            $longestKeyLength = strlen($key);
    }

    //Inserting the head:
    $total.=keyParser($json,$longestKeyLength,0,$head);
    
    //body:
    for($jsonIter = 0;$jsonIter < count($json);$jsonIter++){
        $total.=keyParser($json,$longestKeyLength,$jsonIter,$body);
    }
    //The foot:
    $total.=implode($foot,"\n");


    //aaaaalrighty; we should have everything... Let's send it! (then delete it)
    file_put_contents($GLOBALS['fileName'],$total);
    exec($GLOBALS['emailCommand']);
    unlink($GLOBALS['fileName']);
    if($usePdf)
    unlink('./emailClient/transferlist.pdf');
    //echo $total;
    }

    //This is the core parser for scanning json keys:
    function keyParser(&$json,$longestKeyLength,$jsonIter,$htmlArray){
        $result='';
        for($i=0;$i<count($htmlArray);$i++){
            for($j=0;$j<strlen($htmlArray[$i]);$j++){
                if($htmlArray[$i][$j] == "@"){
                    //retrieve the string based on the longest string count:
                    $snippit = '';
                    for($k = 0;$k<$longestKeyLength;$k++){
                        $snippit.=$htmlArray[$i][$j + $k + 1];
                    }
                    //Let's do an extensive search!
                    $key='';
                    if($key = keyEval($snippit,$json[$jsonIter])){ //This is NOT a comparison error: the alternitave is if $key turns into null after this function is run.
                        $result.=$json[$jsonIter][$key];
                        $j+=strlen($key);
                    }
                    else $result.=$htmlArray[$i][$j];    
                }
                else $result.=$htmlArray[$i][$j];
            }
            $result.="\n";
        }

        return $result;
    }

    //This function searches a given snippet, and if it matches a key, it returns that key. It otherwise returns null;
    function keyEval($snippit, &$jsonArray){
        //We're kindof forced to recreate a new string each time since we're going backwards to find the longest string:
        $subtraction = 0;
        $currKey = '';

        for($i=strlen($snippit);$i>0;$i--){
            //Create/Re-create currKey:
            $currKey = '';
            for($j=0;$j<$i;$j++){
                $currKey.=$snippit[$j];
            }

            //Let's get to the beef: actually searching through keys:
            foreach($jsonArray as $key => $element){
                if($key == $currKey){
                    return $currKey;
                }
            }
        }
        return null;
    }
?>