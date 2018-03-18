using UnityEngine;

public class StartLine : MonoBehaviour {

    public bool finishLine = false;
    public StopWatch stopWatch;

    private void OnTriggerEnter(Collider other) {
        // if the collider is a start line, start the timer, otherwise, pause it
        if (!finishLine) {
            stopWatch.timing = true;
        } else {
            stopWatch.timing = false;
        }
    }
}
