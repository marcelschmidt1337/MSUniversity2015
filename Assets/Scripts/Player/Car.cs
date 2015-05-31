using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

    Player owner;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public Player Owner {

        get { return owner; }
        set { owner = value; }
    }
}
