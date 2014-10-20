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

  void OnDestroy() {
    NotificationCenter.DefaultCenter.RemoveObserver(this, "PieceMoved");
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

    PieceControl controller = piece.GetComponent<PieceControl>();
    controller.PlayerNum = playerNum;
    controller.MeshObject.renderer.material.color = playerNum == 0 ? Color.red : Color.blue;
  }

  void DestroyPiece(GameObject piece) {
  }

  void PieceMoved(NotificationCenter.Notification notification) {
    GameObject pieceToKill;
    int tileX = (int)Math.Floor(notification.Sender.transform.position.x);
    int tileZ = (int)Math.Floor(notification.Sender.transform.position.z);
    
    if (pieceToKill = GetPieceAtTile(tileX, tileZ)) {
      DestroyPiece(pieceToKill);
    }

    UpdatePiecePosition(notification.Sender.name, tileX, tileZ);
    NextTurn();
  }

  GameObject GetPieceAtTile(int tileX, int tileZ) {
    // TODO
    return null;
  }

  void UpdatePiecePosition(string pieceName, int tileX, int tileZ) {
    // TODO
  }

  void NextTurn() {
    ActivePlayer = (ActivePlayer + 1) % NumPlayers;
    Hashtable notifData = new Hashtable {
      {"activePlayerNum", ActivePlayer},
    }; 
    NotificationCenter.DefaultCenter.PostNotification(this, "NextTurn", notifData);
  }
}
