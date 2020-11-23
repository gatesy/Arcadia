# Arcadia
A Pente Playing AI

* Local web app that draws a board you can interact with
* Backend is a load of F# functions
* Probably ASP.NET Core
* Focus on the following themes:
  * Visualisation - draw a board easily
  * Instrumentation - report how an algorithm is progressing
  * Small, pure functions - standalone and easy to argue about functionality
  * Interaction - I want to be able to build a board and easily test my functions on it.

Initial algorithm:
* Game tree with alpha-beta pruning.
* Fixed look-ahead/depth.
* Static evaluation function is trivial:
  * Have I won?
  * How many pieces on the board.

Next gen algo:
* Same game tree evaluator.
* Static evaluation is done using machine learning.
  * Feature extraction: e.g. number of rows of 2, 3, 4 etc.
  * y is: how many moves until I win (bounded by some depth, so if it takes more than 20 moves I don't win)
