using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerInputBehavior {
  public MovementBehavior Movement;
  public bool InputEnabled = true;

  public void ReadInputForEntity(BoardEntity entity) {
    Ray ray;
    RaycastHit hitInfo;

    if (!InputEnabled) {
      return;
    }

    if (Input.GetMouseButtonDown(0)) { // Left click
      ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      if (Physics.Raycast(ray, out hitInfo)) {
	if (hitInfo.collider.gameObject.transform.IsChildOf(entity.gameObject.transform)) {
	  entity.Selected = true;
	} else if (entity.Selected) {
	  int tileX = (int)Math.Floor(hitInfo.collider.gameObject.transform.position.x);
	  int tileZ = (int)Math.Floor(hitInfo.collider.gameObject.transform.position.z);
	  if (Movement.IsTileAccessible(entity.GameBoard, entity.GetTileX(), entity.GetTileZ(), tileX, tileZ)) {
	    entity.MoveToTile(tileX, tileZ);
	  }
        }
      }

    }
  }

}
