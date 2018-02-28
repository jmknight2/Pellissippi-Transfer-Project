// Written by: Jon Knight
// Date last modified: 2/12/18
// Dependencies: mobile.html

var transfersArray = [];
var selectedTransferID;

function refreshList()
{
    $('.content-area tr').remove();
    
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
                `<tr id="`+ index +`">
                    <td>`+ itemID +`</td>
                    <td>`+ model +`</td>
                    <td>`+ preRoom +`</td>
                    <td>`+ preOwner +`</td>
                    <td>`+ preDept +`</td>
                    <td>`+ newRoom +`</td>
                    <td>`+ newOwner +`</td>
                    <td>`+ newDept +`</td>
                    <td>`+ notes +`</td>
                    <td>
                        <button class="btn btn-primary btn-sm">Edit</button>
                        <button class="btn btn-danger btn-md" onclick="deleteTransfer(this)"><span class="glyphicon glyphicon-trash"></span></button>
                    </td>
                </tr>`;
        
                var newElement = $.parseHTML(html);
        
                $('.content-area').append(newElement);
            });
    console.log('Array size: ' + transfersArray.length);
}

function deleteTransfer(button)
{
    var index = $(button).closest('tr').attr('id');
    transfersArray.splice(index, 1);
    $(button).closest('tr').remove();
}

function submitFinal()
{
    var myJsonString = JSON.stringify(transfersArray);
    console.log(myJsonString);
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