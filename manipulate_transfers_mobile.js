// Written by: Jon Knight (Ben Millsaps [Ajax])
// Date last modified: 3/2/18
// Dependencies: mobile.php

var transfersArray = [];
var selectedTransferID;

// * Clears the screen of all panels, and adds a panel for each object in the array.
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
                           <button class="btn btn-primary pull-right" data-toggle="modal" data-target="#Add_Modal" onclick="setSelectedID(this)">Edit</button>
                       </div>
                   </div>
                   </div>`;
        
                var newElement = $.parseHTML(html);
        
                $('.mobile').append(newElement);
            });
}

// * Called when the delete button is clicked.
//
// * Removes selected object from the array, and refreshes the list.
function deleteTransfer(button)
{
    var index = $(button).closest('.panel-collapse').attr('id');
    transfersArray.splice(index, 1);
    $(button).closest('.panel').remove();
}

// * Called when user presses the edit button. 
//
// * Stores the index of the object in a global variable.
function setSelectedID(button)
{
    selectedTransferID = parseInt($(button).closest('.panel-collapse').attr('id'));
    
    console.log("Selected ID: " + selectedTransferID);
    
    $('#IDAdd').val(transfersArray[selectedTransferID].itemID);
    $('#newRoom').selectpicker('val', transfersArray[selectedTransferID].newRoom);
    $('#newOwner').selectpicker('val', transfersArray[selectedTransferID].newOwner);
    $('#newDept').selectpicker('val', transfersArray[selectedTransferID].newDept);
    $('#notes').val(transfersArray[selectedTransferID].notes);
    $('#model').val(transfersArray[selectedTransferID].model);
    $('#pre_room').val(transfersArray[selectedTransferID].preRoom);
    $('#pre_owner').val(transfersArray[selectedTransferID].preOwner);
    $('#pre_dept').val(transfersArray[selectedTransferID].preDept);
}

// * Stringifies the object array in JSON format.
//
// * Still in progress
function submitFinal()
{
    transfersArray.forEach(function(element, index){
        element.custodian = $('#custodian').val();
    });
    
    var myJsonString = JSON.stringify(transfersArray);
    console.log(myJsonString);
}

// * Determines if the user is trying to edit a transfer, or create a new one.
function submit()
{
    if(selectedTransferID === undefined)
    {
        submitNew();
    }
    else
    {
        submitEdit();
    }
}

// * Called when a transfer is to be edited.
//
// * Doesn't alter object unless there are no errors in the modal.
//
// * Refreshes the list when the object's fields have been altered in the array.
function submitEdit()
{
    if($('#IDAdd').val() != '')
    {
        if($('#model').val() != '' && $('#pre_room').val() != '' && $('#pre_owner').val() != '' && $('#pre_dept').val() != '')
        {
            if($('#newRoom').val() != null && $('#newOwner').val() != null && $('#newDept').val() != null)
            {                        
                transfersArray[selectedTransferID].itemID = $('#IDAdd').val();
                transfersArray[selectedTransferID].newRoom = $('#newRoom').val();
                transfersArray[selectedTransferID].newOwner = $('#newOwner').val();
                transfersArray[selectedTransferID].newDept = $('#newDept').val();
                transfersArray[selectedTransferID].notes = $('#notes').val();
                transfersArray[selectedTransferID].model = $('#model').val();
                transfersArray[selectedTransferID].preRoom = $('#pre_room').val();
                transfersArray[selectedTransferID].preOwner = $('#pre_owner').val();
                transfersArray[selectedTransferID].preDept = $('#pre_dept').val();

                refreshList();

                $('#Add_Modal').modal('hide');
                selectedTransferID = undefined;
            }
            else
            {
                alert("Please ensure you've comppleted all required fields.");
            }
        }
        else
        {
            alert("Please ensure you've entered a valid ID");
        }
    }
    else
    {
        alert('Please enter an ID');
    }
}

// * Called when a new transfer is added to the object array.
//
// * Doesn't create object unless there are no errors in the modal.
//
// * Refreshes the list when the new object is added to the array.
function submitNew()
{
    if($('#IDAdd').val() != '')
    {
        if($('#model').val() != '' && $('#pre_room').val() != '' && $('#pre_owner').val() != '' && $('#pre_dept').val() != '')
        {
        
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
                    preDept:$('#pre_dept').val(),
                    custodian:undefined
                };

                transfersArray.push(transfer);    
                refreshList();

                $('#Add_Modal').modal('hide');
            }
            else
            {
                alert("Please ensure you've completed all required fields");
            }
        }
        else
        {
            alert("Please ensure you've entered a valid ID");
        }
    }
    else
    {
        alert('Please enter an ID');
    }
}

// * Registers a handler for the modal close event.
//
// * Clears all fields on modal close.
$('#Add_Modal').on('hidden.bs.modal', function () {
    
    $('#IDAdd').removeClass('error');
    $('#IDAdd').removeClass('success');
    
    $('#IDAdd').val('');
    $('#newRoom').selectpicker('val', 'none');
    $('#newOwner').selectpicker('val', 'none');
    $('#newDept').selectpicker('val', 'none');
    $('#notes').val('');
    $('#model').val('');
    $('#pre_room').val('');
    $('#pre_owner').val('');
    $('#pre_dept').val('');
});

// * Takes the value in the ID field, searches the database for the associated info via Ajax,
//   and returns the results to the appropriate fields.
//
// * Changes the color of the text field upon either success or error.
function getInfoFromTag(str) 
{
	if (str.length < 6 || str.length > 6) 
	{
		if($('#IDAdd').hasClass('success'))
        {
            $('#IDAdd').removeClass('success');
            $('#IDAdd').addClass('error');
        }
        else
        {
            $('#IDAdd').addClass('error');
        }
        
		$("#model").value = "";
		$("#pre_room").value = "";
		$("#pre_owner").value = "";
		$("#pre_dept").value = "";
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
                    
                    if($('#IDAdd').hasClass('has-error'))
                    {
                        $('#IDAdd').removeClass('error');
                        $('#IDAdd').addClass('success');
                    }
                    else
                    {
                        $('#IDAdd').addClass('success');
                    }
                    
					document.getElementById("model").value = resultsArr[0];
					document.getElementById("pre_room").value = resultsArr[1];
					document.getElementById("pre_owner").value = resultsArr[2];
					document.getElementById("pre_dept").value = "Not available";
				}
			}
		};
		xmlhttp.open("GET", "phpFunctions.php?q=" + str, true);
		xmlhttp.send();
	}
}