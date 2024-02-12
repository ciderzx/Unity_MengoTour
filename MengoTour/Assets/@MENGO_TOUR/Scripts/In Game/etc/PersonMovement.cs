using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovement : MonoBehaviour
{
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    private Transform cameraTransform;
    private InputManager inputManager;
    new Animator animation;

    private Joystick joystick;

    // Start is called before the first frame update
    void Start()
    {
        animation = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
        cameraTransform = Camera.main.transform;

        joystick = FindObjectOfType<Joystick>();
    }

    public Vector3 firstMovement()
    {
        float horizontal = joystick.Horizontal; // raw is "1 or -1" like digital value
        float vertical = joystick.Vertical; // raw is "1 or -1" like digital value

        // Vector3 move = transform.TransformVector(inputManager.GetMoveInput());
        horizontal = Input.GetAxis("Horizontal"); // raw is "1 or -1" like digital value
        vertical = Input.GetAxis("Vertical"); // no raw is like anlogue value, and smooth

        Vector3 move = new Vector3(horizontal, 0f, vertical);
        animation.SetBool("isWalk", true);

        controlTargetAngle(move.normalized);

        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0f;

        return move * 1f * 1.0f; //* MaxSpeedOnGround * speedModifier;
    }

    public Vector3 ThirdMovement()
    {
        float horizontal = joystick.Horizontal; // raw is "1 or -1" like digital value
        float vertical = joystick.Vertical; // raw is "1 or -1" like digital value

        horizontal = Input.GetAxisRaw("Horizontal"); // 1 or -1
        vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            Vector3 moveDir = Quaternion.Euler(0f, controlTargetAngle(direction), 0f) * Vector3.forward;
            // animation.SetBool("isWalk", true);
            return moveDir.normalized;
        }
        return direction * 3f * 2.0f; //* MaxSpeedOnGround * speedModifier;
    }

    // 캐릭터의 회전을 캠 화면에 맞게 조절한다.
    private float controlTargetAngle(Vector3 direction)
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y; // 앞을 기준으로 시계방향으로 기울기 값을 계산 * ???
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        return targetAngle;
    }
}
