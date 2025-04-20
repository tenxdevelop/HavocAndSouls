//////////////////////////////////////////////////////////////////
//                         HAVOC AND SOULS                      //
//////////////////////////////////////////////////////////////////

using SkyForge.Reactive;

namespace HavocAndSouls
{
    public class UIRootViewModel : IUIRootViewModel
    {
        public ReactiveProperty<bool> IsShowLoadingScreen { get; private set; } = new();

        public UIRootViewModel()
        {
            IsShowLoadingScreen.Value = false;
        }
        
        public void Dispose()
        {
            
        }

        public void Update(float deltaTime)
        {
            
        }

        public void PhysicsUpdate(float deltaTime)
        {
            
        }

        public void ShowLoadingScreen()
        {
            IsShowLoadingScreen.Value = true;
        }

        public void HideLoadingScreen()
        {
            IsShowLoadingScreen.Value = false;
        }
    }
}