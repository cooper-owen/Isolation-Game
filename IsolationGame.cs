using System;
using static System.Console;

namespace Bme121
{
    static class Program
    {
        public static bool turnPlayerA;                                                             // (8-24) Public varaible declarations
        public static string playerA;
        public static string playerB;
        public static int rows;
        public static int columns;
        public static bool[ , ] board;
        public static int rowPlatformA;
        public static int columnPlatformA;
        public static int rowPlatformB;
        public static int columnPlatformB;
        public static int rowPawnA;
        public static int columnPawnA;
        public static int rowPawnB;
        public static int columnPawnB;
        public static string[ ] letters = { "a","b","c","d","e","f","g","h","i","j","k","l","m",
                                            "n","o","p","q","r","s","t","u","v","w","x","y","z"};
        public static bool check;
                
        static void Main()
        {
            WriteLine();
            
            Initialization();                                                                       // Set up the game with the Initialization method
            
            turnPlayerA = true;                                                                     // Begin with Player A's turn
            
            WriteLine("For all moves [abcd], ab is the tile you want to move to (a=row, b=collumn)" // Explain how you make your move
            + " and cd represents the tile you want to remove (c=row, d=collumn).");
            ReadLine();                                                                             // User must hit enter to move on (otherwise Console.Clear() from DrawGameBoard will automatically clear the screen)
            
            while(true)                                                                             // Continuously run this loop to play the game
            {
                DrawGameBoard();                                                                    // With the DrawGameBoard method board is displayed
                
                MakeMove();                                                                         // The person who's turn it is makes a move in this method
            
                turnPlayerA = !turnPlayerA;                                                         // The turn switches between Player A and B
            }
        }


