using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkspeed = 10.0f;
    public float runspeed = 15.0f;
    public float mouseSensitivity = 100.0f;
    public LayerMask layerMask;

    private CharacterController characterController;
    private Vector3 movement;
    private Vector3 forward;
    bool running = false;


    private void Start()
    {
        characterController = GetComponent<CharacterController>();
       // Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0, vertical);
      //  movement = transform.TransformDirection(movement);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            PlayerWrapper.instance.PlayerAnimationController.EnableRunAnim();
            running = true;

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            PlayerWrapper.instance.PlayerAnimationController.DisableRunAnim();
            running = false;
 
        }
        movement = movement * (running ? runspeed : walkspeed);
        
        PlayerWrapper.instance.PlayerAnimationController.UpdateWalkAnim(movement.magnitude);

        characterController.Move(movement * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, mouseX * mouseSensitivity * Time.deltaTime);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, layerMask))
        {
            forward = hit.point - transform.position;
            forward.y = 0;
            forward = forward.normalized;
            Quaternion targetRotation = Quaternion.LookRotation(forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10);
        }
    }
}