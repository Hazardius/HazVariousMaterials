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

				</book>
			</xsl:for-each>
		</books>
	</xsl:template>
</xsl:stylesheet>
