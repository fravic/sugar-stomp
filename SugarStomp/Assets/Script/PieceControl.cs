using UnityEngine;
using System.Collections;
using System;

public class PieceControl : MonoBehaviour {

  private bool _selected = false;

  void Awake () {
  }
	
  void Update () {
    ReadInput();
  }
	
  void ReadInput() {
    Ray ray;
    RaycastHit hitInfo;

    if (Input.GetMouseButtonDown(0)) { // Left click
      ray = Camera.main.ScreenPointToRay(Input.mousePosition);

      if (Physics.Raycast(ray, out hitInfo)) {
	if (hitInfo.collider.gameObject.transform.IsChildOf(gameObject.transform)) {
	  SelectPiece();
	} else if (_selected) {
	  MoveToTile((int)Math.Floor(hitInfo.collider.gameObject.transform.position.x),
		     (int)Math.Floor(hitInfo.collider.gameObject.transform.position.z));
        }
      }

    }
  }

  void SelectPiece() {
    if (!_selected) {
      AnimateToYPos(gameObject.transform.position.y + 1);
      _selected = true;
    }
  }

  void DeselectPiece() {
    if (_selected) {
      AnimateToYPos(gameObject.transform.position.y - 1);
      _selected = false;
    }
  }

  void AnimateToYPos(float yPos) {
    Vector3 newPos = new Vector3(gameObject.transform.position.x,
				 yPos,
				 gameObject.transform.position.z);
    iTween.MoveTo(gameObject, newPos, 0.5f);
  }

  void MoveToTile(int x, int z) {
    Vector3 pos = new Vector3(x, gameObject.transform.position.y, z);
    Hashtable tweenOptions = new Hashtable {
	{"position", pos},
	{"oncomplete", "DeselectPiece"},
	{"time", 0.5f}
    }; 
    iTween.MoveTo(gameObject, tweenOptions);
  }
}
