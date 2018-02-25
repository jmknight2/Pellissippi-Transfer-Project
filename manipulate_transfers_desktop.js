/* Written by: Jon Knight
 * Last Edited By: Mathew Ratliff
 * Date last modified: 2/25/18
 ***************************************
 *  Reason for modification (2/25/18)  *
 ***************************************
 * Added editTransfer, which allows the user to pop up the edit modal (in progress).
 * Added some checking - if pre'item' is undefined, show N/A for non-applicable.
 *                     - if "model" is empty - display "Unknown"
 * v Edited var html v
 * separated the buttons due to some glitch that caused them to
 * stack sometimes rather than stay side-by-side
 * ((((((((((((()))))))))))))*
 * Dependencies: desktop.html
 */
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

                // typeof, well, checks the type of an item.
                // if the item matches "undefined" then display "N/A"
                if (typeof preDept == "undefined") {
                  preDept = "N/A";
                }
                if (typeof preRoom == "undefined") {
                  preRoom = "N/A";
                }
                if (typeof preOwner == "undefined") {
                  preOwner = "N/A";
                }
                // If model is empty, or never entered, then display unknown.
                if (model == "") {
                  model = "Unknown";
                }

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
                        <button class="btn btn-primary btn-sm" onclick="editTransfer(this)">Edit</button>
                    </td>
                    <td>
                        <button class="btn btn-danger btn-md" onclick="deleteTransfer(this)"><span class="glyphicon glyphicon-trash"></span></button>
                    </td>
                </tr>`;
                var newElement = $.parseHTML(html);

                $('.content-area').append(newElement);
            });

    // Guessing this is for testing?
    console.log('Array size: ' + transfersArray.length);
}

// Turn everything into previous items (instead of newRoom, now preRoom)?
// once the edit btn is pressed
function editTransfer(button)
{

}
function deleteTransfer(button)
{
    var index = $(button).closest('tr').attr('id');
    transfersArray.splice(index, 1);
    $(button).closest('tr').remove();
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
            alert("Please ensure you've completed all required fields.");
        }
    }
    else
    {
        alert('Please enter an ID');
    }
}
