using UnityEngine;
using System.Collections;

public class HighScoreLogic : MonoBehaviour {

    [SerializeField]
    int weaponPoints = 100;

    [SerializeField]
    int crashPoints = 50;

    [SerializeField]
    int ragdollFlyPoints = 200;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int CrashPoints {
        get { return crashPoints; }
    }

    public int RagdollFlyPoints {
        get { return ragdollFlyPoints; }
    }

    public int WeaponPoints {
        get { return weaponPoints; }
    }
}
