using UnityEngine;

public class MouseRotate : MonoBehaviour {
    
    public float m_speed = 1.0f;

    public float m_upperLimit = 50.0f;
    public float m_lowerLimit = -50.0f;
    
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 turnAmount = new Vector3(0, 0, 0);

        float turn = Input.GetAxis("Mouse Y");
        turnAmount.Set(-turn, 0, 0);
        turnAmount.x = Mathf.Clamp(turnAmount.x, m_lowerLimit, m_upperLimit);
        transform.Rotate(turnAmount * m_speed * Time.deltaTime);
    }
}
