namespace TicTacToe;

public class Board {
  public Square[,] Grid;

  public Board() {
    Square[,] board = new Square[3,3];
    int pos = 1;

    for (int r = 2; r >= 0; r--) {
      for (int c = 0; c < board.GetLength(1); c++) {
        if (pos == 1 || pos == 3 || pos == 7 || pos == 9) {
          board[r,c] = new Square(pos,"corner",' ');
        }
        else if (pos == 2 || pos == 4 || pos == 6 || pos == 8) {
          board[r,c] = new Square(pos,"edge",' ');
        }
        else {
          board[r,c] = new Square(pos,"center",' ');
        }
        
        pos ++;
      }
    }

    Grid = board;
  }

  public void TakeTurn(char player, char square) {
    Console.WriteLine($"Player: {player}, Square: {square}");
    switch (square) {
      case '1':
        this.Grid[2,0].Symbol = player;
        break;
      case '2':
        this.Grid[2,1].Symbol = player;
        break;
      case '3':
        this.Grid[2,2].Symbol = player;
        break;
      case '4':
        this.Grid[1,0].Symbol = player;
        break;
      case '5':
        this.Grid[1,1].Symbol = player;
        break;
      case '6':
        this.Grid[1,2].Symbol = player;
        break;
      case '7':
        this.Grid[0,0].Symbol = player;
        break;
      case '8':
        this.Grid[0,1].Symbol = player;
        break;
      case '9':
        this.Grid[0,2].Symbol = player;
        break;
    }
  }

  public bool CheckWin() {
    if (CheckRow(0) || CheckRow(1) || CheckRow(2) 
     || CheckCol(0) || CheckCol(1) || CheckCol(2) || CheckDiagonals()) return true;

    return false;
  }

  private bool CheckRow(int row){
    if (!(this.Grid[row,0].Symbol == ' ' && this.Grid[row,1].Symbol == ' ' && this.Grid[row,2].Symbol == ' ')) {
      if (this.Grid[row,0].Symbol == this.Grid[row,1].Symbol && this.Grid[row,0].Symbol == this.Grid[row,2].Symbol) {
        return true;
      }
    }
    return false;
  }

  private bool CheckCol(int col){
    if (!(this.Grid[0,col].Symbol == ' ' && this.Grid[1,col].Symbol == ' ' && this.Grid[2,col].Symbol == ' ')) {
      if (this.Grid[0,col].Symbol == this.Grid[1,col].Symbol && this.Grid[0,col].Symbol == this.Grid[2,col].Symbol) {
        return true;
      }
    }
    return false;
  }

  private bool CheckDiagonals() {
    if (!(this.Grid[0,0].Symbol == ' ' && this.Grid[1,1].Symbol == ' ' && this.Grid[2,2].Symbol == ' ')) {
      if (this.Grid[0,0].Symbol == this.Grid[1,1].Symbol && this.Grid[0,0].Symbol == this.Grid[2,2].Symbol) {
        return true;
      }
    }
    if (!(this.Grid[0,2].Symbol == ' ' && this.Grid[1,1].Symbol == ' ' && this.Grid[2,0].Symbol == ' ')) {
      if (this.Grid[0,2].Symbol == this.Grid[1,1].Symbol && this.Grid[0,2].Symbol == this.Grid[2,0].Symbol) {
        return true;
      }
    }

    return false;
  }

  public int GetAvailableCorners() {
    int corners = 0;

    for(int r = 0; r < Grid.GetLength(0); r++) {
      for(int c = 0; c < Grid.GetLength(1); c++) {
        if (Grid[r,c].Type == "corner" && Grid[r,c].Symbol == ' ') 
          corners++;
      }
    }

    return corners;
  }

  public int GetAvailableEdges() {
    int edges = 0;

    for(int r = 0; r < Grid.GetLength(0); r++) {
      for(int c = 0; c < Grid.GetLength(1); c++) {
        if (Grid[r,c].Type == "edge" && Grid[r,c].Symbol == ' ') 
          edges++;
      }
    }

    return edges;
  }

  public string GetUIString() {
    string uIString = "";

    int turn = 1;

    for(int r = 0; r < Grid.GetLength(0); r++) {
      for(int c = 0; c < Grid.GetLength(1); c++) {
        if (Grid[r,c].Symbol != ' ') 
          turn++;
      }
    }

    uIString += $"Turn: {turn} | ";

    return uIString ;
  }

  public override string ToString() {
    var str = 
@$" {Grid[0,0].Symbol} | {Grid[0,1].Symbol} | {Grid[0,2].Symbol} 
-----------
 {Grid[1,0].Symbol} | {Grid[1,1].Symbol} | {Grid[1,2].Symbol} 
-----------
 {Grid[2,0].Symbol} | {Grid[2,1].Symbol} | {Grid[2,2].Symbol} ";

    return str;
  }

  public string ToStringFull() {
    var str = 
@$" {Grid[0,0].Position},{Grid[0,0].Type} | {Grid[0,1].Position},{Grid[0,1].Type} | {Grid[0,2].Position},{Grid[0,2].Type} 
------------------------------
 {Grid[1,0].Position},{Grid[1,0].Type} | {Grid[1,1].Position},{Grid[1,1].Type} | {Grid[1,2].Position},{Grid[1,2].Type} 
------------------------------
 {Grid[2,0].Position},{Grid[2,0].Type} | {Grid[2,1].Position},{Grid[2,1].Type} | {Grid[2,2].Position},{Grid[2,2].Type} ";

    return str;
  }
}
