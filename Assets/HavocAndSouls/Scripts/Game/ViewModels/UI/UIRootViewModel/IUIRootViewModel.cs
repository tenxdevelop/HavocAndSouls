//////////////////////////////////////////////////////////////////
//                         HAVOC AND SOULS                      //
//////////////////////////////////////////////////////////////////

using SkyForge.MVVM;

namespace HavocAndSouls
{
    public interface IUIRootViewModel : IViewModel
    {
        void ShowLoadingScreen();
        void HideLoadingScreen();
    }
}