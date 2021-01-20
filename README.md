# Isolation-Game
In my digital computation course I was tasked with coding the board game Isolation in C#.
I decided to structure my code all within the class "program" and created static field variables that I used throughout the different methods.
The game begins with the main method calling the "Initialization" method.
The code will automatically set default settings if the users respond to the set up promts by clicking enter rather than entering their name, desired game board size and starting position.
Next instructions for how the players will enter their moves is displayed before a while loop is entered that will perpetually run until the game is finished.
It is important to note that a method to automatically end the game when a player has won was not required for this assignment; it will be added during a future iteration of the code.
The while loop first calls the "DrawGameBoard" constructs a game board based on the information gathered in the "Initialization" method. Every time this method is called in the future, it will clear the previously displayed game board and update it based on the user inputs from the "MakeMove" method.
Next the make move method is called, where, starting with Player A, an input from the user is recieved that determines where their pawn will move to and which tile they will remove. Extensive error checks are performed to ensure that this input is valid.
The next line of the while loop switches who's turn it is to move next.
At this point in the while loop, right before it repeats, is where the method to check whether the game has been won and by who will be implemented.
