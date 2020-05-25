using Management;

namespace GameManagement
{
    public class CameraManager : Singleton<CameraManager>
    {


        void Awake()
        {
            MakeSingleton(true);
        }
        
    }
}