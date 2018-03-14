using UnityEngine;

public class CameraController : MonoBehaviour {

    public float cameraSpeed = 1.0f;
    public float damping = 1.0f;
    public GameObject target;
    Vector3 offSet;
    Vector3 positionOffSet;

    float mouseY;

    // Use this for initialization
    void Start()
    {
        offSet = target.transform.position - transform.position;
        mouseY = 0;
        positionOffSet = target.transform.position + new Vector3(0, 0.5f, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        positionOffSet = target.transform.position + new Vector3(0, 0.5f, 0);
        mouseY += Input.GetAxis("Mouse Y");
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(-mouseY, desiredAngle, 0);
        transform.LookAt(positionOffSet);
        Vector3 position = Vector3.Lerp(transform.position, target.transform.position - (rotation * offSet), Time.deltaTime * damping);
        transform.position = position;
    }
}
