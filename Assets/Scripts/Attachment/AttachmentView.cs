using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Assets.Scripts.Attachment
{
    public sealed class AttachmentView : MonoBehaviour
    {
        [SerializeField]
        private Toggle _attachmentToggle;

        [SerializeField]
        private AttachmentType _attachmentType;

        private IObjectResolver _objectResolver;
        private IAttachmentViewModel _attachmentViewModel;

        [Inject]
        private void Construct(IObjectResolver objectResolver)
        {
            _objectResolver = objectResolver;
        }

        private void Start()
        {
            _attachmentViewModel = new AttachmentViewModel(_attachmentType);
            _objectResolver.Inject(_attachmentViewModel);

            _attachmentToggle.onValueChanged.AddListener(OnSelectionChanged);
        }

        private void OnSelectionChanged(bool isSelected)
        {
            if (isSelected)
                _attachmentViewModel.OnAttachmentSelected();
        }

        private void Destroy()
        {
            _attachmentToggle.onValueChanged.RemoveAllListeners();
        }
    }
}