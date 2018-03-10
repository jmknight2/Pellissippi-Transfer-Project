//Barcode Scanning by: QuaggaJS!!
//File author: Zachary Mitchell (2018)

//I take absolutely no credit for actually SCANNING barcodes, it was done by the awesome api from github. In this file, I'm simply piloting the blimp.

//First things first. We generate the file input tag, which is "clicked" when scan() is run.
//This is done so that we can implement the scanner as easy as possible, with little to no setup:
document.body.innerHTML+='<input id="ScannerJS" type="file" accept="image/*" style="display:none"/>';

//This activates bgGo(), and expects the output variable to be an "input" tag.
//Why have this function? It allows an image request in virtually any scenario, not just when the user clicks on an input tag.
function scan(output){
    if(output == undefined)
         console.error("scan(): Please specifiy the insert tag you wish to output the barcode to.");
    else{
        var newFile=document.getElementById("ScannerJS");
        newFile.onchange=function(){bgGo(output);};
        newFile.click();
    }
}

//launches the scanner, and if successful, places the result inside "value" attribute of inputTag.
//WARNING! Anything in inputTag.value will be OVERWRITTEN!
function bgGo(inputTag){

    //QuaggaJS:
    Quagga.decodeSingle({
        decoder:{
        readers:["code_128_reader","ean_reader", "ean_8_reader"]
        },
        src: URL.createObjectURL(document.getElementById("ScannerJS").files[0])
  }, function(data) {
      if (data) {
          inputTag.value=data.codeResult.code.split(' ');
          return
      }
      else
        alert("Barcode not found... Please try again.");
  });
}
