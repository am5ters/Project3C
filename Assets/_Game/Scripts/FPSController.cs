using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FPSController : MonoBehaviour
{
    [Tooltip("Insert player camera here")]
    public Camera playerCamera;

    [SerializeField]
    private string _name;

    [Header("Movement Speed")]
    [SerializeField]
    [Range(1, 50)]
    public float walkSpeed = 6f;
    [SerializeField]
    [Range(1, 100)]
    public float runSpeed = 12f;

    [Header("Weeeee")]
    [SerializeField]
    [Range(0, 100)]
    [Tooltip("How strong are your legs?")]
    public float jumpPower = 7f;
    [SerializeField]
    [Range(0, 100)]
    [Tooltip("How strong is gravity?")]
    public float gravity = 10f;

    [Header("Camera Movement")]
    [Tooltip("How fast you can turn your head")]
    public float lookSpeed = 2f;
    [Tooltip("How far you can turn your head")]
    public float lookXLimit = 45f;

    [Header("Can I move?")]
    public bool canMove = true;

    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        #region Handles Movement
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        //Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        #endregion

        #region Handles Jumping
        //initializes jump when jump button is pressed 
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }
        
        //if character controller ISN'T off the ground, apply gravity
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        #endregion

        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion
    }
}
