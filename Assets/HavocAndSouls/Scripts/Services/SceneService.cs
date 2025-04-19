//////////////////////////////////////////////////////////////////
//                         HAVOC AND SOULS                      //
//////////////////////////////////////////////////////////////////

using System.Collections;
using SkyForge.Extension;

namespace HavocAndSouls
{
    public class SceneService : BaseSceneService
    {
        public const string BOOTSTRAP_SCENE = "Bootstrap";
        public const string MAIN_MENU_SCENE = "MainMenu";

        public IEnumerator LoadMainMenu(MainMenuEnterParams mainMenuEnterParams)
        {
            yield return LoadScene(BOOTSTRAP_SCENE);
            yield return LoadScene(MAIN_MENU_SCENE, mainMenuEnterParams);
        }
    }
}