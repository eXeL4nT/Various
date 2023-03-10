using ReactiveUI;
using System.Reactive.Disposables;

namespace Various.Sample.Views;

/// <summary>
/// Interaction logic for MainView.xaml
/// </summary>
public partial class MainView
{
    public MainView()
    {
        InitializeComponent();

        this.WhenActivated(disposable =>
        {
            this.BindCommand(ViewModel,
                viewModel => viewModel.CommandOpenDialog,
                view => view.ButtonOpenDialog)
            .DisposeWith(disposable);

            this.OneWayBind(ViewModel,
                viewModel => viewModel.ModalContent,
                view => view.ReactiveModal.Content)
            .DisposeWith(disposable);

            this.Bind(ViewModel,
                viewModel => viewModel.IsModalOpen,
                view => view.ReactiveModal.IsOpen)
            .DisposeWith(disposable);
        });
    }
}
