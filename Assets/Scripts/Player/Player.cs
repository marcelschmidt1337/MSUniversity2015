using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private int id;

    [SerializeField]
    private int livepoints = 3;

    [SerializeField]
    private GameObject weapon;

    private int score = 0;

    private bool hasCrown = false;

    private bool isAlive = false;


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

    public bool HasCrown {
        get { return hasCrown; }
        set { hasCrown = value; }
    }

    public bool IsAlive {
        get { return isAlive; }
        set { isAlive = value; }
    }

    public void addLivePoints(int livepoints) {
        LivePoints = LivePoints - livepoints;
        if (LivePoints <= 0) {
            LivePoints = 0;
        }
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
