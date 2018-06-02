namespace Assets.Code.Model
{
    public class DataStore
    {
        public static DataStore DataStoreInstance = new DataStore();

        public static DataStore Instance
        {
            get { return DataStoreInstance; }
        }
        
        public GradeTree GradeTree { get; set; }
        public ColourScheme ColourScheme { get; set; }
        public Settings Settings { get; set; }
    }
}