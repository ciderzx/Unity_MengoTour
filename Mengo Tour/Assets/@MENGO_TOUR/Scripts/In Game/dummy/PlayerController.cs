using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace MENGO_TOUR.Game
{

    [RequireComponent(typeof(Player))]
    public class PlayerController : MonoBehaviourPunCallbacks, IPunObservable
    {
        private Player m_Character; // A reference to the ThirdPersonCharacter on the object
        private Transform m_Cam;                  // A reference to the main camera in the scenes transform
        private Vector3 m_CamForward;             // The current forward direction of the camera
        private Vector3 m_Move;
        private bool m_Jump;                      // the world-relative desired move direction, calculated from the camForward and user input.
        private PhotonView myPhoton;

        private JumpButton m_JumpButton;
        private CrouchButton m_CrouchButton;
        private Joystick m_JoyStick;
        private Transform myTrans;

        private void Awake()
        {
            myPhoton = GetComponent<PhotonView>();
            myTrans = GetComponent<Transform>();
        }

        private void Start()
        {
            if (!myPhoton.IsMine) return;

            // get the transform of the main camera
            if (Camera.main != null)
            {
                m_Cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Third person character needs a Camera tagged \"MainCamera\", for camera-relative controls.", gameObject);
                // we use self-relative controls in this case, which probably isn't what the user wants, but hey, we warned them!
            }

            // get the third person character ( this should never be null due to require component )
            m_Character = GetComponent<Player>();
            // get the Joystick control value
            m_JumpButton = FindObjectOfType<JumpButton>();
            m_CrouchButton = FindObjectOfType<CrouchButton>();
            m_JoyStick = FindObjectOfType<Joystick>();
        }


        private void Update()
        {
            if (!myPhoton.IsMine) return;

            if (!m_Jump)
            {
                m_Jump = Input.GetButtonDown("Jump") || m_JumpButton.pressed;
            }
        }


        // Fixed update is called in sync with physics
        private void FixedUpdate()
        {
            if (!myPhoton.IsMine) return;

            // read inputs (by joystick)
            float h = m_JoyStick.Horizontal;
            float v = m_JoyStick.Vertical;
            // float h = Input.GetAxis("Horizontal");
            // float v = Input.GetAxis("Vertical");
            bool crouch = Input.GetKey(KeyCode.C) || m_CrouchButton.pressed;

            // calculate move direction to pass to character
            if (m_Cam != null)
            {
                // calculate camera relative direction to move:
                m_CamForward = Vector3.Scale(m_Cam.forward, new Vector3(1, 0, 1)).normalized;
                m_Move = v * m_CamForward + h * m_Cam.right;
            }
            else
            {
                Debug.Log("no cam");
                // we use world-relative directions in the case of no main camera
                m_Move = v * Vector3.forward + h * Vector3.right;
            }
#if !MOBILE_INPUT
            // walk speed multiplier
            if (Input.GetKey(KeyCode.LeftShift)) m_Move *= 0.5f;
#endif

            // pass all parameters to the character control script
            m_Character.Move(m_Move, crouch, m_Jump);
            m_Jump = false;
        }

        private Vector3 curPos;
        private Quaternion curRot;

        public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(myTrans.position);
                stream.SendNext(myTrans.rotation);
            }
            else
            {
                curPos = (Vector3)stream.ReceiveNext();
                curRot = (Quaternion)stream.ReceiveNext();
            }
        }
    }
}
