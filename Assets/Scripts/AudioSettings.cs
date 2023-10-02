namespace FlappyDaBurd.Core
{
    /// <summary>
    /// Encapsulates audio settings parameters
    /// </summary>
    public class AudioSettings
    {
        public bool EnableMusic;
        public bool EnableSfx;
        public float MasterVolume;

        // Default values for new references.
        public AudioSettings()
        {
            EnableMusic = true;
            EnableSfx = true;
            MasterVolume = .5f;
        }
    }
}
