using Assets.Scripts.Command;

namespace Assets.Scripts.Selection
{
    public sealed class SelectionViewModel : ISelectionViewModel
    {
        private ICommandDispatcher _commandDispatcher;

        public SelectionViewModel(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public void OnSelectionConfirmed()
        {
            _commandDispatcher.Execute(new CreateSelectedAttachment());
        }
    }
}