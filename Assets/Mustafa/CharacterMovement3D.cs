using UnityEngine;

public class CharacterMovement3D : MonoBehaviour
{
    public float speed = 10f;

    private CharacterController characterController;
    private Vector3 movement;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0, vertical);
        movement = transform.TransformDirection(movement);
        movement *= speed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        characterController.Move(movement);
    }
}