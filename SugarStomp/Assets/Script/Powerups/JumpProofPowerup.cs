using UnityEngine;
using System.Collections;
using System;

public class JumpProofPowerup : Powerup {
  public override void PickedUp(PieceEntity owner) {
    base.PickedUp(owner);

    owner.MeshObject.renderer.material.color = Color.green;
  }

  public override void Apply() {
  }

  public override void Remove() {
  }
}
