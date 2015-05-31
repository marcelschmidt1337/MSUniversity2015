using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {

    public Car CurrentOwner = null;

    void OnTriggerEnter(Collider other)
    {
        Car HittingCar = other.GetComponent<Car>();

        if (HittingCar == null)
        {
            return;
        }

        SetOwner(HittingCar);
    }

    void FixedUpdate()
    {
        if(CurrentOwner != null)
        {
            CurrentOwner.Owner.addScore(1);
        }
    }


    public void SetOwner(Car NewOwner)
    {
        CurrentOwner = NewOwner;
        transform.parent = NewOwner.transform;
        transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
        transform.localRotation = Quaternion.identity;

    }
}
