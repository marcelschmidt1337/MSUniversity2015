using UnityEngine;
using System.Collections;
using XInputDotNetPure;
using UnityStandardAssets.Vehicles.Car;

[RequireComponent(typeof(CarController))]
public class XInputControlled : MonoBehaviour {

    public PlayerIndex PlayerIndex;

    private CarController Car;

    private void Awake()
    {
        Car = GetComponent<CarController>();
    }
	
	// Update is called once per frame
	void Update () {
        GamePadState CurrentState = GamePad.GetState(PlayerIndex);
        if(!CurrentState.IsConnected)
        {
            return;
        }

        Car.Move(CurrentState.ThumbSticks.Left.X, CurrentState.Triggers.Right, -CurrentState.Triggers.Left, CurrentState.Buttons.A == ButtonState.Pressed ? 1f : 0f);

	}
}
