# CardGameCodingExercise

C# project with a Command Line user interface, which takes a list of playing cards and returns a score for the cards given.

Requirements:
- The application’s back-end must be written in C#.
- The code to convert the list of cards to their score must be performed in the back-end C#
code.
- The application must contain a user interface, which allows the user to enter their list of
cards.
- The list of cards must be given as a comma separated list.
- Each card must use a two-character representation as follows:
  - The first character represents the card’s value:
    - 2-9 for the card values 2 through 9
    - T for 10
    - J for a Jack
    - Q for a Queen
    - K for a King
    - A for an Ace
  - The second character represents the card’s suit:
    - C for Clubs
    - D for Diamonds
    - H for Hearts
    - S for Spades
  - E.g. “AS” would be the Ace of Spades, “4C” would be the 4 of Clubs etc.
  - A Joker is represented by two-character code “JK”.
- The score must be displayed on the user interface.
- The application must convert any valid list of cards to their score.
- The application must display an error message if the user enters an invalid list of cards.
- An error message must be displayed if the user duplicates a card in their list. Note however
that a Joker can appear twice, so an error message must be displayed if three or more Jokers
appear in the list.
- All code must be written using TDD.
- There must be 100% unit test coverage.