        static void Initialization()
        {
            Write("Enter Player A name: ");                                                         // Prompt the first player to enter their name 
            playerA = ReadLine();                                                                   // Entry is stored as a variable
            if(playerA.Length == 0)                                                                 // (53-58) If they enterd nothing, "Player A" is set automatically
            {
                playerA = "Player A";
                WriteLine("Player A");
            }
            WriteLine();
            
            Write("Enter Player B name: ");                                                         // Prompt the second player to enter their name
            playerB = ReadLine();                                                                   // Store the entry as a variable
            if(playerB.Length == 0)                                                                 // (62-67) If they enterd nothing, "Player B" is set automatically 
            {
                playerB = "Player B";
                WriteLine("Player B");
            }
            WriteLine();
            
            check = false;                                                                          
            while(check == false)                                                                   // The while loop will continue to run until the user enters a valid input
            {
                Write("Enter desired number of game board rows between 4 and 26 (inclusive): ");    // Prompt the user to enter the number of rows
                string rowsInput = ReadLine();                                                      // Entry is stored as a string variable
                if(rowsInput.Length == 0)                                                           // (74-79) If the user enters nothing before pressing enter, the default (6) is set and displayed
                {
                    rowsInput = "6";
                    WriteLine("6");
                }
                rows = int.Parse(rowsInput);                                                        // Variable is converted into an integer to be compared with the number of rows
                if(rows < 4 || rows > 26)                                                           // (80-89) Check is only set to true and allows the while loop to exit when the number of rows is between 4 and 26
                {
                    WriteLine("There must be between 4 and 26 rows");                               // Otherwise error message is displayed
                }
                else
                {
                    check = true;
                    WriteLine();
                }
            }
            
            check = false;
            while(check == false)                                                                   // (92-111) Logic for columns initialization is identical to rows
            {
                Write("Enter desired number of game board columns between 4 and 26 (inclusive): ");
                string columnsInput = ReadLine();
                if(columnsInput.Length == 0)
                {
                    columnsInput = "8";
                    WriteLine("8");
                }
                columns = int.Parse(columnsInput);
                if(columns < 4 || columns > 26)
                {
                    WriteLine("There must be between 4 and 26 columns");
                }
                else
                {
                    check = true;
                    WriteLine();
                }
            }
            
            board = new bool[rows, columns];                                                        // (113-121) The array board is initialized and filled with true boolean variables
            
            for(int r = 0; r < board.GetLength(0); r ++)
            {
                for(int c = 0; c < board.GetLength(1); c++)
                {
                    board[r, c] = true;
                }
            }
            
            check = false;
            while(check == false)                                                                   // (124-143) Logic for Platform A row initialization is identical to rows
            {
                Write(playerA + " enter the row (starts at 0) of your starting platform: ");
                string rowPlatformInputA = ReadLine();
                if(rowPlatformInputA.Length == 0)
                {
                    rowPlatformInputA = "2";
                    WriteLine("2");
                }
                rowPlatformA = int.Parse(rowPlatformInputA);
                if(rowPlatformA < 0 || rowPlatformA > rows)
                {
                    WriteLine("The row must be on the board");
                }
                else
                {
                    check = true;
                    WriteLine();
                }
            }
            
            check = false;
            while(check == false)                                                                   // (146-165) Logic for Platform A column initialization is identical to rows
            {
                Write(playerA + " enter the column (starts at 0) of your starting platform: ");
                string columnPlatformInputA = ReadLine();
                if(columnPlatformInputA.Length == 0)
                {
                    columnPlatformInputA = "0";
                    WriteLine("0");
                }
                columnPlatformA = int.Parse(columnPlatformInputA);
                if(columnPlatformA < 0 || columnPlatformA > columns)
                {
                    WriteLine("The column must be on the board");
                }
                else
                {
                    check = true;
                    WriteLine();
                }
            }
            
            check = false;
            while(check == false)                                                                   // (168-187) Logic for Platform B row initialization is identical to rows
            {
                Write(playerB + " enter the row (starts at 0) of your starting platform: ");
                string rowPlatformInputB = ReadLine();
                if(rowPlatformInputB.Length == 0)
                {
                    rowPlatformInputB = "3";
                    WriteLine("3");
                }
                rowPlatformB = int.Parse(rowPlatformInputB);
                if(rowPlatformB < 0 || rowPlatformB > rows)
                {
                    WriteLine("The row must be on the board");
                }
                else
                {
                    check = true;
                    WriteLine();
                }
            }
            
            check = false;
            while(check == false)                                                                   // (190-209) Logic for Platform B column initialization is identical to rows
            {
                Write(playerB + " enter the column (starts at 0) of your starting platform: ");
                string columnPlatformInputB = ReadLine();
                if(columnPlatformInputB.Length == 0)
                {
                    columnPlatformInputB = "7";
                    WriteLine("7");
                }
                columnPlatformB = int.Parse(columnPlatformInputB);
                if(columnPlatformB < 0 || columnPlatformB > columns)
                {
                    WriteLine("The column must be on the board");
                }
                else
                {
                    check = true;
                    WriteLine();
                }
            }
            rowPawnA = rowPlatformA;                                                                // (210-215) Pawns A and B are set to their respective platforms 
            columnPawnA = columnPlatformA;
            
            rowPawnB = rowPlatformB;
            columnPawnB = columnPlatformB;
        }


