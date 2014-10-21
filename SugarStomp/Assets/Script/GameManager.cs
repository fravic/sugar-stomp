using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

  public GameObject BoardPiece;
  public GameObject BoardSquare;

  public int NumPlayers = 2;
  public int ActivePlayer = -1;
  public int GameState = 0;

  private Board _board = new Board();
  private int _boardSize = 8;
  private float _boardYPos = -0.25f;
  private float _pieceYPos = 0;

  private Dictionary<string,GameObject> _piecePositions = new Dictionary<string,GameObject>();

  void Awake() {
    NotificationCenter.DefaultCenter.AddObserver(this, "PieceMoved");
  }

  void Start() {
    Debug.Log("Starting game!");

    CreateBoard();
    AddPieces();
    NextTurn();
  }

  void CreateBoard() {
    GameObject board = GameObject.FindGameObjectWithTag("Board");

    for (int i = 0; i < _boardSize; i++) {
      for (int j = 0; j < _boardSize; j++) {
	GameObject tile = (GameObject)Instantiate(BoardSquare, new Vector3(i,_boardYPos,j), Quaternion.identity);
	tile.name = "tile" + i + "," + j;
	tile.transform.parent = board.transform;
      }
    }
  }
	
  void AddPieces() {
    AddPiece(0, 0, 0);
    AddPiece(1, 7, 7);
  }

  void AddPiece(int playerNum, int tileX, int tileZ) {
    GameObject piece = (GameObject)Instantiate(BoardPiece, new Vector3(tileX,_pieceYPos,tileZ), Quaternion.identity);
    piece.name = "piece" + playerNum;

    PieceEntity entity = piece.GetComponent<PieceEntity>();
    entity.PlayerNum = playerNum;
    entity.MeshObject.renderer.material.color = playerNum == 0 ? Color.red : Color.blue;
  }

  void PieceMoved(NotificationCenter.Notification notification) {
    BoardEntity pieceToKill;
    BoardEntity movedPiece = (BoardEntity)notification.Sender;
    int tileX = movedPiece.GetTileX();
    int tileZ = movedPiece.GetTileZ();
    
    if (pieceToKill = _board.GetPieceAtTile(tileX, tileZ)) {
      // TODO: Move this logic to Piece.Collide
    }

    _board.UpdatePiecePosition(movedPiece, tileX, tileZ);
    NextTurn();
  }

  void NextTurn() {
    ActivePlayer = (ActivePlayer + 1) % NumPlayers;
    Hashtable notifData = new Hashtable {
      {"activePlayerNum", ActivePlayer},
    }; 
    NotificationCenter.DefaultCenter.PostNotification(this, "NextTurn", notifData);
  }

}
