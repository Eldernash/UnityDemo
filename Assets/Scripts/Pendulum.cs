using UnityEngine;

public class Pendulum : MonoBehaviour {

    public Transform pendulumArm;

    public float maximumAngle = 90.0f;
    public float rotationSpeed = 10.0f;

    private float rotationSpeedNegative;

    HingeJoint joint;
    JointMotor motor;
    
	// Use this for initialization
	void Start () {
        joint = gameObject.GetComponent<HingeJoint>();
        motor = joint.motor;
        rotationSpeedNegative = rotationSpeed * -1;
    }
	
	// Update is called once per frame
	void Update () {
        float angle = pendulumArm.rotation.z;

        if (angle > maximumAngle)
        {
            motor.targetVelocity = rotationSpeedNegative;
        }
        if (angle < -maximumAngle) {
            motor.targetVelocity = rotationSpeed;
        }

        motor.force = 3.402823e+38f;
        motor.freeSpin = false;
        joint.motor = motor;
        joint.useMotor = true;
	}
}
