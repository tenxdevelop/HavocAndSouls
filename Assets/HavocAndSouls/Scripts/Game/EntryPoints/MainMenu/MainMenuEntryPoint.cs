//////////////////////////////////////////////////////////////////
//                         HAVOC AND SOULS                      //
//////////////////////////////////////////////////////////////////

using SkyForge.Extension;
using System.Collections;
using SkyForge.Reactive;
using UnityEngine;
using SkyForge;

namespace HavocAndSouls
{
    public class MainMenuEntryPoint : MonoBehaviour, IEntryPoint
    {
        private DIContainer m_container;
        private SingleReactiveProperty<MainMenuExitParams> m_mainMenuExitParams;
        public IEnumerator Initialization(DIContainer parentContainer, SceneEnterParams sceneEnterParams)
        {
            var mainMenuEnterParams = sceneEnterParams as MainMenuEnterParams;
            m_container = parentContainer;
            
            MainMenuService.RegisterServices(m_container, mainMenuEnterParams);
            MainMenuViewModelRegistrar.RegisterViewModels(m_container, mainMenuEnterParams);
            MainMenuViewRegistrar.RegisterViews(m_container);
            
            yield return new WaitForSeconds(2.0f);
        }

        public IObservable<SceneExitParams> Run()
        {
            return m_mainMenuExitParams;
        }
    }
}