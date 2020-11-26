<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="html"/>
<xsl:template match="/">
<html>
<body>
<table border="3">
<tr>
  <th><b>Тип</b></th>
<th><b>Бренд</b></th>
<th><b>Ціна</b></th>
<th><b>Магазин</b></th>
<th><b>Країна</b></th>
<th><b>Відгуки</b></th>
  <th><b>Знижка</b></th>
  <th><b>Об'єм</b></th>
</tr>
<xsl:for-each select="beerlist/beer">
<tr>
<td><xsl:value-of select="@sort"/></td>
  <td><xsl:value-of select="@brand"/></td>
  <td><xsl:value-of select="@price"/></td>
  <td><xsl:value-of select="@shop"/></td>
  <td><xsl:value-of select="@country"/></td>
  <td><xsl:value-of select="@reviews"/></td>
  <td><xsl:value-of select="@sale"/></td>
<td><xsl:value-of select="@volume"/></td>
  </tr>
  </xsl:for-each>
  </table>
  </body>
  </html>
  </xsl:template>
  </xsl:stylesheet>