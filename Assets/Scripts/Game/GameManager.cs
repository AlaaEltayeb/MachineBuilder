using UnityEngine;

namespace Assets.Scripts.Game
{
    public sealed class GameManager : IGameManager
    {
        private readonly IGameModel _gameModel;

        public GameManager(IGameModel gameModel)
        {
            _gameModel = gameModel;
        }

        public void CreateSelectedAttachment()
        {
            GameObject.Instantiate(_gameModel.Attachments[_gameModel.SelectedAttachmentType]);
            Debug.Log("Created");
        }
    }
}