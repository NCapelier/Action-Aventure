using UnityEngine;
using Management;

namespace Lantern
{
    /// <summary>
    /// boomerang all possible states
    /// </summary>
    public enum boomerangState { Tidy, Cast, Static, FallBack };

    public enum lightState { Displayed, Hidden};

    public enum flashState { Idle, FlashingUp, FlashingDown};

    /// <summary>
    /// NCO - General management of the will o' the wisp object
    /// </summary>
    public class LanternManager : Singleton<LanternManager>
    {
        #region Variables

        public LanternLightBehaviour behaviour = null;
        public LanternInteractions interaction = null;
        public LanternBoomerang boomerang = null;
        public LanternHideLight hideLight = null;
        public LanternFlashLight flashLight = null;
        public GameObject spriteMaskObject = null;

        #endregion

        void Awake()
        {
            MakeSingleton(false);
        }
    }
}