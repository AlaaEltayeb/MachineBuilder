using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Assets.Scripts.Selection
{
    public sealed class SelectionView : MonoBehaviour
    {
        [SerializeField]
        private Button _selectButton;

        private ISelectionViewModel _selectionViewModel;

        [Inject]
        private void Construct(ISelectionViewModel selectionViewModel)
        {
            _selectionViewModel = selectionViewModel;
        }

        private void Start()
        {
            _selectButton.onClick.AddListener(OnSelection);
        }

        private void OnSelection()
        {
            _selectionViewModel.OnSelectionConfirmed();
        }

        private void Destroy()
        {
            _selectButton.onClick.RemoveAllListeners();
        }
    }
}