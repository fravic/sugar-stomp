using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

  public GameObject BoardPiece;
  public GameObject BoardSquare;

  public int ActivePlayer = 1;
  public int GameState = 0;

  private int _boardSize = 8;
  private float _boardYPos = 0f;
  private float _pieceYPos = 0.5f;

  void Start() {
    Debug.Log("Starting game!");

    CreateBoard();
    AddPieces();
  }
	
  void CreateBoard() {
    GameObject board = GameObject.FindGameObjectWithTag("Board");

    for (int i = 0; i < _boardSize; i++) {
      for (int j = 0; j < _boardSize; j++) {
	GameObject tile = (GameObject)Instantiate(BoardSquare, new Vector3(i,_boardYPos,j), Quaternion.Euler(90,0,0));
	tile.name = "tile" + i + "," + j;
	tile.transform.parent = board.transform;
      }
    }
  }
	
  void AddPieces() {
    GameObject piece = (GameObject)Instantiate(BoardPiece, new Vector3(0,_pieceYPos,0), Quaternion.identity);
  }
}
