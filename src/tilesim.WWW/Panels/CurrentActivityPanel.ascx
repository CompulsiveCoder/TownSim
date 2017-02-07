﻿<%@ Control Language="C#" Inherits="tilesim.CurrentActivityPanel" %>
<%@ Import namespace="tilesim.Engine.Entities" %>
<div class="pnl" id="CurrentActivityPanel">
    <h2>Current Activity</h2>
    <% if (Player != null){ %>
        <% if (Player.IsAlive){ %>
            <div>Activity: <%= Player.ActivityText %></div>
            <div>
                <div class="bar" style="width: <%= (int)(Player.Activity != null ? Player.Activity.PercentComplete*2.5m : 0) %>px; background-color: lightgreen;"></div>
            </div>
        <% } %>
    <% } else { %>   
        <div>No player found.</div>
    <% } %>
</div>