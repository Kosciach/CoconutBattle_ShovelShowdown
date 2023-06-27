<h2 align="center">Two Players</h2>


<br>
<h2 align="center">Seperating two players</h2>
<p align="center">
    Both players are almost the same gameObjects, with the same scripts.<br>
    To seperate two players game uses PlayerIndex(P1-0, P2-1), this is used when for example, each player has to get his own movement input values.
</p>

<br>
<h2 align="center">Camera</h2>
<p align="center">
  Camera always looks at point between players, or at the winning player.<br>
  To make camera face the center, LookAt gameObjects position is calculated with both players positions.<br>
  When the game ends and one of the players wins, LookAt gameObjects position is then changed to this players position.
</p>


<h3 align="center">
  <a href="README.md">ReadMe</a>
</h3>
