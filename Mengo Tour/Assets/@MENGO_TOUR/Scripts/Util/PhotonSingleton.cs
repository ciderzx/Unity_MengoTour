using Photon.Pun;//포톤 기능 사용

namespace Util
{
    public class PhotonSingleton<T> : MonoBehaviourPunCallbacks where T : MonoBehaviourPunCallbacks
    {
        private static T instance;

        public static T Instance
        {
            get { return instance; }
        }


        protected virtual void Awake()
        {
            if (instance == null || photonView.IsMine)
            {
                instance = this as T;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}

