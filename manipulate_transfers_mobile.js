// Written by: Jon Knight
// Date last modified: 2/12/18
// Dependencies: mobile.html

var transfersArray = [];
var selectedTransferID;

function refreshList()
{
    $('.mobile .panel').remove();
    
    transfersArray.forEach(function(element, index){
                var itemID = element.itemID;
                var newRoom = element.newRoom;
                var newOwner = element.newOwner;
                var newDept = element.newDept;
                var notes = element.notes;
                var model = element.model;
                var preRoom = element.preRoom;
                var preOwner = element.preOwner;
                var preDept = element.preDept;
        
                var html = 
                `<div class="panel panel-primary" data-toggle="collapse" href="#` + index + `">
                   <div class="panel-heading">
                      <h4 class="panel-title">
                         <a><b>ID#</b> ` + itemID + ` | ` + model + `</a>
                         <span class="glyphicon glyphicon-chevron-down pull-right"></span>
                       </h4>
                   </div>
                   <div id="` + index + `" class="panel-collapse collapse">
                       <div class="panel-body">
                           <table class="table table-condensed">
                               <tr><td><b>Model </b></td><td>` + model + `</td></tr>
                               <tr><td><b>Previous Room </b></td><td>` + preRoom + `</td></tr>
                               <tr><td><b>Previous Owner </b></td><td>` + preOwner + `</td></tr>
                               <tr><td><b>Previous Dept. </b></td><td>` + preDept + `</td></tr>
                               <tr><td><b>New Room </b></td><td>` + newRoom + `</td></tr>
                              <tr><td><b>New Owner </b></td><td>` + newOwner + `</td></tr>
                               <tr><td><b>Dept. To </b></td><td>` + newDept + `</td></tr>
                           </table>

                           <p><b>Notes: </b>` + notes + `</p>
                           <button class="btn btn-danger delete-btn" onclick="deleteTransfer(this)">Remove</button>
                           <button class="btn btn-primary pull-right" data-toggle="modal" data-target="#Edit_Modal1" onclick="setSelectedID(this)">Edit</button>
                       </div>
                   </div>
                   </div>`;
        
                var newElement = $.parseHTML(html);
        
                $('.mobile').append(newElement);
            });
}

function deleteTransfer(button)
{
    var index = $(button).closest('.panel-collapse').attr('id');
    transfersArray.splice(index, 1);
    $(button).closest('.panel').remove();
}

function clearAll()
{
    transfersArray = [];
    $('.mobile .panel').remove();
}

function setSelectedID(button)
{
    selectedTransferID = parseInt($(button).closest('.panel-collapse').attr('id'));
    
    $('#IDEdit').val(transfersArray[selectedTransferID].itemID);
    $('#newRoomEdit').selectpicker('val', transfersArray[selectedTransferID].newRoom);
    $('#newOwnerEdit').selectpicker('val', transfersArray[selectedTransferID].newOwner);
    $('#newDeptEdit').selectpicker('val', transfersArray[selectedTransferID].newDept);
    $('#notesEdit').val(transfersArray[selectedTransferID].notes);
    $('#modelEdit').val(transfersArray[selectedTransferID].model);
    $('#preRoomEdit').val(transfersArray[selectedTransferID].preRoom);
    $('#preOwnerEdit').val(transfersArray[selectedTransferID].preOwner);
    $('#preDeptEdit').val(transfersArray[selectedTransferID].preDept);
}

function submitEdit()
{
    if($('#IDEdit').val() != '')
    {
        //Add an additional check here to make sure the ID is valid
        //Do this by making sure the fields populated by the database aren't empty.
        
        if($('#newRoomEdit').val() != null && $('#newOwnerEdit').val() != null && $('#newDeptEdit').val() != null)
        {                        
            transfersArray[selectedTransferID].itemID = $('#IDEdit').val();
            transfersArray[selectedTransferID].newRoom = $('#newRoomEdit').val();
            transfersArray[selectedTransferID].newOwner = $('#newOwnerEdit').val();
            transfersArray[selectedTransferID].newDept = $('#newDeptEdit').val();
            transfersArray[selectedTransferID].notes = $('#notesEdit').val();
            transfersArray[selectedTransferID].model = $('#modelEdit').val();
            transfersArray[selectedTransferID].preRoom = $('#preRoomEdit').val();
            transfersArray[selectedTransferID].preOwner = $('#preOwnerEdit').val();
            transfersArray[selectedTransferID].preDept = $('#preDeptEdit').val();
            
            refreshList();
        }
        else
        {
            alert("Please ensure you've comppleted all required fields.");
        }
    }
    else
    {
        alert('Please enter an ID');
    }
}

function submitNew()
{
    if($('#IDAdd').val() != '')
    {
        //Add an additional check here to make sure the ID is valid
        //Do this by making sure the fields populated by the database aren't empty.
        
        if($('#newRoom').val() != null && $('#newOwner').val() != null && $('#newDept').val() != null)
        {
            var transfer = {
                itemID:$('#IDAdd').val(),
                newRoom:$('#newRoom').val(),
                newOwner:$('#newOwner').val(),
                newDept:$('#newDept').val(),
                notes:$('#notes').val(),
                model:$('#model').val(),
                preRoom:$('#pre_room').val(),
                preOwner:$('#pre_owner').val(),
                preDept:$('#pre_dept').val()
            };
            
            
            $('#IDAdd').val('');
            $('#newRoom').selectpicker('val', 'none');
            $('#newOwner').selectpicker('val', 'none');
            $('#newDept').selectpicker('val', 'none');
            $('#notes').val('');
            $('#model').val('');
            $('#pre_room').val('');
            $('#pre_owner').val('');
            $('#pre_dept').val('');
            
            transfersArray.push(transfer);
            
            refreshList();
        }
        else
        {
            alert("Please ensure you've comppleted all required fields.");
        }
    }
    else
    {
        alert('Please enter an ID');
    }
}

function getInfoFromTag(str) 
{
	
	//window.alert(str.length);
	
	if (str.length < 6) 
	{
		document.getElementById("notes").value = "Tag not found.";
		document.getElementById("model").value = "";
		document.getElementById("pre_room").value = "";
		document.getElementById("pre_owner").value = "";
		document.getElementById("pre_dept").value = "";
		return;
	} 
	
	else 
	{
		var xmlhttp = new XMLHttpRequest();
		xmlhttp.onreadystatechange = function()
		{
			if (this.readyState == 4 && this.status == 200) 
			{
				var results = this.responseText.trim();
				
				if(results !== "error")
				{
					var resultsArr = results.split(",");
					console.log(resultsArr);
					
					document.getElementById("model").value = resultsArr[0];
					document.getElementById("pre_room").value = resultsArr[1];
					document.getElementById("pre_owner").value = resultsArr[2];
					document.getElementById("pre_dept").value = "Not available";
					document.getElementById("notes").value = "";
				}
			}
		};
		xmlhttp.open("GET", "phpFunctions.php?q=" + str, true);
		xmlhttp.send();
	}
}