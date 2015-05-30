using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof(CarController))]
public class TestInput : MonoBehaviour 
{
    private CarController m_Car; // the car controller we want to use

    private void Awake()
    {
        Debug.Log("hi");
        // get the car controller
        m_Car = GetComponent<CarController>();
    }

    private void FixedUpdate()
    {
        // pass the input to the car!
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float handbrake = Input.GetAxis("Jump");
        m_Car.Move(h, v, v, handbrake);
    }
      
}
