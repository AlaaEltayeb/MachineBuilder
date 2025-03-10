using UnityEngine;
using VContainer;

namespace Assets.Scripts.Loading
{
    public class LoadingView : MonoBehaviour
    {
        [SerializeField]
        private Transform _loading;

        private bool _isLoading = true;

        [Inject]
        private void Construct(ILoadingViewModel loadingViewModel)
        {
            loadingViewModel.OnLoadingCompleted += StopLoading;
        }

        private void StopLoading()
        {
            _isLoading = false;
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (!_isLoading)
                return;

            _loading.Rotate(-Vector3.forward, 0.5f);
        }
    }
}