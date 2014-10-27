using UnityEngine;
using System.Collections;
using System;

public class PowerupEntity : BoardEntity {

  public Powerup Power;

  protected override void CollideReceived(BoardEntity collider) {
    if (Power == null) {
      Debug.LogWarning("PowerupEntity has no Power attached");
    }

    Power.PickedUp((PieceEntity)collider);

    base.CollideReceived(collider);
  }

}
