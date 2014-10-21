using UnityEngine;
using System.Collections;
using System;

public class PieceEntity : BoardEntity {

  public int PlayerNum = 0;
  public bool InputEnabled = true;

  private bool _selected = false;
  private float _yPosSelected = 1;
  private float _yPosDefault = 0;

  protected override void MoveToTileComplete() {
    BoardEntity collideEntity = GameBoard.GetPieceAtTile(GetTileX(), GetTileZ());

    base.MoveToTileComplete();

    if (collideEntity != null) {
      CollideInto(collideEntity);
    }

    NotificationCenter.DefaultCenter.PostNotification(this, "EndTurn");
    DeselectPiece();
  }

  void Awake() {
    NotificationCenter.DefaultCenter.AddObserver(this, "StartTurn");
  }

  void Update() {
    if (InputEnabled) {
      ReadInput();	
    }
  }

  void StartTurn(NotificationCenter.Notification notification) {
    if (notification.Data["activePlayerNum"] == null) {
      Debug.LogError("No activePlayerNum set in NextTurn notification");
      return;
    }
    InputEnabled = ((int)notification.Data["activePlayerNum"] == PlayerNum);
  }

  void ReadInput() {
    Ray ray;
    RaycastHit hitInfo;

    if (Input.GetMouseButtonDown(0)) { // Left click
      ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      if (Physics.Raycast(ray, out hitInfo)) {
	if (hitInfo.collider.gameObject.transform.IsChildOf(gameObject.transform)) {
	  SelectPiece();
	} else if (_selected) {
	  int tileX = (int)Math.Floor(hitInfo.collider.gameObject.transform.position.x);
	  int tileZ = (int)Math.Floor(hitInfo.collider.gameObject.transform.position.z);
	  if (IsTileAccessible(tileX, tileZ)) {
	    MoveToTile(tileX, tileZ);
	  }
        }
      }

    }
  }

  void SelectPiece() {
    if (!_selected) {
      AnimateToYPos(_yPosSelected);
      _selected = true;
    }
  }

  void DeselectPiece() {
    if (_selected) {
      AnimateToYPos(_yPosDefault);
      _selected = false;
    }
  }

  bool IsTileAccessible(int tileX, int tileZ) {
    return Math.Abs(transform.position.x - tileX) <= 1 &&
      Math.Abs(transform.position.z - tileZ) <= 1;
  }

}
