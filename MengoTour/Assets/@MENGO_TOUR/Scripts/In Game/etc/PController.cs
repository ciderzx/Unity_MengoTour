using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PController : MonoBehaviour
{
    private CharacterController controller;
    private PersonMovement movement;
    private Transform cameraTransform;
    private InputManager inputManager;
    private string mode = ""; // TPV || FPV // first person view

    [SerializeField] private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 6.0f;
    [SerializeField] private float jumpHeight = 3.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private Vector3 verticalVelocity;
    private Vector3 playerMovement;
    new Animator animation;

    private JoyButton joybutton;
    private bool jump;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        inputManager = GetComponent<InputManager>();
        movement = GetComponent<PersonMovement>();
        animation = GetComponent<Animator>();
        joybutton = FindObjectOfType<JoyButton>();

        // inputManager = InputManager.Instance; // 임시

        mode = "TPV";
        // Cursor.lockState = CursorLockMode.Locked;
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        // 그라운드 체크
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && verticalVelocity.y < 0)
        {
            verticalVelocity.y = -2f;
        }

        // 시점 변환
        if (Input.GetKeyDown("c"))
        {
            if (mode == "FPV") mode = "TPV";
            else mode = "FPV";
        }
        switch (mode)
        {
            case "TPV": // third person view
                playerMovement = movement.ThirdMovement();
                break;
            case "FPV": // first person view
                playerMovement = movement.firstMovement();
                break;
            default:
                playerMovement = movement.firstMovement();
                break;
        }
        controller.Move(playerMovement * Time.deltaTime * playerSpeed);

        // 점프
        if (!jump && groundedPlayer && (joybutton.pressed || inputManager.GetJumpInputDown()))
        {
            verticalVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animation.SetBool("isJump", true);
            jump = true;
        }
        else
        {
            // animation.SetBool("isJump", false);
            jump = false;
        }

        // 중력
        verticalVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(verticalVelocity * Time.deltaTime);
    }
}