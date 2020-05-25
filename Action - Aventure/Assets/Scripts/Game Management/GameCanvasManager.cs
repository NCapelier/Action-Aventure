using Management;
using Dialog;

namespace GameManagement
{
    public class GameCanvasManager : Singleton<GameCanvasManager>
    {

        public DialogDisplay dialog = null;

        void Awake()
        {
            MakeSingleton(false);
        }
    }
}