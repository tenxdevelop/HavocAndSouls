//////////////////////////////////////////////////////////////////
//                         HAVOC AND SOULS                      //
//////////////////////////////////////////////////////////////////

using SkyForge;

namespace HavocAndSouls
{
    public static class GameService
    {
        public static void RegisterServices(DIContainer container)
        {
            container.RegisterSingleton(factory => new SceneService());
            container.RegisterSingleton(factory => new LoadService());
        }
    }
}