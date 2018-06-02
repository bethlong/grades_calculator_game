using Assets.Code.Helper;
using Assets.Code.Model.Constants;
using UnityEngine.SceneManagement;

namespace Assets.Code.Scripts.MainMenu
{
    public class MainMenuButtonController
    {
        public void OnPlayButton()
        {
            GradeSaveFileImporter.LoadGradeSaveFile("CSFinalYear2018");
            
            SceneManager.LoadSceneAsync(SceneKeys.MainMenu);
        }
    }
}