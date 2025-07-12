using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class NavigatorController : MonoBehaviour
{
    private CharacterController characterController;
    private GameInputActions.NavigatorActions navigatorActions;

    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;

    private Vector3 playerVelocity;
    private bool isGrounded;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        navigatorActions = InputManager.Instance.GetGameInputActions().Navigator;

        navigatorActions.Jump.performed += OnJump;
        navigatorActions.Interact.performed += OnInteract;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    private void OnInteract(InputAction.CallbackContext context)
    {
        Debug.Log("Navigator interacted with an object.");
    }

    private void Update()
    {
        isGrounded = characterController.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 moveInput = navigatorActions.Move.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        characterController.Move(move * Time.deltaTime * moveSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravity * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);

        // Vector2 lookInput = navigatorActions.Look.ReadValue<Vector2>();
        // Logic to rotate the camera based on lookInput
    }
}
