<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version='1.0'
	xmlns:xsl='http://www.w3.org/1999/XSL/Transform'>
	<xsl:template match="/">
		<books>
			<xsl:for-each select="catalog/book">
					<book>
						<title>
							<xsl:value-of select="title" />
						</title>
						<author>
							<xsl:value-of select="author" />
						</author>
						<price>
							<xsl:value-of select="price" />
						</price>
						<xsl:if test="price &gt; 5.94">
						<promotion>
						    <xsl:value-of select="round(price * 90) div 100"/>
						</promotion>
						</xsl:if>
					</book>
			</xsl:for-each>
		</books>
	</xsl:template>
</xsl:stylesheet>
