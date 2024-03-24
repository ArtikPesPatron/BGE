using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private float fallVelocity = 0;
    private Vector3 _moveVector;
    private int runDir = 0;

    public float gravity = 9.8f;
    public Animator animator;
    public float jumpForce;
    public float sprint;
    public float speed;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _characterController = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        fallVelocity += gravity * Time.fixedDeltaTime;

        _characterController.Move(_moveVector * Time.fixedDeltaTime * speed);
        _characterController.Move(Vector3.down * fallVelocity * Time.deltaTime);

        if (_characterController.isGrounded)
        {
            fallVelocity = 0;
        }
    }

    void Update()
    {
        MovementUpdate();
        JumpUpdate();
    }

    private void MovementUpdate()
    {
        _moveVector = Vector3.zero;
        runDir = 0;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            runDir = 1;
        }


        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            runDir = 2;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            runDir = 3;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            runDir = 4;
            
        }
        animator.SetInteger("RunDirection", runDir);
    }
    private void JumpUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            runDir = 0;
            runDir = 5;
            fallVelocity = jumpForce * -1;
            animator.SetInteger("RunDirection", runDir);
        }
    }
}
