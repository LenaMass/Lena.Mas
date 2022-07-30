using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPController : MonoBehaviour
{
    // Camera Variables
    [SerializeField] private Transform cameraTarget;
    private Camera mainCamera;

    
    private float verticalRotationLimit;

    // Mouse Variables 
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private float lookUpConstraint;
    [SerializeField] private float lookDownConstraint;
    [SerializeField] private bool invertMouse = false;

    // Movement Variables 
    public float WalkSpeed;
    public float RunSpeed;
    private CharacterController charController;
    private Vector3 movement;


    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }

    // Update is called once every frame
    private void Update()
    {
        // Mouse Input
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
        
        //Rotation the player horizontally based on Mouse X Input 
        float yRotation = transform.rotation.eulerAngles.y + mouseInput.x;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, yRotation, transform.rotation.eulerAngles.z);
        
        // Mouse Invert Preference 
        float invert = (!invertMouse) ? -1f : 1f;
        verticalRotationLimit += (mouseInput.y * invert);

        // Limit the X axis rotation based on input
        verticalRotationLimit = Mathf.Clamp(verticalRotationLimit, lookDownConstraint, lookUpConstraint);

        //Applies rotation to the camera target
        cameraTarget.rotation = Quaternion.Euler(verticalRotationLimit, cameraTarget.eulerAngles.y, cameraTarget.eulerAngles.z);

        //User input for moving 
        Vector3 moveForward = transform.forward * Input.GetAxisRaw("Vertical");
        Vector3 moveRight = transform.right * Input.GetAxisRaw("Horizontal");

        //set movement speed based on if the player is holding down left shift
        float currentSpeed = (Input.GetKey(KeyCode.LeftShift)) ? RunSpeed : WalkSpeed;


        // Generate movement 
        movement = (moveForward + moveRight).normalized * currentSpeed;
        charController.Move(movement * Time.deltaTime);

    }


    // LateUpdate is called after Update()
    void LateUpdate()
    {
        mainCamera.transform.position = cameraTarget.position;
        mainCamera.transform.rotation = cameraTarget.rotation;
    }
}
