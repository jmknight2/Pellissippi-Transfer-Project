<?php
    session_start();
    $_SESSION['auth'] = false;
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
    html {
      height: 100%;
      width: 100%;
    }
    body
    {
      background: radial-gradient(rgb(255, 210, 79), rgb(0, 75, 141));
      background-size: cover;
      color: white;
      display: flex;
      width: 100%;
    }
    .container-fluid {
      width: 100%;
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
      margin: 0 auto;
      margin-top: 20%;
      text-align: center;
      background-color: #0066cc;
      padding: 10px 60px 20px 60px;
      border-radius: 30px;
      border: 2px solid #fcd955;
      width: 60%;
    }
    @media screen and (max-width: 768px) {
      [class*="col-"] {
        width: 75%;
      }
      body {
        text-align: center;
      }
      #login-panel
      {
        margin: 0 auto;
        margin-top: 25%;
        text-align: center;
        background-color: #0066cc;
        padding: 10px 30px 20px 30px;
        border-radius: 20px 20px 20px 20px;
        border: 2px solid #fcd955;
        width: 90%;
        height: 75%;
        display: block;
        float: none;
      }
      h2 {
        font-size: 20px;
      }
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
                    if (isset($_POST["submit"]))
                    {
                        if($_POST["pwd"] == '')
                        {
                            $_SESSION['auth'] = false;
                            echo "<script>alert('Password cannot be blank.');</script>";
                        }
						else if(exec('cd verification && scramblerVerify.exe '.$_POST["pwd"].' -f nothingInteresting.txt') == 'True')
                        {
                            $_SESSION['auth'] = true;
                        }
                        else
                        {
                            $_SESSION['auth'] = false;
                            echo "<script>alert('Password incorrect.');</script>";
                        }
                    }
                ?>

          <form method="post">
            <div class="form-group">
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
      if($_SESSION['auth'] == true)
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
          document.location.replace('mobile.php');
        }
        else {
          document.location.replace('desktop.php');
        }
        </script>
        </body>
        </html>
EOT;
          echo $script;
      }
    ?>