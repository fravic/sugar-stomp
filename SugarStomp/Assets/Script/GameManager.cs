using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

  public GameObject BoardPiece;
  public GameObject BoardSquare;

  public int activePlayer = 1;
  public int gameState = 0;

  private int _boardSize = 8;
  private int _boardYPos = -1;

  // Change the state of the game
  public void ChangeState(int _newState) {
    gameState = _newState;
  }

  void OnGUI() {
    // Handle GUI events. May be called several times per frame (once per GUI event)
    // Update labels, etc
  }
	
  void Start() {
    Debug.Log("Starting game!");

    // Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
    CreateBoard();
    AddPieces();
  }
	
  void CreateBoard() {
    for (int i = 0; i < _boardSize; i++) {
      for (int j = 0; j < _boardSize; j++) {
	Object.Instantiate(BoardSquare, new Vector3(i,_boardYPos,j), Quaternion.Euler(90,0,0));
      }
    }
  }
	
  void AddPieces() {
    Object.Instantiate(BoardPiece, new Vector3(0,0,0), Quaternion.identity);
  }
}
