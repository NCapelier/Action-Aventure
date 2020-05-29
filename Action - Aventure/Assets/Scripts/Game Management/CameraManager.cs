using Management;
using Cinemachine;

namespace GameManagement
{
    public class CameraManager : Singleton<CameraManager>
    {
        public CinemachineVirtualCamera vCam = null;
        void Awake()
        {
            MakeSingleton(true);
        }
        
    }
}