using Assets.Code.Helper;
using Assets.Code.Model.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Code.Scripts
{
    public class ApplicationStartController : MonoBehaviour
    {
        public void Awake()
        {
            DontDestroyOnLoad(gameObject);
            
            InitialDataImporter initialDataImporter = new InitialDataImporter();
            initialDataImporter.LoadInitialData();
        }

        public void Start()
        {
            SceneManager.LoadSceneAsync(SceneKeys.MainMenu);
        }
    }
}