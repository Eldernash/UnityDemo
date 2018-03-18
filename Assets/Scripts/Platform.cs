using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

    public Transform startPosition;
    public Transform endPosition;

    public float moveSpeed = 10;

    public bool goingToEnd = true;

    private float startTime;
    private float travelDistance;
    // Use this for initialization
    void Start () {
        startTime = Time.time;
        travelDistance = Vector3.Distance(startPosition.position, endPosition.position);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector3 newPosition = new Vector3(0,0,0);

        float distTravelled = (Time.time - startTime) * moveSpeed;
        float fracJourney = distTravelled / travelDistance;

        if (goingToEnd)
        {
            newPosition = Vector3.Lerp(transform.position, endPosition.transform.position, fracJourney);
        } else {
            newPosition = Vector3.Lerp(transform.position, startPosition.transform.position, fracJourney);
        }

        transform.position = newPosition;

        if (transform.position == startPosition.transform.position) {
            goingToEnd = true;
        } else if (transform.position == endPosition.transform.position) {
            goingToEnd = false;
        }
    }
}
