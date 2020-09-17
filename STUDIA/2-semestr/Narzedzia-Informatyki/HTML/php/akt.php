<html>
<head>
<title>Aktualnosci</title>
<link rel="stylesheet" type="text/css" href="strona.css" />
</head>
<body>
<center>

<?php
$xml = simplexml_load_file("aktualnosci.xml");

foreach ($xml->children() as $child)
  {
  echo "<div id=\"naglowek\">";
  echo "<div id=\"title\"> Tytu³: " . $child->tytul . "</div>";
  echo "<div id=\"date\"> Data publikacji: " . $child->data . " </div>";
  echo "<div id=\"wysw\"> Wyswietlen: " . $child->wyswietlane . "</div>";
  echo "<div id=\"tk\"> <b>Tresc krotka:</b> " . $child->tresckrotka . "</div>";
  echo "<div id=\"tresc\"> <b>Tresc artykulu:</b> " . $child->tresc . "</div>";
  echo "</div>";
  }
  
fclose($file);  
?>

</center>
</body>
</html>