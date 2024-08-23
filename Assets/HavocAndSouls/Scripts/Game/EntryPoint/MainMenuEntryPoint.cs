/**************************************************************************\
   Copyright SkyForge Corporation. All Rights Reserved.
\**************************************************************************/

using HavocAndSouls.Infrastructure;
using HavocAndSouls.Services;
using System.Collections;
using UnityEngine;

namespace HavocAndSouls
{
    public class MainMenuEntryPoint : MonoBehaviour, IEntryPoint
    {
        private DIContainer m_container;

        public IEnumerator Intialization(DIContainer parentContainer)
        {
            m_container = parentContainer;

            RegisterService(m_container);
            RegisterViewModel(m_container);
            BindView(m_container);
            yield return null;
        }

        private void RegisterService(DIContainer container)
        {

        }

        private void RegisterViewModel(DIContainer container)
        {
            container.RegisterSingleton<IUIMainMenuViewModel>(factory => new UIMainMenuViewModel(factory.Resolve<SceneService>(), factory.Resolve<Coroutines>()));
        }

        private void BindView(DIContainer container)
        {
            var loadService = container.Resolve<LoadService>();

            //Load and Bind UIMainMenuView
            var uIRootViewModel = container.Resolve<IUIRootViewModel>();
            var uIMainMenuPrefab = loadService.LoadPrefab<UIMainMenuView>(LoadService.PREFAB_UI_MAIN_MENU);
            var uIMainMenuView = Object.Instantiate(uIMainMenuPrefab);
            var uIMainMenuViewModel =  container.Resolve<IUIMainMenuViewModel>();

            uIMainMenuView.Bind(uIMainMenuViewModel);
            uIRootViewModel.AttachSceneUI(uIMainMenuView);
        }
    }
}
