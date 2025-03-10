using Assets.Scripts.Command;
using Assets.Scripts.Game;
using Assets.Scripts.Loading;
using Assets.Scripts.Selection;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ICommandFactory, CommandFactory>(Lifetime.Singleton);
            builder.Register<ICommandDispatcher, CommandDispatcher>(Lifetime.Singleton);
            builder.Register<IGameManager, GameManager>(Lifetime.Singleton);
            builder.Register<ISelectionViewModel, SelectionViewModel>(Lifetime.Singleton);
            builder.Register<ILoadingViewModel, LoadingViewModel>(Lifetime.Singleton);
            builder.Register<IGameModel, GameModel>(Lifetime.Singleton);
        }
    }
}