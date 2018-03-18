using UnityEngine;

public class Raygun : MonoBehaviour {

    public float range = 50.0f;
    public float hitForce = 100.0f;

    public Transform spawnPoint;

    private Camera facing;

    public CrosshairChange crosshairChange = null;

    // Use this for initialization
    void Start () {
        facing = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {

        RaycastHit hit;
        Vector3 rayOrigin = facing.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        // fires a ray to the centre of the screen and applies force to any object
        if (Physics.Raycast (rayOrigin, facing.transform.forward, out hit, range)) {
            if (hit.transform.tag == "Interactive") {
                if (crosshairChange != null) {
                    crosshairChange.detected = true;
                }

    		    if (Input.GetMouseButton(0)) {
                    hit.rigidbody.AddForce(facing.transform.forward * hitForce);
                }
            } else if (hit.transform.tag != "Interactive" && crosshairChange != null) {
                crosshairChange.detected = false;
            }
        }
	}
}
