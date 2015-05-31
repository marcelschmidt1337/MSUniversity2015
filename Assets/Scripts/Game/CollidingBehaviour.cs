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

        Car crashingCar = collision.collider.GetComponent<Car>();
        Car car = this.GetComponent<Car>();

        if (weapon != null) {
            Player weaponOwner = weapon.Owner;

            if (weaponOwner != null) {

                GameManager.Instance.WeaponCrashesCar(weaponOwner.ID, car.Owner.ID, weapon);

                Debug.Log("Car collided with Weapon! Origin: " + weaponOwner.ID + " Victim: " + car.Owner.ID );
            }
        } else if (crashingCar != null) {
            GameManager.Instance.CarCrashesCar(crashingCar.Owner.ID, car.Owner.ID);

            Debug.Log("Car collided with other car " + crashingCar.Owner.ID + " Victim: " + car.Owner.ID);
        }
    }
}
