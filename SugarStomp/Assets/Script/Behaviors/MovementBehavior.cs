using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MovementBehavior {
  public bool IsTileAccessible(int curX, int curZ, int targetX, int targetZ) {
    return Math.Abs(curX - targetX) <= 1 && Math.Abs(curZ - targetZ) <= 1;
  }
}
