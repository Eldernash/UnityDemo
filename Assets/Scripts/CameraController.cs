using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {

    public float cameraSpeed = 1.0f;
    public float damping = 1.0f;
    public GameObject target;

    Vector3 positionOffSet;
    Vector3 aimOffset;

    // used for crosshairs in UI

    float mouseY;

    // Use this for initialization
    void Start() {
        positionOffSet = target.transform.position - transform.position;
        mouseY = 0;
        aimOffset = target.transform.position + new Vector3(0, 0.5f, 0);
    }

    // Update is called once per frame
    void LateUpdate() {
        // sets variables for transform
        aimOffset = target.transform.position + new Vector3(0, 0.5f, 0);
        mouseY += Input.GetAxis("Mouse Y");
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(-mouseY, desiredAngle, 0);
        transform.LookAt(aimOffset);

        // moves the camera towards the target based on x, y and z distances (moves slower when closer, etc.)
        Vector3 position = Vector3.Lerp(transform.position, target.transform.position - (rotation * positionOffSet), Time.deltaTime * damping);
        transform.position = position;
    }
}
