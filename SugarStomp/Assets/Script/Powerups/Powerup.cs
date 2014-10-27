using UnityEngine;
using System.Collections;
using System;

public abstract class Powerup {
  private PieceEntity _owner;

  public abstract void Apply();
  public abstract void Remove();

  public virtual void PickedUp(PieceEntity owner) {
    _owner = owner;
  }
}
