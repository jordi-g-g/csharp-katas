Tic Tac Toe
About this kata
Like many game kata, it’s a good introduction to double loop TDD or BDD.

Rules
The rules of the tic tac toe game are the following:

[V] - a game has nine fields in a 3x3 grid
[V] - there are two player in the game (X and O)
[V] - a game is over when all fields are taken
[V] - a game is over when all fields in a column are taken by a player
[V] - a game is over when all fields in a row are taken by a player
[V] - a game is over when all fields in a diagonal are taken by a player
[V] - a player can take a field if not already taken
[V] - a player cannot take an already taken field
[ ] - players take turns taking fields until the game is over

Suggested Test Cases
Given this game board

+---+---+---+
| 1 | 2 | 3 |
+---+---+---+
| 4 | 5 | 6 |
+---+---+---+
| 7 | 8 | 9 |
+---+---+---+

And it's the turn of player X
When it play on cell 5
Then the board is now

+---+---+---+
| 1 | 2 | 3 |
+---+---+---+
| 4 | X | 6 |
+---+---+---+
| 7 | 8 | 9 |
+---+---+---+

And it's not the end of game.
