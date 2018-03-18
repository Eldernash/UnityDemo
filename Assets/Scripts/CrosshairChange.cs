using UnityEngine;
using UnityEngine.UI;

public class CrosshairChange : MonoBehaviour {
    
    public Sprite unTargetted;
    public Sprite targetted;

    public bool detected = false;

    Image crosshair;

    // Use this for initialization
    void Start () {
        crosshair = gameObject.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
        crosshair.enabled = detected;
    }
}
