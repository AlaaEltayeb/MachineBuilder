using Assets.Scripts.Game;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Attachment
{
    public sealed class AttachmentViewModel : IAttachmentViewModel
    {
        private IGameModel _gameModel;

        private readonly AttachmentType _attachmentType;

        [Inject]
        private void Construct(IGameModel gameModel)
        {
            _gameModel = gameModel;
        }

        public AttachmentViewModel(AttachmentType attachmentType)
        {
            _attachmentType = attachmentType;
        }

        public void OnAttachmentSelected()
        {
            _gameModel.SetCurrentAttachmentType(_attachmentType);
            Debug.Log($"Selected: {_attachmentType}");
        }
    }
}