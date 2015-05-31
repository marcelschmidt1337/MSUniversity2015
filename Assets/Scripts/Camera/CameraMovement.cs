using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Vector3 PlayerMiddle = Vector3.zero;
        Vector3 TopLeft = Vector3.zero;
        Vector3 BottomRight = Vector3.zero;

        GameObject[] Players = GameManager.Instance.spawnPoints;

        foreach(GameObject Car in Players)
        {
            if(Car.activeInHierarchy)
            {
                if(Car.transform.position.x > TopLeft.x)
                {
                    TopLeft.x = Car.transform.position.x;
                }

                if (Car.transform.position.y < TopLeft.y)
                {
                    TopLeft.y = Car.transform.position.y;
                }

                if (Car.transform.position.x < BottomRight.x)
                {
                    BottomRight.x = Car.transform.position.x;
                }

                if (Car.transform.position.y > BottomRight.y)
                {
                    BottomRight.y = Car.transform.position.y;
                }

                PlayerMiddle += Car.transform.position / 2f ;
            }
        }

        transform.position = new Vector3(PlayerMiddle.x, transform.position.y, PlayerMiddle.z);
        Debug.Log(Vector3.Distance(TopLeft, BottomRight));
	}
}
