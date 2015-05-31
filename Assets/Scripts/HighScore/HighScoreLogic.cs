using UnityEngine;
using System.Collections;

public class HighScoreLogic : MonoBehaviour {

    [SerializeField]
    static int weaponPoints = 100;

    [SerializeField]
    static int crashPoints = 50;

    [SerializeField]
    static int ragdollFlyPoints = 200;

    [SerializeField]
    static int crownMultiplier = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static int CrashPoints {
        get { return crashPoints; }
    }

    public static int RagdollFlyPoints {
        get { return ragdollFlyPoints; }
    }

    public static int WeaponPoints {
        get { return weaponPoints; }
    }

    public static int CalculatePoints(Player player, PointType pointType) {

        int points = 0;

        int multiplier = player.HasCrown ? crownMultiplier : 1;

        switch (pointType) {
            case PointType.Crash:
                points = crashPoints;
                break;
            case PointType.Ragdoll:
                points = ragdollFlyPoints;
                break;
            case PointType.Weapon:
                points = weaponPoints;
                break;
            default:
                points = 0;
                break;
        }

        return points * multiplier;
    }
}

public enum PointType {
    Ragdoll,
    Weapon,
    Crash
}
