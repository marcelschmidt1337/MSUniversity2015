using UnityEngine;
using System.Collections;

public class CollidingBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCollisionEnter(Collision collision) {
        Weapon weapon = collision.collider.GetComponent<Weapon>();

        if (weapon != null) {
            Player weaponOwner = weapon.Owner;

            if (weaponOwner != null) {

                Car car = this.GetComponent<Car>();

                GameManager.Instance.WeaponCrashesCar(weaponOwner.ID, car.Owner.ID, weapon);
            }
        }
    }
}