        static void DrawGameBoard()
        {
            Console.Clear();                                                                        // Screen is cleared to prepare for new board display
            
            const string h  = "\u2500"; // horizontal line                                          // (222-239) Constant variables are declared to be used for board display
            const string v  = "\u2502"; // vertical line
            const string tl = "\u250c"; // top left corner
            const string tr = "\u2510"; // top right corner
            const string bl = "\u2514"; // bottom left corner
            const string br = "\u2518"; // bottom right corner
            const string vr = "\u251c"; // vertical join from right
            const string vl = "\u2524"; // vertical join from left
            const string hb = "\u252c"; // horizontal join from below
            const string ha = "\u2534"; // horizontal join from above
            const string hv = "\u253c"; // horizontal vertical cross
            const string sp = " ";      // space
            const string pa = "A";      // pawn A
            const string pb = "B";      // pawn B
            const string bb = "\u25a0"; // block
            const string fb = "\u2588"; // full block
            const string lh = "\u258c"; // left half block
            const string rh = "\u2590"; // right half block
            
            Write("   ");                                                                           // (241-246) Loops through the columns 
            for(int c = 0; c < board.GetLength(1); c ++)
            {
                Write(sp + sp + letters[c] + sp );                                                  // Labels them by placing the appropriate letter above it (spaces for formatting)
            }
            WriteLine();
            
            Write( "   " );                                                                         // (248-256) Draw the top board boundary
            for( int c = 0; c < board.GetLength( 1 ); c ++ )                                        // Loop through the columns
            {
                if( c == 0 ) Write( tl );                                                           // At the top of first column insert the top left corner
                Write( "{0}{0}{0}", h );                                                            // Draw 3 horzizontal lines
                if( c == board.GetLength( 1 ) - 1 ) Write( "{0}", tr );                             // At the top of the last column insert the top right corner
                else                                Write( "{0}", hb );                             // If not at the first or last column, a small vertical line will be drawn between the previous and next column
            }
            WriteLine( );
            
            for( int r = 0; r < board.GetLength( 0 ); r ++ )                                        // (258-260) Loops through the rows 
            {
                Write( " {0} ", letters[ r ] );                                                     // Labels them by placing the appropriate letter to the left it (spaces for formatting)
                
                for(int c = 0; c < board.GetLength(1); c ++)                                        // Loops through the columns to draw the cell contents
                {
                    if( c == 0 ) Write( v );                                                        // At the beginning of the first column insert a straight line (happens in each row)
                    if(r == rowPawnA && c == columnPawnA)                                           // (265-268) Display Pawn A when r and c are equal to the Pawn A's row and column
                    {
                        Write(sp + pa + sp + v);
                    }
                    else if(r == rowPawnB && c == columnPawnB)                                      // (269-272) Display Pawn B when r and c are equal to the Pawn B's row and column
                    {
                        Write(sp + pb + sp + v);
                    }
                    else if(r == rowPlatformA && c == columnPlatformA)                              // (273-276) If not covered by Pawn A or B, display a small block and a vertical line seperating the next column when r and c are equal to Platform A's row and column
                    {
                        Write(sp + bb + sp + v);
                    }
                    else if(r == rowPlatformB && c == columnPlatformB)                              // (277-280) If not covered by Pawn A or B, display a small block and a vertical line seperating the next column when r and c are equal to Platform B's row and column
                    {
                        Write(sp + bb + sp + v);
                    }
                    else if(board[r, c] == true)                                                    // (281-284) If not covered by Platform A or B (or a Pawn), display a large block and a vertical line seperating the next column at [r, c] if it is an available space
                    {
                        Write(rh + fb + lh + v);
                    }
                    else                                                                            // (285-288) If [r, c] is an unavailable space (and not covered by a Platform or Pawn) follow 3 spaces with a vertical line seperating the next column 
                    {
                        Write(sp + sp + sp + v);
                    }
                }
                WriteLine( );
                
                if( r != board.GetLength( 0 ) - 1)                                                  // If you do not stop displaying row border lines before the last row there will be an extra line as our index starts at 0 not 1 
                { 
                    Write( "   " );                                                                 // Formatting
                    for( int c = 0; c < board.GetLength( 1 ); c ++ )                                
                    {
                        if( c == 0 ) Write( vr );
                        Write( "{0}{0}{0}", h );                                                    // Displays 3 horizontal lines under each cell that will form a row boundary
                        if( c == board.GetLength( 1 ) - 1 ) Write( "{0}", vl );                     // If at the final column (but not final row), vertical join from the left
                        else                                Write( "{0}", hv );                     // If not at the last column (and not final row) insert a horizontal vertical cross
                    }
                    WriteLine( );
                }
                else
                {
                    Write( "   " );                                                                 // Formatting
                    for( int c = 0; c < board.GetLength( 1 ); c ++ )                                // If at the last row loop through columns
                    {
                        if( c == 0 ) Write( bl );                                                   // At the first column (and last row) insert the bottom left corner
                        Write( "{0}{0}{0}", h );                                                    // Display 3 horizontal lines under each cell that will form a row boundary
                        if( c == board.GetLength( 1 ) - 1 ) Write( "{0}", br );                     // At the final column (and last row) insert the bottom right corner
                        else                                Write( "{0}", ha );                     // If not at the final column horizontal join from above
                    }
                    WriteLine( );
                }
            }
        }


