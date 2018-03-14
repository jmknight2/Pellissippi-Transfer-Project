Email Message
=============

The email is split into three files: head.html, body.html, and foot.html. All three parts can be customized to the limits of HTML's capabilities.

Keep in mind, that CSS stylesheets do **not** work in Microsoft's outlook, however, an html tag can be styled using the *style* operator.

The head and foot is essentially the top and bottom of the email. The body however, is a little more unique...

# The Body
The body is designed to recurse for every json object that is passed through *email.php*. It can accept any json element by defining the key of each value, preceeded by the "@" symbol.
## example:
```
$json ='[{"Key1":"Element1","key2":1234}]';

<!--You could design the body with variables like these:-->
<p>Hi! Key1 gives you the value: @Key1<br>
It's as easy as @key2</p>
```

As the body keeps being printed based one each json object, the values will change along with it.