using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int id;

    [SerializeField]
    private int livepoints = 3;

    [SerializeField]
    private GameObject weapon;

    private int score = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int ID {

        get { return id; }
        set {
                id = value;
        }
    }

    public int LivePoints {
        get { return livepoints; }
        set {
            livepoints = value;
        }
    }

    public void addLivePoints(int livepoints) {
        LivePoints = LivePoints - livepoints;
    }


    public int Score {
        get {
            return score;
        }
    }

    public void addScore(int points) {
        score += points;
    }
}
