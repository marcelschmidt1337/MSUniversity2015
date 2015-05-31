using UnityEngine;
using System.Collections;

public class AnimatedCamera : MonoBehaviour {
    public float Radius = 3.0f;
    public float Speed = 25.0f;
    public Transform LookAt;

    private double CurrentAngle;
    private Vector3 NewPosition;

    void FixedUpdate()
    {
        this.CurrentAngle += Time.deltaTime * this.Speed;
        if(this.CurrentAngle > 360f)
        {
            this.CurrentAngle = 0;
        }

        float angle = (float)ConvertToRadians(this.CurrentAngle);
        this.NewPosition.x = this.Radius * Mathf.Cos(angle);
        this.NewPosition.y = this.transform.position.y;
        this.NewPosition.z = this.Radius * -Mathf.Sin(angle);

        this.transform.position = this.NewPosition;
        this.transform.LookAt(this.LookAt);
    }

    private double ConvertToRadians(double angle)
    {
        return (Mathf.PI / 180) * angle;
    }
}
