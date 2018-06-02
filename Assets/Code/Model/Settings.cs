using Newtonsoft.Json;

namespace Assets.Code.Model
{
    public class Settings
    {
        [JsonProperty("BackgroundMusicVolume")]
        public static float BackgroundMusicVolume { get; set; }
        [JsonProperty("SoundEffectVolume")]
        public static float SoundEffectVolume { get; set; }
    }
}