using UnityEngine;
using System.Collections;
using System;

public class JumpProofPowerup : Powerup {
  public override void PickedUp() {
  }

  public override void Apply() {
    base.Apply();
    BoardEntity ent = gameObject.GetComponent<BoardEntity>();
    if (ent) {
      ent.MeshObject.renderer.material.color = Color.green;
    }
  }

  public override void Remove() {
  }
}
