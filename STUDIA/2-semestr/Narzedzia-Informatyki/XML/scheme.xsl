<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">
  <html>
  <body>
  <center>
    <table border="1" width="50%" cellspacing="0" cellpadding="20" rules="rows">
      <xsl:for-each select="root/osoba">
      <tr>
        <td colspan="2"><center><xsl:value-of select="firma"/></center></td>
      </tr>
      </xsl:for-each>
      <xsl:for-each select="root/osoba">
      <tr>
        <td align="left" width="50%" valign="bottom"> <xsl:value-of select="imie"/> <br/>
                   <xsl:value-of select="stanowisko"/> <br/>
                   <br/>
                   <xsl:value-of select="www"/> <br/>
                   <xsl:value-of select="mail"/> <br/>
                   <xsl:value-of select="telefon"/></td>
        <td align="right" valign="bottom" width="50%"> <xsl:value-of select="miasto"/><br/>
<xsl:value-of select="ulica"/><br/>
<xsl:value-of select="nip"/></td>
      </tr>
      </xsl:for-each>
    </table>
  </center>
  </body>
  </html>
</xsl:template>
</xsl:stylesheet>