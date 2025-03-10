using Assets.Scripts.Command;
using Assets.Scripts.Game;
using VContainer;

namespace Assets.Scripts.Selection
{
    public sealed class CreateSelectedAttachment : ICommand
    {
        private IGameManager _gameManager;

        [Inject]
        private void Construct(IGameManager commandManager)
        {
            _gameManager = commandManager;
        }

        public void Execute()
        {
            _gameManager.CreateSelectedAttachment();
        }
    }
}