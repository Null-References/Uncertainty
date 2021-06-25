namespace IL3DN
{
    using UnityEngine;
    /// <summary>
    /// Override player sound when walking in different environments
    /// Attach this to a trigger
    /// </summary>
    public class IL3DN_ChangeWalkingSound : MonoBehaviour
    {
        public AudioClip[] footStepsOverride;
        public AudioClip jumpSound;
        public AudioClip landSound;
    }
}
