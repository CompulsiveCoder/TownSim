﻿<%@ Control Language="C#" Inherits="townsim.LogPanel" %>
<%@ Import Namespace="townsim.Data" %>
<div class="pnl">
	<h2>Log</h2>
	<div id="log" style="overflow:auto;height:300px;">
	<%= LogWriter.Current.ReadAll(EngineId).Replace("\n", "<br/>").Replace("\r", "<br/>") %>
	</div>
	<script language="javascript">
		var objDiv = document.getElementById("log");
		objDiv.scrollTop = objDiv.scrollHeight;
	</script>
</div>