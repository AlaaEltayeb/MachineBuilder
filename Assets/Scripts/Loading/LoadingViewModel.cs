using System;

namespace Assets.Scripts.Loading
{
    public sealed class LoadingViewModel : ILoadingViewModel
    {
        public Action OnLoadingCompleted { get; set; }

        public void StopLoading()
        {
            OnLoadingCompleted?.Invoke();
        }
    }
}