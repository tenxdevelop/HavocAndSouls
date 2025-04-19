//////////////////////////////////////////////////////////////////
//                         HAVOC AND SOULS                      //
//////////////////////////////////////////////////////////////////

using UnityEngine.SceneManagement;
using System.Collections;
using SkyForge.Extension;
using UnityEngine;
using SkyForge;

namespace HavocAndSouls
{
    public class GameEntryPoint
    {
        private static GameEntryPoint m_instance;

        private IUIRootViewModel m_uIRootViewModel;
        private DIContainer m_rootContainer;
        private Coroutines m_coroutines;
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Run()
        {
            Application.targetFrameRate = 60;

            if (m_instance is not null)
            {
                Debug.LogError("GameEntryPoint is already running.");
                return;
            }

            m_instance = new GameEntryPoint();
            m_instance.Init();
        }
        
        private GameEntryPoint()
        {
            m_rootContainer = new DIContainer();
            GameService.RegisterServices(m_rootContainer);
        }

        private void Init()
        {
            //Init coroutines
            m_coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            m_rootContainer.RegisterInstance(m_coroutines);
            Object.DontDestroyOnLoad(m_coroutines.gameObject);
            
            var sceneService = m_rootContainer.Resolve<SceneService>();
            sceneService.LoadSceneEvent += OnLoadScene;
            
            RegisterViewModel(m_rootContainer);
            BindView(m_rootContainer);

            var defaultMainMenuEnterParams = new MainMenuEnterParams();
            m_coroutines.StartCoroutine(sceneService.LoadMainMenu(defaultMainMenuEnterParams));
        }

        private void RegisterViewModel(DIContainer container)
        {
            
        }

        private void BindView(DIContainer container)
        {
            
        }
        
        private void OnLoadScene(Scene scene, LoadSceneMode loadSceneMode, SceneEnterParams sceneEnterParams)
        {
            var sceneName = scene.name;
            if (sceneName.Equals(SceneService.BOOTSTRAP_SCENE))
                LoadBootstrapScene();
            else if(sceneName.Equals(SceneService.MAIN_MENU_SCENE))
                m_coroutines.StartCoroutine(LoadMainMenuScene(sceneEnterParams));
        }
        
        private void LoadBootstrapScene()
        {
            m_uIRootViewModel?.ShowLoadingScreen();
        }
        
        private IEnumerator LoadMainMenuScene(SceneEnterParams sceneEnterParams)
        {
            var mainMenuContainer = new DIContainer(m_rootContainer);

            var mainMenuEntryPoint = UnityExtension.GetEntryPoint<MainMenuEntryPoint>();
            
            yield return mainMenuEntryPoint.Initialization(mainMenuContainer, sceneEnterParams);

            mainMenuEntryPoint.Run();
            
            m_uIRootViewModel?.HideLoadingScreen();
        }
    }

}
