using UnityEngine;

public class StartLine : MonoBehaviour {

    public bool finishLine = false;
    public StopWatch stopWatch;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if (!finishLine) {
            stopWatch.timing = true;
        } else {
            stopWatch.timing = false;
        }
    }
}
