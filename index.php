<!doctype html>

<html>

<head>
  <title>UI Demo 4</title>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
  <link href="jquery/jquery.min.js">
</head>

<body>
    
    <?php
        $pwd = 'Password';    
    
    
        if (isset($_POST["submit"]))
        {
            if($_POST["pwd"] == $pwd)
            {
                
            }
        }
    
    ?>
    
  <h1>PSTCC Transfer Application</h1>
  <form action="" method="post">
    <h4>Password</h4>
    <div class="input-group">
      <input class="form-control" name="pwd" id="pwd" placeholder="Please enter your technician password" value="">
    </div>
    <button type="submit"></button>
  </form> 
  
  <?php
    if()
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
