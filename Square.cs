namespace TicTacToe;

public class Square {
  public char Symbol { get; set; }

  public int Position { get; set; }

  public string Type {get; set;}

  public Square(int position,string type,char symbol = ' ') {
    Symbol = symbol;
    Position = position;
    Type = type;
  }
}
