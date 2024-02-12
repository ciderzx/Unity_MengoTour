using UnityEngine;
using Cinemachine;
using Photon.Pun;

[RequireComponent(typeof(CinemachineFreeLook))]
public class ThirdPersonCamController : MonoBehaviour
{
    private CinemachineFreeLook cinemachine;
    private JoyPanelHandler look;
    private float rotateSpeed = 1.0f;

    private GameObject playerLookAt;
    private GameObject playerTarget;

    private void Awake()
    {
        look = FindObjectOfType<JoyPanelHandler>();
        cinemachine = GetComponent<CinemachineFreeLook>();
    }

    private void Start()
    {
        Init();
        cinemachine.LookAt = playerLookAt.transform;
        cinemachine.Follow = playerTarget.transform;
    }

    void Update()
    {
        //if (!PhotonView.FindObjectOfType<PhotonView>().IsMine) return;
        
        Vector2 delta = look.LookValue;
        cinemachine.m_XAxis.Value += delta.x * Time.deltaTime * 200f * rotateSpeed;
        cinemachine.m_YAxis.Value -= delta.y * Time.deltaTime * rotateSpeed;
    }

    private void Init()
    {
        playerLookAt = PTPlayerSpawnManager.Instance.GetMyPlayer().MyLookAt;
        playerTarget = PTPlayerSpawnManager.Instance.GetMyPlayer().MyTarget;
    }
}
