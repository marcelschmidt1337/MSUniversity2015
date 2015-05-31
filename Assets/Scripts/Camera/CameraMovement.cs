using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Vector3 PlayerMiddle = Vector3.zero;
        GameObject[] Players = GameManager.Instance.spawnPoints;

        foreach(GameObject Car in Players)
        {
            if(Car.activeInHierarchy)
            {
                PlayerMiddle += Car.transform.position / 2f ;
            }
        }

        transform.position = new Vector3(PlayerMiddle.x, transform.position.y, PlayerMiddle.z);

	}
}
