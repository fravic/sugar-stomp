using UnityEngine;
using System.Collections;
 
public class CameraFacingBillboard : MonoBehaviour {
  private Camera _camera;

  void Awake () {
    transform.LookAt(Camera.main.transform);
    transform.Rotate(Vector3.right * 90);
  }

  void Update() {
  }
}
