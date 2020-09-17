<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<html>
<body>
<center>
<xsl:for-each select="students/student">
<table border="1" width="50%" cellspacing="0" cellpadding="20" rules="rows">
<tr>
<td colspan="2"><center><xsl:value-of select="firstname"/></center></td>
</tr>
<tr>
<td align="left" width="50%" valign="bottom">
Rok urodzenia: <xsl:value-of select="byear"/> <br/>
Odleglosc od Poznania: <xsl:value-of select="dist"/> km <br/>
Rozmiar obuwia: <xsl:value-of select="boot"/></td>
<td align="right" valign="bottom" width="50%"> Wzrost: <xsl:value-of select="high"/>cm<br/>
Plec: <xsl:value-of select="sex"/><br/>
Kierunek: <xsl:value-of select="rose"/></td>
</tr>
</table>
<br/>
</xsl:for-each>
</center>
</body>
</html>
</xsl:template>
</xsl:stylesheet>
