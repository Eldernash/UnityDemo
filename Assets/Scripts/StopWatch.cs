using UnityEngine;
using UnityEngine.UI;

public class StopWatch : MonoBehaviour {

    public bool timing;

    float time;
    public Text textField;

    // Use this for initialization
    void Start () {
        textField = GetComponent<Text>();
        time = 0.0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (timing) {
            time += 1 * Time.deltaTime;
        }

        textField.text = "Time: " + time;
	}
}
