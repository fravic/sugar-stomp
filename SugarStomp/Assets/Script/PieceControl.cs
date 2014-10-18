using UnityEngine;
using System.Collections;

public class PieceControl : MonoBehaviour {
  private Camera _camera;
	
  void Awake () {
    _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
  }
	
  void Update () {
    ReadInput();
  }
	
  void ReadInput() {
    Ray ray;
    RaycastHit hitInfo;

    if (Input.GetMouseButtonDown(0)) { // Left click
      ray = _camera.ScreenPointToRay(Input.mousePosition);

      if (Physics.Raycast(ray, out hitInfo)) {
	gameObject.transform.position =
	  new Vector3(hitInfo.collider.gameObject.transform.position.x,
		      gameObject.transform.position.y,
		      hitInfo.collider.gameObject.transform.position.z);
      }

    }
  }
}
