using Assets.Scripts.Command;
using VContainer;

namespace Assets.Scripts.Loading
{
    public sealed class StopLoadingCommand : ICommand
    {
        private ILoadingViewModel _loadingViewModel;

        [Inject]
        private void Construct(ILoadingViewModel loadingViewModel)
        {
            _loadingViewModel = loadingViewModel;
        }

        public void Execute()
        {
            _loadingViewModel.StopLoading();
        }
    }
}