        static void MakeMove()
        {
            WriteLine();
            
            bool invalidInput = true;
            
            while(invalidInput == true)                                                             // (326-468) The while loop will not exit until the user enters a valid input
            {
                if(turnPlayerA == true)                                                             // (328-397) This part of the loop is used when it is Player A's turn to move
                {
                    Write(playerA + " enter your move [abcd]: ");                                   // Player A is prompted to enter a move 
                    string move = ReadLine();                                                       // Entry is stored as a string variable
                    WriteLine();
                    
                    if(move.Length != 4)                                                            // (334-337) If the length of the move is not 4, an error message is displayed
                    {
                        WriteLine("Enter a move of 4 letters");
                    }
                    else
                    {
                        string rowMoveInputA = move.Substring(0, 1);                                // The first character of the move is stored as a string
                        int rowMoveA = Array.IndexOf(letters, rowMoveInputA);                       // The string is converted into it's respective number (index of the array letter) and stored as an int
                        
                        string columnMoveInputA = move.Substring(1, 1);                             // The second character of the move is stored as a string
                        int columnMoveA = Array.IndexOf(letters, columnMoveInputA);                 // The string is converted into it's respective number (index of the array letter) and stored as an int
                        
                        string rowRemoveInputA = move.Substring(2, 1);                              // The third character of the move is stored as a string
                        int rowRemoveA = Array.IndexOf(letters, rowRemoveInputA);                   // The string is converted into it's respective number (index of the array letter) and stored as an int
                        
                        string columnRemoveInputA = move.Substring(3, 1);                           // The fourth character of the move is stored as a string
                        int columnRemoveA = Array.IndexOf(letters, columnRemoveInputA);             // The string is converted into it's respective number (index of the array letter) and stored as an int
                    
                        if(rowMoveA > rows - 1 || columnMoveA > columns - 1 ||                      // (352-356) If the tile Player A wants to move to or remove is not on the board an error message is displayed
                           rowRemoveA > rows - 1 || columnRemoveA > columns - 1)
                        {
                            WriteLine("Enter a move where all columns and rows are on the board");
                        }
                        else
                        {
                            if((rowPawnA - rowMoveA != 1 && rowPawnA - rowMoveA != 0 && rowPawnA - rowMoveA != -1) ||  // (359-363) If the Max (Chebyshev) distance between Pawn A and the inputted move for Pawn A is greater than 1, an error message is displayed
                               (columnPawnA - columnMoveA != 1 && columnPawnA - columnMoveA != 0 && columnPawnA - columnMoveA != -1))
                            {
                                WriteLine("Enter a space a distance of 1 away from your pawn to move to");
                            }
                            else
                            {
                                if((rowPawnA == rowMoveA && columnPawnA == columnMoveA) ||          // (366-371) If the inputted move for Pawn A is the same tile as Pawn A or Pawn B or the tile is removed, an error message is displayed
                                   (rowPawnB == rowMoveA && columnPawnB == columnMoveA) ||
                                   (board[rowMoveA, columnMoveA] == false))
                                {
                                    WriteLine("Enter an available unoccupied space to move to");
                                }
                                else
                                {
                                    if((board[rowRemoveA, columnRemoveA] == false) ||               // (374-382) If the inputted tile to remove is already removed, occupied by a Pawn or Platform, an error message is displayed
                                       (rowRemoveA == rowPawnA && columnRemoveA == columnPawnA) ||                     
                                       (rowRemoveA == rowPawnB && columnRemoveA == columnPawnB) ||                     
                                       (rowRemoveA == rowPlatformA && columnRemoveA == columnPlatformA) ||             
                                       (rowRemoveA == rowPlatformB && columnRemoveA == columnPlatformB) ||             
                                       (board[rowRemoveA, columnRemoveA] == false))
                                    {
                                        WriteLine("Enter an available unoccupied tile to remove");
                                    }
                                    else
                                    {
                                        invalidInput = false;                                       // Now that the move has passed all error checks, it is decalred a valid input
                                    }
                                }
                            }
                        }
                        if(invalidInput == false)                                                   // (390-395) If the input is valid, Pawn A's position is updated to the move and the declared tile is removed
                        {
                            rowPawnA = rowMoveA;
                            columnPawnA = columnMoveA;
                            board[rowRemoveA, columnRemoveA] = false;
                        }
                    }
                }
                else                                                                                // (398-467) Logic is idential to Player A's turn
                {
                    Write(playerB + " enter a move [abcd]: ");
                    string move = ReadLine();
                    WriteLine();
                    
                    if(move.Length != 4)
                    {
                        WriteLine("Enter a move of 4 letters");
                    }
                    else
                    {
                        string rowMoveInputB = move.Substring(0, 1); 
                        int rowMoveB = Array.IndexOf(letters, rowMoveInputB);
                        
                        string columnMoveInputB = move.Substring(1, 1); 
                        int columnMoveB = Array.IndexOf(letters, columnMoveInputB);
                        
                        string rowRemoveInputB = move.Substring(2, 1);
                        int rowRemoveB = Array.IndexOf(letters, rowRemoveInputB);
                        
                        string columnRemoveInputB = move.Substring(3, 1);
                        int columnRemoveB = Array.IndexOf(letters, columnRemoveInputB);
                    
                        if(rowMoveB > rows -1 || columnMoveB > columns -1 || 
                           rowRemoveB > rows -1 || columnRemoveB > columns - 1)
                        {
                            WriteLine("Enter a move where all columns and rows are on the board");
                        }
                        else
                        {
                            if((rowPawnB - rowMoveB != 1 && rowPawnB - rowMoveB != 0 && rowPawnB - rowMoveB != -1) ||
                               (columnPawnB - columnMoveB != 1 && columnPawnB - columnMoveB != 0 && columnPawnB - columnMoveB != -1))
                            {
                                WriteLine("Enter a space a distance of 1 away from your pawn to move to");
                            }
                            else
                            {
                                if((rowPawnA == rowMoveB && columnPawnA == columnMoveB) ||
                                   (rowPawnB == rowMoveB && columnPawnB == columnMoveB) ||
                                   (board[rowMoveB, columnMoveB] == false))
                                {
                                    WriteLine("Enter an available unoccupied space to move to");
                                }
                                else
                                {
                                    if((board[rowRemoveB, columnRemoveB] == false) ||
                                       (rowRemoveB == rowPawnA && columnRemoveB == columnPawnA) ||
                                       (rowRemoveB == rowPawnB && columnRemoveB == columnPawnB) ||
                                       (rowRemoveB == rowPlatformA && columnRemoveB == columnPlatformA) ||
                                       (rowRemoveB == rowPlatformB && columnRemoveB == columnPlatformB) ||
                                       (board[rowRemoveB, columnRemoveB] == false))
                                    {
                                        WriteLine("Enter an available unoccupied tile to remove");
                                    }
                                    else
                                    {
                                        invalidInput = false;
                                    }
                                }
                            }
                        }
                        if(invalidInput == false)                                                   
                        {
                            rowPawnB = rowMoveB;
                            columnPawnB = columnMoveB;
                            board[rowRemoveB, columnRemoveB] = false;
                        }
                    }
                }
            }
            
        } 
    }
}
