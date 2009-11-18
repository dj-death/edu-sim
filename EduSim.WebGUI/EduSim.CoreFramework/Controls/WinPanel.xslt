<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">
  <xsl:template match="WC:Tags.Panel[@Attr.CustomStyle='Window']" mode="modContent">
    <xsl:if test="@Attr.Enabled='0'">
      <xsl:attribute name="class">Common-InheritDisabled</xsl:attribute>
    </xsl:if>
    <TABLE style="table-layout:fixed;width:100%;height:100%" border="0" cellpadding="0" cellspacing="0">
      <COL width="4px" />
      <COL />
      <COL width="4px" />
      <TR height="22px">
        <TD style="background-image:url(Skins.ToolTopLeft.gif.wgx)"></TD>
        <TD style="background-image:url(Skins.ToolTopCenter.gif.wgx);position:relative;cursor:default;">
          <SPAN style="width:100%;height:100%;">
            <SPAN class="Common-SubFontLabel" style="color: #ffffff;position:absolute;top:4px;left:0px;">
              <xsl:value-of select="@Attr.Text" />
            </SPAN>
            <SPAN style="position:absolute;top:6px;right:0px;">
              <IMG src="Skins.ToolClose.gif.wgx" class="Common-HandCursor" onclick="mobjApp.Events_FireEvent({@Id},'PanelClose',true)"
								align="left" />
            </SPAN>
          </SPAN>
        </TD>
        <TD style="background-image:url(Skins.ToolTopRight.gif.wgx)"></TD>
      </TR>
      <TR>
        <TD style="background-image:url(Skins.ToolLeft.gif.wgx)"></TD>
        <TD style="position:relative;background:white;">
          <xsl:call-template name="tplDrawContained" />
        </TD>
        <TD style="background-image:url(Skins.ToolRight.gif.wgx)"></TD>
      </TR>
      <TR height="4px">
        <TD style="background-image:url(Skins.ToolBottomLeft.gif.wgx)"></TD>
        <TD style="background-image:url(Skins.ToolBottomCenter.gif.wgx)"></TD>
        <TD style="background-image:url(Skins.ToolBottomRight.gif.wgx)"></TD>
      </TR>
    </TABLE>
  </xsl:template>
</xsl:stylesheet>
