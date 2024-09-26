using Prism.Commands;
using Prism.Navigation;
using System.Windows.Input;
using System.Windows.Navigation;

namespace DCTCrypto.Pages.Base
{
    public abstract class BasePageViewModel
    {
        private readonly NavigationService _navigationService;
        private ICommand _goBackCommand;

        protected BasePageViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public ICommand GoBackCommand => _goBackCommand ?? new DelegateCommand(ExecuteGoBackCommand);

        private void ExecuteGoBackCommand()
        {
            if (_navigationService.CanGoBack)
                _navigationService.GoBack();
        }
    }
}
