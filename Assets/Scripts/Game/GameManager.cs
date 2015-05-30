using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    
    [SerializeField]
    GameObject[] spawnPoints;

    [SerializeField]
    int playercount;

    [SerializeField]
    int crashDamagePoints = 1;

    [SerializeField]
    Player playerprefab;

    [SerializeField]
    GameObject carPrefab;

    HighScoreLogic highscorelogic;

    private Player[] player;

    // Static singleton instance
    private static GameManager instance;
     
    // Static singleton property
    public static GameManager Instance
    {
        get { return instance ?? (instance = new GameObject("GameManager").AddComponent<GameManager>()); }
    }

    public int PlayerCount {
        get { return playercount; }
        set { playercount = value; }
    }

    public void CarCrashesCar(int origin, int victim) {
        player[victim].addLivePoints(-crashDamagePoints);
    }

    public void WeaponCrashesCar(int origin, int victim, Weapon weapon) {
        player[victim].addLivePoints(-crashDamagePoints);
    }

    public void RagdollFlies(int origin, int victim) {
        player[victim].addLivePoints(-crashDamagePoints);
    }

    public void StartGame(int playerCount) {

        highscorelogic = new HighScoreLogic();

        PlayerCount = playerCount;
        player = new Player[playercount];

        for (int i = 0; i < playercount; i++) {
            SpawnPlayer(i);
        } 
    }

    public void SpawnPlayer(int id) {
        player[id] = GameObject.Instantiate<Player>(playerprefab);

        Player playerData = player[id].GetComponent<Player>();

        int spawnPointIndex = Random.Range(0, spawnPoints.Length - 1);

        GameObject playerVehicle = GameObject.Instantiate<GameObject>(carPrefab);

        playerVehicle.transform.position = spawnPoints[spawnPointIndex].transform.position;

    }
 

}