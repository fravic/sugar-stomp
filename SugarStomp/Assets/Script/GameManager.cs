using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

  public GameObject BoardPieceTemplate;
  public GameObject BoardSquareTemplate;
  public GameObject BoardPowerupTemplate;

  public int NumPlayers = 2;
  public int ActivePlayer = -1;
  public int GameState = 0;

  private Board _board = new Board();
  private int _boardSize = 8;
  private float _boardYPos = -0.25f;
  private float _pieceYPos = 0;

  void Awake() {
    NotificationCenter.DefaultCenter.AddObserver(this, "EndTurn");
  }

  void Start() {
    Debug.Log("Starting game!");

    CreateBoard();
    AddPieces();
    AddPowerup(1, 1);
    NextTurn();
  }

  void CreateBoard() {
    GameObject board = GameObject.FindGameObjectWithTag("Board");

    for (int i = 0; i < _boardSize; i++) {
      for (int j = 0; j < _boardSize; j++) {
	GameObject tile = (GameObject)Instantiate(BoardSquareTemplate, new Vector3(i,_boardYPos,j), Quaternion.identity);
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
    GameObject piece = (GameObject)Instantiate(BoardPieceTemplate, new Vector3(tileX,_pieceYPos,tileZ), Quaternion.identity);
    piece.name = "piece" + playerNum;

    PieceEntity entity = piece.GetComponent<PieceEntity>();
    entity.GameBoard = _board;
    entity.PlayerNum = playerNum;
    entity.MeshObject.renderer.material.color = playerNum == 0 ? Color.red : Color.blue;
    entity.MoveToTile(tileX, tileZ);
  }

  void AddPowerup(int tileX, int tileZ) {
    GameObject powerup = (GameObject)Instantiate(BoardPowerupTemplate, new Vector3(tileX,_pieceYPos,tileZ), Quaternion.identity);
    powerup.name = "powerup";

    PowerupEntity entity = powerup.GetComponent<PowerupEntity>();
    entity.GameBoard = _board;
    entity.MeshObject.renderer.material.color = Color.yellow;
    entity.PowerupType = "JumpProofPowerup";
    entity.MoveToTile(tileX, tileZ);
  }

  void EndTurn() {
    NextTurn();
  }

  void NextTurn() {
    ActivePlayer = (ActivePlayer + 1) % NumPlayers;
    Hashtable notifData = new Hashtable {
      {"activePlayerNum", ActivePlayer},
    }; 
    NotificationCenter.DefaultCenter.PostNotification(this, "StartTurn", notifData);    
  }

}
