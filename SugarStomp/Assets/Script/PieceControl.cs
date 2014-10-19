using UnityEngine;
using System.Collections;

public class PieceControl : MonoBehaviour {
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
	Debug.Log(hitInfo.collider.gameObject.transform.position.x);
	gameObject.transform.position =
	  new Vector3(hitInfo.collider.gameObject.transform.position.x,
		      gameObject.transform.position.y,
 		      hitInfo.collider.gameObject.transform.position.z);
      }

    }
  }
}
