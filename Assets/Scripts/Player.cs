using UnityEngine;

[RequireComponent (typeof(CharacterController))]
[RequireComponent (typeof(Animator))]
public class Player : MonoBehaviour {
    CharacterController m_controller = null;
    Animator m_animator = null;

    // movement speeds
    public float walkSpeed = 80.0f;
    public float sprintSpeed = 80.0f;
    public float sneakSpeed = 80.0f;

    public float turnSpeed = 80.0f;

    public float m_pushPower = 2.0f;

    public float jumpStrength = 8.0f;
    public float gravity = 11.0f;

    public Vector3 moveDirection = Vector3.zero;

    public bool crouching = false;
    public bool grounded = false;
    public bool running = false;

    // Use this for initialization
    void Start () {
        m_controller = GetComponent<CharacterController>();
        m_animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Mouse X");
        
        m_controller.SimpleMove(transform.up * Time.deltaTime);

        transform.Rotate(transform.up, horizontal * turnSpeed * Time.deltaTime);

        m_animator.SetFloat("WalkSpeed", vertical * walkSpeed * Time.deltaTime);
        m_animator.SetFloat("SprintSpeed", vertical * sprintSpeed * Time.deltaTime);
        m_animator.SetFloat("SneakSpeed", vertical * sneakSpeed * Time.deltaTime);

        grounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);
        m_animator.SetBool("Grounded", grounded);

        crouching = Input.GetKey(KeyCode.LeftControl) && grounded;
        m_animator.SetBool("Crouching", crouching);

        running = Input.GetKey(KeyCode.LeftShift);
        m_animator.SetBool("Running", running);

        if (grounded) {
            moveDirection.y = 0;
        } else if (!grounded) { // if the player is grounded, stop applying gravity. If they are, apply gravity
            moveDirection.y -= gravity * Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && grounded && !crouching) {
            moveDirection.y = jumpStrength;
        }
        
        if (crouching && grounded) { // shrinks the hitbox while the player is crouching
            m_controller.center = new Vector3(0,0.5f,0); // moves the hitbpx position lower to match with where the player is
            m_controller.height = 1.0f; // reduces the height to match the player's crouch
        } else {
            m_controller.center = new Vector3(0, 1.0f, 0); // restores position
            m_controller.height = 2.0f; // restores hitbox height
        }

        m_controller.Move(moveDirection * Time.deltaTime);
	}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;

        if (hit.moveDirection.y < -0.3F)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
        body.velocity = pushDir * m_pushPower;
    }
}
