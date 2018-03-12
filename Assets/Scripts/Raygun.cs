using UnityEngine;

public class Raygun : MonoBehaviour {

    public float range = 50.0f;
    public float hitForce = 100.0f;

    public Transform spawnPoint;

    private Camera facing;

	// Use this for initialization
	void Start () {
        facing = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {

            RaycastHit hit;

            Vector3 rayOrigin = facing.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));


            if (Physics.Raycast (rayOrigin, facing.transform.forward, out hit, range)) {
                if (hit.rigidbody != null) {
                    Debug.Log("Hit");
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }

        }
	}
}
