<!doctype html>

<html>

<head>
  <link href="jquery/jquery.min.js">
</head>

<body>
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
