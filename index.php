<?php
    session_start();
    $_SESSION['auth'] = false;
    ini_set('display_errors', 1);
    ini_set('display_startup_errors', 1);
    error_reporting(E_ALL);
?>

<!doctype html>

<html>

<head>
    <title>PSTCC Transfer</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <style>

        body
        {
            background-image: url('img_assets/zeIVk.png'); 
            background-repeat: no-repeat; 
            background-size: cover;
            color: white;
        }
        
        form
        {
            margin-top: 20px;
        }
        
        .col-centered
        {
            margin: 0 auto;
            float: none;
        }

        #login-panel
        {
            text-align: center; 
            background-color: #0066cc;
            padding: 10px 60px 20px 60px;
            border-radius: 0px 0px 20px 20px;
            border: 2px solid #fcd955;
            max-width: 500px;
        }
        
        
    </style>
    
</head>

<body>
    
    <div class="container-fluid">
    <div class="row">
      <div class="col-sm-8 col-centered" id="login-panel">

          <img src="img_assets/pelli_full.svg"/>
          <h1>Transfer Application</h1>
          
              <?php
                    $pwd = 'Password'; 
                    if (isset($_POST["submit"]))
                    {
                        if($_POST["pwd"] == $pwd)
                        {
                            $_SESSION['auth'] = true;
                        }
                        else if($_POST["pwd"] == '')
                        {
                            $_SESSION['auth'] = false;
                            echo "<script>alert('Password cannot be blank.');</script>";
                        }
                        else
                        {
                            $_SESSION['auth'] = false;
                            echo "<script>alert('Password incorrect.');</script>";
                        }
                    }
                ?>

          <form method="post">
            <div class="form-group" style="text-align: left; margin: 0 auto;">
                <div class="input-group">
                    <input class="form-control" style="width: 100%" name="pwd" id="pwd" placeholder="Please enter technician password" type="password">
                    <span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
                </div>
            </div>
            <button type="submit" name="submit" class="btn btn-info btn-block" style="margin-top: 15px;">Submit</button>
          </form> 

      </div>
        
    </div>
  <?php
    if($_SESSION['auth'])
    {
$script = <<<EOT
<script>
var isMobile = {
Android: function() {
  return navigator.userAgent.match(/Android/i);
},
BlackBerry: function() {
  return navigator.userAgent.match(/BlackBerry/i);
},
iOS: function() {
  return navigator.userAgent.match(/iPhone|iPad|iPod/i);
},
Opera: function() {
  return navigator.userAgent.match(/Opera Mini/i);
},
Windows: function() {
  return navigator.userAgent.match(/IEMobile/i) || navigator.userAgent.match(/WPDesktop/i);
},
any: function() {
  return (isMobile.Android() || isMobile.BlackBerry() || isMobile.iOS() || isMobile.Opera() || isMobile.Windows());
}
};
if (isMobile.any()) {
  document.location.replace('mobile.html');
}
else {
  document.location.replace('desktop.html');
}
</script>
</body>
</html>
EOT;
        echo $script;
    }
  ?>