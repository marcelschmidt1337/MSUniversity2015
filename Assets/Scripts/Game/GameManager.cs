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

	[SerializeField]
	float initialGameTime;

	private float timer;
	private bool gameStarted = false;

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
        DamagePlayer(victim, -crashDamagePoints);
        AddHighScorePoints(origin, PointType.Crash);
    }

    public void WeaponCrashesCar(int origin, int victim, Weapon weapon) {
        DamagePlayer(victim, -crashDamagePoints);
        AddHighScorePoints(origin, PointType.Weapon);
    }

    public void RagdollFlies(int origin, int victim) {
        DamagePlayer(victim, -crashDamagePoints);
        AddHighScorePoints(origin, PointType.Ragdoll);
    }

    public void StartGame(int playerCount) {

        PlayerCount = playerCount;
        player = new Player[playercount];

        gameStarted = true;

        for (int i = 0; i < playercount; i++) {
            SpawnPlayer(i);
        }

		timer = initialGameTime;
    }

    public void SpawnPlayer(int id) {
        player[id] = GameObject.Instantiate<Player>(playerprefab);

        Player playerData = player[id].GetComponent<Player>();

        player[id] = playerData;

        playerData.IsAlive = true;

        int spawnPointIndex = Random.Range(0, spawnPoints.Length - 1);

        GameObject playerVehicle = GameObject.Instantiate<GameObject>(carPrefab);

        playerVehicle.transform.position = spawnPoints[spawnPointIndex].transform.position;

    }

    private void AddHighScorePoints(int playerId, PointType damageType) {

        Player toReward = player[playerId];

        int points = HighScoreLogic.CalculatePoints(player[playerId], damageType);

        toReward.addScore(points);

    }

    private void DamagePlayer(int playerId, int damagePoints) {
        player[playerId].addLivePoints(-damagePoints);

        int livingPlayers = 0;

        if (!player[playerId].IsAlive) {
            for (int i = 0; i < PlayerCount; i++) {
                livingPlayers += player[i].IsAlive ? 1 : 0; 
            }
        }

        if (livingPlayers == 1) {
            gameStarted = false;
        } else if (livingPlayers > 1) {

        }
    }

	void Update () {
		if (gameStarted) {
			timer -= Time.deltaTime;

			if (timer <= 0) {
				gameStarted = false;
			}
		}
	}


 

}