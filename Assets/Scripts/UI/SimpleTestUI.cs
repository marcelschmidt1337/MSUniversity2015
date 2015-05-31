using UnityEngine;
using System.Collections;

public class SimpleTestUI : MonoBehaviour {

    GameManager gameManager;

	// Use this for initialization
	void Start () {
	
            gameManager = this.GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI() {
        GUI.Label(new Rect(0, 0, 100, 25), "PlayerCount: ");

        if (GUI.Button(new Rect(100, 0, 25, 25), "1")) {
            gameManager.StartGame(1);
        } else if (GUI.Button(new Rect(125, 0, 25, 25), "2")) {
            gameManager.StartGame(2);
        } else if (GUI.Button(new Rect(150, 0, 25, 25), "3")) {
            gameManager.StartGame(3);
        } else if(GUI.Button(new Rect(175, 0, 25, 25), "4")) {
            gameManager.StartGame(4);
        }
    }
}
