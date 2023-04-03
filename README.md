# CSCI-526-game

Created for the group Night Rangers.

Team: Night Rangers

The link to our GDD - https://docs.google.com/document/d/1aN0BRfKqfXw87Drb1p618vh5wG25GP5x_FAFn_AcPbE/edit

Basic Mechanics of the Game -
* Player needs to place bricks and jump on those bricks to reach the destination
  * Once the player jumps on a brick, they cannot move the brick. This is to avoid reusing stable bricks as a hack
* We have multiple different types of bricks:
  * Stable bricks - these bricks don’t move at all
  * Falling bricks - the player can only stand on these bricks for a limited amount of time, after this the brick will fall and the player will die
  * Floating bricks - these bricks will stay on either the x or y-axis that the player places it on, but will move back-and-forth
  * Black Hole - Once the player enters the portal from one end he directly teleports to the other end. It engulfs the player when he gets too close to it.
* There are other types of enemies that the player may face: aliens, UFOs, meteor showers, etc.

