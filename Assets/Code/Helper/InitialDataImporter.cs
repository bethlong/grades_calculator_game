using Assets.Code.Model;

namespace Assets.Code.Helper
{
    public class InitialDataImporter
    {
        private static readonly string GameDataProjectFilePath = "/SystemData/";
        private static readonly string Extension = ".json";
        
        private static readonly string ColourSchemeFileName = "ColourScheme";
        private static readonly string SettingsFileName = "Settings";
        
        public void LoadInitialData()
        {
            JsonStorage<ColourScheme> jsonStorage = new JsonStorage<ColourScheme>();
            DataStore.Instance.ColourScheme = jsonStorage.LoadInternalFile(GameDataProjectFilePath, ColourSchemeFileName, Extension);
            
            JsonStorage<Settings> jsonSettings = new JsonStorage<Settings>();
            DataStore.Instance.Settings =
                jsonSettings.LoadInternalFile(GameDataProjectFilePath, SettingsFileName, Extension);
        }
    }
}