using System;
using System.Collections.Specialized;
using FoodAppClient.ViewModels;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using UIKit;

namespace FoodAppClient.iOS
{
    public partial class BrowseViewController : UITableViewController
    {
        UIRefreshControl refreshControl;

        private ItemsViewModel ViewModel => App.Locator.Main;

        public BrowseViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = ViewModel.Title;

            btnAddItem.SetCommand(ViewModel.NewNavigateCommand);

            TableView.Source = new ItemsDataSource(ViewModel);
            ViewModel.LoadItemsCommand.Execute(null);
            ViewModel.Items.CollectionChanged += Items_CollectionChanged;
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (ViewModel.Items.Count == 0)
                ViewModel.LoadItemsCommand.Execute(null);
        }

        void RefreshControl_ValueChanged(object sender, EventArgs e)
        {
            if (!ViewModel.IsBusy && refreshControl.Refreshing)
                ViewModel.LoadItemsCommand.Execute(null);
        }

        void IsBusy_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var propertyName = e.PropertyName;
            switch (propertyName)
            {
                case nameof(ViewModel.IsBusy):
                    {
                        InvokeOnMainThread(() =>
                        {
                            if (ViewModel.IsBusy && !refreshControl.Refreshing)
                                refreshControl.BeginRefreshing();
                            else if (!ViewModel.IsBusy)
                                refreshControl.EndRefreshing();
                        });
                    }
                    break;
            }
        }

        void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            InvokeOnMainThread(() => TableView.ReloadData());
        }
    }

    class ItemsDataSource : UITableViewSource
    {
        static readonly NSString CELL_IDENTIFIER = new NSString("ITEM_CELL");

        public ItemsViewModel viewModel;

        public ItemsDataSource(ItemsViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override nint RowsInSection(UITableView tableview, nint section) => viewModel.Items.Count;

        public override nint NumberOfSections(UITableView tableView) => 1;

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CELL_IDENTIFIER, indexPath);

            var item = viewModel.Items[indexPath.Row];

            cell.TextLabel.Text = item.Name;
            cell.DetailTextLabel.Text = item.Kkal.ToString();
            cell.LayoutMargins = UIEdgeInsets.Zero;

            return cell;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            viewModel.DetailNavigateCommand.Execute(new FoodDetailViewModel(viewModel.Items[indexPath.Row]));
        }
    }
}
