using UnityEngine;
using System.Collections;
using System;

public class PowerupEntity : BoardEntity {

  public string PowerupType;

  protected override void CollideReceived(BoardEntity collider) {
    if (PowerupType == null) {
      Debug.LogWarning("PowerupEntity has no PowerupType");
    }

    PieceEntity ent = (PieceEntity)collider;
    Powerup powerup = (Powerup)ent.gameObject.AddComponent(PowerupType);
    powerup.PickedUp();

    // Auto-apply powerups for now
    powerup.Apply();

    base.CollideReceived(collider);
  }

}
