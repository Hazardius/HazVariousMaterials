<html>
<body>

<form action="hello.php" method="post">
Ile wypisac: <input type="text" name="ile" />
<input type="submit" />
</form>

<?php
$txt="Hello World!";
$x=$_POST["ile"];
for ($i=1; $i<=$x; $i++)
  {
  echo $txt . "<br />";
  }  
?>

</body>
</html>