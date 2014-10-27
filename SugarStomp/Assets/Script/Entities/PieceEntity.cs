using UnityEngine;
using System;
using System.Collections;

public class PieceEntity : BoardEntity {

  public int PlayerNum = 0;
  
  private bool _selected = false;
  public override bool Selected {
    get { return _selected; }
    set {
      _selected = value;
      if (!_selected) {
	AnimateToYPos(_yPosDefault);
      } else {
	AnimateToYPos(_yPosSelected);
      }	
    }
  }

  private PlayerInputBehavior _inputBehavior;

  private float _yPosSelected = 1;
  private float _yPosDefault = 0;

  protected override void MoveToTileComplete() {
    BoardEntity collideEntity = GameBoard.GetEntAtTile(GetTileX(), GetTileZ());

    if (collideEntity != null) {
      CollideInto(collideEntity);
    }

    base.MoveToTileComplete();

    NotificationCenter.DefaultCenter.PostNotification(this, "EndTurn");
    this.Selected = false;
  }

  void Awake() {
    NotificationCenter.DefaultCenter.AddObserver(this, "StartTurn");

    // Just use default behaviors for now
    _inputBehavior = new PlayerInputBehavior();
    MovementBehavior movementBehavior = new MovementBehavior();
    _inputBehavior.Movement = movementBehavior;
  }

  void Update() {
    _inputBehavior.ReadInputForEntity(this);
  }

  void StartTurn(NotificationCenter.Notification notification) {
    if (notification.Data["activePlayerNum"] == null) {
      Debug.LogError("No activePlayerNum set in NextTurn notification");
      return;
    }
    _inputBehavior.InputEnabled = ((int)notification.Data["activePlayerNum"] == PlayerNum);
  }
}
