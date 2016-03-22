using UnityEngine;
using System.Collections;

public class CharMover : MonoBehaviour
{
    public float MovementSpeed = 5.0f;
    public float RotationSpeed = 200.0f;
    public float JumpStrength = 5.0f;
    public float SprintSpeed = 15.0f;
    public Transform Head;

    private CharacterController charContr;
    private float m_ySpeed = 0.0f;
    private float m_movementSpeed;

    void Awake()
    {
        charContr = GetComponent<CharacterController>();
    }

	void Update()
    {
        Movement();
        Rotation();
	}

    private void Movement()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        move = move.normalized;

        if (Input.GetKey(KeyCode.LeftControl)) // Sprintfeature
        {
            m_movementSpeed = SprintSpeed;
        }
        else
        {
            m_movementSpeed = MovementSpeed;
        }

        move *= Time.deltaTime * m_movementSpeed;
        move = transform.TransformDirection(move);


        if (charContr.isGrounded) // Jumpfeature
        {
            if (Input.GetButtonDown("Jump"))
            {
                m_ySpeed = JumpStrength;
            }
            else
            {
                m_ySpeed = -0.1f;
            }

        }
        else
        {
            m_ySpeed += Physics.gravity.y * Time.deltaTime * 0.1f;
        }
        move.y = m_ySpeed;

        charContr.Move(move);
    }

    private void Rotation() // Looking around
    {
        float input = Input.GetAxis("Mouse X");
        input *= RotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.up, input);

        input = Input.GetAxis("Mouse Y");
        input *= RotationSpeed * Time.deltaTime;

        Head.Rotate(Vector3.left, input);
    }
}
