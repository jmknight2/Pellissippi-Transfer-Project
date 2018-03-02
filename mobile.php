<!-- Designer(s): Jon Knight
  -- Date last modified: 2/2/2018 (Zachary Mitchell - minor edit)
  -- Dependices: Stylesheet = "mobile.css"
  -->
  
<?php
	include("phpFunctions.php");
	$con = connectToDB();
?>

<html lang="en">
    <head>
        <title>UI Demo 4</title>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
        <link href='http://fonts.googleapis.com/css?family=Great+Vibes' rel='stylesheet' type='text/css'>
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.12.4/css/bootstrap-select.min.css">
        <link rel="stylesheet" href="style/mobile.css">
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-select/1.12.4/js/bootstrap-select.min.js"></script>
    </head>
    <body>

        <nav class="navbar navbar-default">
          <div class="container-fluid">
            <ul class="nav navbar-nav">
                <li>
                    <select class="form-control">
                        <option>jmknight2@pstcc.edu</option>
                        <option>lbates@pstcc.edu</option>
                    </select>
                </li>
                <li class="active"><button class="btn btn-success btn-block">Submit Transfer</button></li>
                <li><button class="btn btn-danger btn-block" onclick="clearAll()">Clear Items</button></li>
            </ul>
          </div>
        </nav>
        
        <div class="container-fluid mobile">
            
          <div id="items">
            <button id="add-item" data-toggle="modal" data-target="#Add_Modal"><span class="glyphicon glyphicon-plus"></span></button>

            <!-- The commented snippet below is the template for a single record. This is the markup necessary for every new record.
              -- There are 2 things that must be different in each panel for them to work: the ID of the panel-collapse, and the
              -- href attribute of the panel itself.
              -- ** Make sure that the href is identical to the panel-collpse ID **
              --
              -->

            <!--
               <div class="panel panel-primary" data-toggle="collapse" href="#collapse2">
               <div class="panel-heading">
                  <h4 class="panel-title">
                     <a><b>ID#</b> 1005 | Dell Inspiron 9100</a>
                     <span class="glyphicon glyphicon-chevron-down pull-right"></span>
                   </h4>
               </div>
               <div id="collapse2" class="panel-collapse collapse">
                   <div class="panel-body">
                       <table class="table table-condensed">
                           <tr><td><b>Model </b></td><td>Dell Inspiron 9100</td></tr>
                           <tr><td><b>From (Room) </b></td><td>MC149A</td></tr>
                           <tr><td><b>Previous Owner </b></td><td>Jon Knight</td></tr>
                           <tr><td><b>Dept. From </b></td><td>CITC</td></tr>
                           <tr><td><b>To (Room) </b></td><td>MC253</td></tr>
                          <tr><td><b>New Owner </b></td><td>Jon Knight</td></tr>
                           <tr><td><b>Dept. To </b></td><td>CITC</td></tr>
                       </table>

                       <p><b>Notes: </b>This is only a test transfer.</p>
                       <button class="btn btn-danger delete-btn">Remove</button>
                       <button class="btn btn-primary pull-right" data-toggle="modal" data-target="#Edit_Modal1">Edit</button>
                   </div>
               </div>
               </div>
              -->
          </div>
        </div>
		
		<!-- Add Modal start -->
        <div id="Add_Modal" class="modal fade" role="dialog">
          <div class="modal-dialog">

            <!-- Add Modal content start -->
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">New Transfer</h4>
              </div>
              <div class="modal-body">
                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>PSCC ID#</h4>
                    <div class="input-group">
                        <input class="form-control" name="ID" id="IDAdd" placeholder="Please enter/scan ID" value="" onkeyup="getInfoFromTag(this.value)">
                        <span class="barcode input-group-addon" onclick="scan(IDEdit)"><span class="glyphicon glyphicon-barcode"></span></span>
                    </div>
                </div>

                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>New Room</h4>
                    <select id="newRoom" class="form-control selectpicker" data-show-subtext="true" data-live-search="true">
                        <option value="none" selected disabled>Please choose room...</option>
						<?php
							$query= "SELECT DISTINCT Location FROM [Complete Active inventory list 52914];";
							$options = queryDB($con1, $query);
							
							foreach($options as $row) 
							{
								foreach($row as $value) 
								{
									echo "<option>" . $value . "</option>";
								}
							}
						?>
                    </select>
                </div>
                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>New Owner</h4>
                    <select id="newOwner" class="form-control selectpicker" data-show-subtext="true" data-live-search="true">
                        <option value="none" selected disabled>Please choose owner...</option>
						<?php
							$query= "SELECT DISTINCT Custodian FROM [Complete Active inventory list 52914];";
							$options = queryDB($con1, $query);
							
							foreach($options as $row) 
							{
								foreach($row as $value) 
								{
									echo "<option>" . $value . "</option>";
								}
							}
						?>
                    </select>
                </div>
                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>New Department</h4>
                    <select id="newDept" class="form-control selectpicker" data-show-subtext="true" data-live-search="true">
                        <option value="none" selected disabled>Please choose dept...</option>
						<?php
							$query= "SELECT DISTINCT DeptTo FROM tblTransTemp_072017;";
							$options = queryDB($con1, $query);
							
							foreach($options as $row) 
								foreach($row as $value) 
									echo "<option>" . $value . "</option>";
						?>
                    </select>
                </div>

                <div class="form-group">
                    <h4>Notes</h4>
                    <textarea class="form-control" id="notes" name="notes">

                    </textarea>
                </div>

                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>Model</h4>
                    <input class="form-control" id="model" name="model" readonly>
                </div>
                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>Previous Room</h4>
                    <input class="form-control" id="pre_room" name="pre_room" value=" " readonly>
                </div>
                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>Previous Owner</h4>
                    <input class="form-control" id="pre_owner" name="pre_owner" value=" " readonly>
                </div>
                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>Previous Department</h4>
                    <input class="form-control" id="pre_dept" name="pre_dept" value=" " readonly>
                </div>

              </div>
              <!-- Edit Modal content end -->

              <div class="modal-footer">
                <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Cancel</button>
                <button type="button" class="btn btn-success" data-dismiss="modal" onclick="submitEdit()">Save Changes</button>
              </div>
            </div>
            <!-- Add Modal content end -->

              <div class="modal-footer">
                <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Cancel</button>
                <button type="button" class="btn btn-success" data-dismiss="modal" onclick="submitNew()">Save Changes</button>
              </div>
            </div>

          </div>
        <!-- Add Modal end -->
    
    
        <!-- Edit Modal start -->
        <div id="Edit_Modal1" class="modal fade" role="dialog">
          <div class="modal-dialog">

            <!-- Edit Modal content start-->
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Edit Transfer</h4>
                <h4 class="modal-title">Edit Transfer</h4>
              </div>
              <div class="modal-body">
                <form class="form" action="#">
                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>PSCC ID#</h4>
                    <div class="input-group">
                        <input class="form-control" name="ID" id="IDAdd" placeholder="Please enter/scan ID" value="">
                        <span class="barcode input-group-addon" onclick="scan(IDAdd)"><span class="glyphicon glyphicon-barcode"></span></span>
                    </div>
                </div>
				

                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>New Room</h4>
                    <select id="newRoomEdit" class="form-control selectpicker" data-show-subtext="true" data-live-search="true">
						<?php
							$query= "SELECT DISTINCT Location FROM [Complete Active inventory list 52914];";
							$options = queryDB($con1, $query);
							
							foreach($options as $row) 
							{
								foreach($row as $value) 
								{
									echo "<option>" . $value . "</option>";
								}
							}
						?>
                    </select>
                </div>
                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>New Owner</h4>
                    <select id="newOwnerEdit" class="form-control selectpicker" data-show-subtext="true" data-live-search="true">
						<?php
							$query= "SELECT DISTINCT Custodian FROM [Complete Active inventory list 52914];";
							$options = queryDB($con1, $query);
							
							foreach($options as $row) 
							{
								foreach($row as $value) 
								{
									echo "<option>" . $value . "</option>";
								}
							}
						?>
                    </select>
                </div>
                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>New Department</h4>
                    <select id="newDeptEdit" class="form-control selectpicker" data-show-subtext="true" data-live-search="true">
						<?php
							$query= "SELECT DISTINCT DeptTo FROM tblTransTemp_072017;";
							$options = queryDB($con1, $query);
							
							foreach($options as $row) 
								foreach($row as $value) 
									echo "<option>" . $value . "</option>";
						?>
                    </select>
                </div>

                <div class="form-group">
                    <h4>Notes</h4>
                    <textarea id="notesEdit" class="form-control" name="notes"></textarea>
                </div>

                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>Model</h4>
                    <input id="modelEdit" class="form-control" name="model" value="" readonly>
                </div>
                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>Previous Room</h4>
                    <input id="preRoomEdit" class="form-control" name="pre_room" value="" readonly>
                </div>
                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>Previous Owner</h4>
                    <input id="preOwnerEdit" class="form-control" name="pre_owner" value="" readonly>
                </div>
                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>Previous Department</h4>
                    <input id="preDeptEdit" class="form-control" name="pre_dept" value="" readonly>
                </div>

              </form>

              </div>
              <!-- Edit Modal content end -->

              <div class="modal-footer">
                <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Cancel</button>
                <button type="button" class="btn btn-success" data-dismiss="modal" onclick="submitEdit()">Save Changes</button>
              </div>
            </div>

          </div>
        </div>
        <!-- Edit Modal end -->

        <script src="barcode/quagga/dist/quagga.min.js"></script>
        <script src="barcode/scanner.js"></script>
        <script src="manipulate_transfers_mobile.js"></script>
    </body>
</html>