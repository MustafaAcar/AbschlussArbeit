using UnityEngine;
using System.Collections;

public class CharMover : MonoBehaviour
{
    public float MovementSpeed = 5.0f;
    private CharacterController charContr;

    void Awake()
    {
        charContr = GetComponent<CharacterController>();
    }

	void Update()
    {
        Movement();
	}

    private void Movement()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        move = move.normalized;
        move *= Time.deltaTime * MovementSpeed;
        Debug.Log(move);

        charContr.Move(move);
    }
}
