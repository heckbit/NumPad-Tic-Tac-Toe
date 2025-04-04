using System;

namespace TicTacToe;

public class TicTacToe
{
  private static readonly Random _random = new();

  static void Main(string[] args)
  {
    Board board = new();
    bool humanTurn = HumanIsFirst();

    int turn = 1;

    while (turn <= 9){
      char movePos;

      ScreenUpdate(board,humanTurn);

      if (humanTurn){
        do{
          Console.Write("Enter a square (0-9): ");
          ConsoleKeyInfo keyInfo = Console.ReadKey();
          Console.WriteLine();

          movePos = keyInfo.KeyChar;

        } while (movePos < '1' || movePos > '9');

        board.TakeTurn('x', movePos);
      }
      else{
        Console.WriteLine("Computer is playing...");
        Console.WriteLine();

        movePos = BotFindMove(board);

        board.TakeTurn('o', movePos);
      }

      ScreenUpdate(board,humanTurn);

      if (turn >= 5){
        if (board.CheckWin()){
          string winText = humanTurn ? "Game over, X wins!" : "Game over, O wins!";

          Console.WriteLine(winText);
          break;
        }
      }

      // round end logic
      humanTurn = !humanTurn;
      turn++;
    }

    Console.WriteLine("Game is over!");

    // Console.WriteLine(board.ToStringFull());
  }

  static bool HumanIsFirst(){
    return _random.Next(0, 2) == 0;
  }

  static char BotFindMove(Board board){
    string botMove = "";
    string moveType = "";
    int corners = board.GetAvailableCorners();
    int edges = board.GetAvailableEdges();

    if (corners >= 2){
      moveType = "corner";
    }
    else{
      if (edges >= 2){
        moveType = "edge";
      }
    }

    for (int r = 0; r < board.Grid.GetLength(0); r++){
      for (int c = 0; c < board.Grid.GetLength(1); c++){
        if (board.Grid[r, c].Symbol == ' '){
          if (moveType != ""){
            if (moveType == board.Grid[r, c].Type){
              botMove = $"{board.Grid[r, c].Position}";
              break;
            }
          }
          else {
            botMove = $"{board.Grid[r, c].Position}";
            break;
          }
        }
      }
      if (botMove != ""){
        break;
      }
    }

    return botMove.ToCharArray()[0];
  }

  static void ScreenUpdate(Board board, bool humanTurn){
    string controlsBoard =
@$" 7 | 8 | 9 
-----------
 4 | 5 | 6 
-----------
 1 | 2 | 3 ";

    Console.Clear();
    Console.WriteLine("Controls: Use the numbers on the numpad to select your move. Each number corresponds to a square on the board.");
    Console.WriteLine();
    Console.WriteLine(controlsBoard);
    Console.WriteLine();
    Console.WriteLine(board.GetUIString()+"Player: "+(humanTurn?"X":"O"));
    Console.WriteLine();
    Console.WriteLine(board);
    Console.WriteLine();
  }
}
