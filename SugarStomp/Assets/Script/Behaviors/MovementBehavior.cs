using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MovementBehavior {
  public Board GameBoard;

  public bool IsTileAccessible(Board gameBoard, int curX, int curZ, int targetX, int targetZ) {
    return TileIsAccessibleFromPoint(gameBoard, curX, curZ, targetX, targetZ) &&
      EntityAtTileIsAccessible(gameBoard, targetX, targetZ);
  }

  protected virtual bool EntityAtTileIsAccessible(Board gameBoard, int targetX, int targetZ) {
    BoardEntity ent = gameBoard.GetEntAtTile(targetX, targetZ);
    if (ent != null) {
      JumpProofPowerup powerup = ent.GetComponent<JumpProofPowerup>();
      return !(powerup != null && powerup.Active);
    }
    return true;
  }

  protected virtual bool TileIsAccessibleFromPoint(Board gameBoard, int curX, int curZ, int targetX, int targetZ) {
    return Math.Abs(curX - targetX) + Math.Abs(curZ - targetZ) <= 1;
  }
}
