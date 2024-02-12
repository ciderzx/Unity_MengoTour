using UnityEngine;
using Cinemachine;
using System;
using Photon.Pun;

public class CinemachinePOVExtension : CinemachineExtension
{
    InputManager inputManager;

    private Vector3 startingRotation;
    private float horizontalSpeed = 80f;
    private float verticalSpeed = 80f;
    private float clampVerticalAngle = 89f;
    private float clampHorizontalAngle = 60f;

    private Transform playerBody;

    private CinemachineVirtualCamera camera;
    private GameObject playerLookAt;
    private GameObject playerTarget;


    private JoyPanelHandler look;

    protected override void Awake()
    {
        camera = GetComponent<CinemachineVirtualCamera>();
        inputManager = GetComponent<InputManager>();
        look = FindObjectOfType<JoyPanelHandler>();
        base.Awake();
    }

    private void Start()
    {
        Init();
        camera.LookAt = playerLookAt.transform;
        camera.Follow = playerTarget.transform;
        playerBody = PTPlayerSpawnManager.Instance.GetMyPlayer().transform;
    }

    private void Init()
    {
        playerLookAt = PTPlayerSpawnManager.Instance.GetMyPlayer().MyLookAt;
        playerTarget = PTPlayerSpawnManager.Instance.GetMyPlayer().MyTarget;
    }

    private void Update()
    {
        //if (!PhotonView.FindObjectOfType<PhotonView>().IsMine) return;

        Vector2 delta = look.LookValue;
        // player 방향 제어 (!수정 필요)
        playerBody.Rotate(Vector3.up * delta.x * verticalSpeed * Time.deltaTime);
        // playerBody.Rotate(Vector3.up * Input.GetAxis("Mouse X") * verticalSpeed * Time.deltaTime);
    }
    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        //if (!PhotonView.FindObjectOfType<PhotonView>().IsMine) return;

        Vector2 delta = look.LookValue;
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                if (startingRotation == null) startingRotation = transform.localRotation.eulerAngles;
                startingRotation.x += delta.x * verticalSpeed * Time.deltaTime;
                // if (startingRotation.x >= clampHorizontalAngle || startingRotation.x <= -clampHorizontalAngle)
                // playerBody.Rotate(Vector3.up * delta.x * verticalSpeed * Time.deltaTime);

                // startingRotation.x = Mathf.Clamp(startingRotation.x, -clampHorizontalAngle, clampHorizontalAngle);

                startingRotation.y += delta.y * horizontalSpeed * Time.deltaTime;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampVerticalAngle, clampVerticalAngle);
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
            }
        }
    }

    private void characterRotationHandler()
    {

    }
}
