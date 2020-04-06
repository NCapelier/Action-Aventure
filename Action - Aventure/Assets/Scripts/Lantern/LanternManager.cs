using UnityEngine;
using Management;

namespace Lantern
{
    /// <summary>
    /// boomerang all states
    /// </summary>
    public enum boomerangState { Tidy, PreCast, Cast, Static, FallBack };

    /// <summary>
    /// light display states
    /// </summary>
    public enum lightState { Displayed, Hidden};

    /// <summary>
    /// light flash states
    /// </summary>
    public enum flashState { Idle, FlashingUp, FlashingDown};

    /// <summary>
    /// light's power after flash
    /// </summary>
    public enum lightStrength { Strengthful, Weakening, Weak, Recovering};

    /// <summary>
    /// NCO - General management of the will o' the wisp object
    /// </summary>
    public class LanternManager : Singleton<LanternManager>
    {
        #region Variables

        // all scripts of the prefab
        public LanternLightBehaviour behaviour = null;
        public LanternInteractions interaction = null;
        public LanternBoomerang boomerang = null;
        public LanternHideLight hideLight = null;
        public LanternFlashLight flashLight = null;
        public GameObject spriteMaskObject = null;

        #endregion

        void Awake()
        {
            MakeSingleton(true);
        }
    }
}