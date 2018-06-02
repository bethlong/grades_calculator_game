using Assets.Code.Model;

namespace Assets.Code.Helper
{
    public static class GradeSaveFileImporter
    {
        public static readonly string GameDataProjectFilePath = "/ClientData/";
        public static readonly string Extension = ".grades";
        
        public static bool LoadGradeSaveFile(string fileName)
        {
            JsonStorage<GradeTree> gradeJsonStorage = new JsonStorage<GradeTree>();
            DataStore.Instance.GradeTree = gradeJsonStorage.LoadInternalFile(GameDataProjectFilePath, fileName, Extension);

            if (DataStore.Instance.GradeTree == null) return false;
            
            return true;
        }

        public static bool SaveGradeSaveFile(string fileName)
        {
            JsonStorage<GradeTree> gradeJsonStorage = new JsonStorage<GradeTree>();
            gradeJsonStorage.SaveInternalFile(DataStore.Instance.GradeTree, GameDataProjectFilePath, fileName, Extension);

            return true;
        }
    }
}