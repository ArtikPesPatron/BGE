using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float sprint;

    public float jumpForce;

    public float gravity = 9.8f;

    private CharacterController _characterController;

    private float fallVelocity = 0;

    public float speed;

    private Vector3 _moveVector;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _characterController.Move(_moveVector * Time.fixedDeltaTime * speed);

        fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * fallVelocity * Time.deltaTime);
    }

    void Update()
    {
        if (_characterController.isGrounded)
        {
            fallVelocity = 0;
        }

        _moveVector = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            fallVelocity = jumpForce * -1;
        }
    }
}
