using UnityEngine;
using System.Collections;
using System;

public abstract class Powerup : MonoBehaviour {
  public bool Active;

  public virtual void Apply() {
    Active = true;
  }

  public virtual void Remove() {
    Active = false;
    Destroy(this);
  }

  public virtual void PickedUp() {
  }
}
