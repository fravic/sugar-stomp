using UnityEngine;
using System.Collections;
using System;

public abstract class BoardEntity : MonoBehaviour {

  public virtual Board GameBoard { get; set; }
  public GameObject MeshObject = null;
  public virtual bool Selected { get; set; }

  public int GetTileX() {
    return (int)Math.Floor(transform.position.x);
  }

  public int GetTileZ() {
    return (int)Math.Floor(transform.position.z);
  }

  public void MoveToTile(int tileX, int tileZ) {
    Vector3 pos = new Vector3(tileX, gameObject.transform.position.y, tileZ);
    Hashtable tweenOptions = new Hashtable {
	{"position", pos},
	{"oncomplete", "MoveToTileComplete"},
	{"time", 0.5f}
    }; 
    iTween.MoveTo(gameObject, tweenOptions);
  }

  protected virtual void MoveToTileComplete() {
    GameBoard.UpdateEntPosition(this, GetTileX(), GetTileZ());
  }

  protected void AnimateToYPos(float yPos) {
    Vector3 newPos = new Vector3(gameObject.transform.position.x,
				 yPos,
				 gameObject.transform.position.z);
    iTween.MoveTo(gameObject, newPos, 0.5f);
  }

  protected virtual void CollideInto(BoardEntity collider) {
    collider.CollideReceived(this);
  }

  protected virtual void CollideReceived(BoardEntity collider) {
    DestroyEntity();
  }

  protected virtual void DestroyEntity() {
    GameBoard.RemoveEnt(this);

    Destroy(gameObject);
    Destroy(this);
  }

}
