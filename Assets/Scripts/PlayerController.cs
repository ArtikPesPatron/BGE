using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    private float _fallVelocity = 0;
    private Vector3 _moveVector;
    private int _runDir = 0;

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
        _fallVelocity += gravity * Time.fixedDeltaTime;

        _characterController.Move(_moveVector * Time.fixedDeltaTime * speed);
        _characterController.Move(Vector3.down * _fallVelocity * Time.deltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
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
        _runDir = 0;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            _runDir = 1;
        }


        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            _runDir = 2;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            _runDir = 3;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            _runDir = 4;
            
        }
        animator.SetInteger("RunDirection", _runDir);
    }
    private void JumpUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _runDir = 0;
            _runDir = 5;
            _fallVelocity = jumpForce * -1;
            animator.SetInteger("RunDirection", _runDir);
        }
    }
}
