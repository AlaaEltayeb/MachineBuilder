using System;

namespace Assets.Scripts.Loading
{
    public interface ILoadingViewModel
    {
        Action OnLoadingCompleted { get; set; }

        void StopLoading();
    }
}