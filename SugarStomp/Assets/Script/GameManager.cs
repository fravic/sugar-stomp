using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int activePlayer = 1;
	public int gameState = 0;

	// Change the state of the game
	public void ChangeState(int _newState) {
		gameState = _newState;
	}

	void OnGUI() {
		// Handle GUI events. May be called several times per frame (once per GUI event)
		// Update labels, etc
	}
	
	void Start() {
		Debug.Log("Starting game!");

		// Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.	
		CreateBoard();
		AddPieces();
	}
	
	void CreateBoard() {
		// eg. Object.Instantiate(...);
	}
	
	void AddPieces() {
	}
}
