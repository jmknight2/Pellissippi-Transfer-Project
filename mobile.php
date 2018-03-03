<!-- Designer(s): Jon Knight, Matthew Ratliff, (Zachary Mitchell - minor edit)
  -- Date last modified: 3/2/2018 
  -- Dependices: Stylesheet = "mobile.css", JS = "manipulate_transfers_mobile.js"
  -->
  
<?php
    session_start();
	include("phpFunctions.php");
	$con = connectToDB();

    if(!$_SESSION['auth'])
    {
        header('Location: index.php');
        die();
    }
?>

<html lang="en">
    <head>
        <title>PSTCC Transfer</title>
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
                    <select class="form-control" id="custodian">
                        <option>jmknight2@pstcc.edu</option>
                        <option>lbates@pstcc.edu</option>
                    </select>
                </li>
                <li class="active"><button class="btn btn-success btn-block" onclick="submitFinal()">Submit Transfer</button></li>
                <li><button class="btn btn-danger btn-block" onclick="window.location.href='logout.php'">Logout</button></li>
            </ul>
          </div>
        </nav>
        
        <div class="container-fluid mobile">
            
          <div id="items">
            <button id="add-item" data-toggle="modal" data-target="#Add_Modal"><span class="glyphicon glyphicon-plus"></span></button>

          </div>
        </div>
		
		<!-- Add Modal start -->
        <div id="Add_Modal" class="modal fade" role="dialog">
          <div class="modal-dialog">

            <!-- Add Modal content start -->
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Transfer Details</h4>
              </div>
              <div class="modal-body">
                <div class="form-group" style="text-align: left; margin: 0 auto;">
                    <h4>PSCC ID#</h4>
                    <div class="input-group">
                        <input class="form-control" name="ID" id="IDAdd" placeholder="Please enter/scan ID" value="" onkeyup="getInfoFromTag(this.value)">
                        <span class="barcode input-group-addon" onclick="scan(IDAdd)"><span class="glyphicon glyphicon-barcode"></span></span>
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

              <div class="modal-footer">
                <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Cancel</button>
                <button type="button" class="btn btn-success" onclick="submit()">Save Changes</button>
              </div>
            </div>

          </div>
        </div>
        <!-- Add Modal end -->

        <script src="barcode/quagga/dist/quagga.min.js"></script>
        <script src="barcode/scanner.js"></script>
        <script src="manipulate_transfers_mobile.js"></script>
    </body>
</html>
