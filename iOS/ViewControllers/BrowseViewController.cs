using System;
using System.Collections.Specialized;
using System.Globalization;
using FoodAppClient.ViewModels;
using Foundation;
using GalaSoft.MvvmLight.Helpers;
using UIKit;

namespace FoodAppClient.iOS
{
    public partial class BrowseViewController : UITableViewController
    {

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

            InvokeOnMainThread(() => TableView.ReloadData());
        }

        void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            InvokeOnMainThread(() => TableView.ReloadData()); 
        }
    }

    class ItemsDataSource : UITableViewSource
    {
        static readonly NSString CELL_IDENTIFIER = new NSString("ITEM_CELL");

        private const int heightHeader = 50;

        private const int heightRow = 200;

        public ItemsViewModel viewModel;

        public ItemsDataSource(ItemsViewModel viewModel)
        {
            this.viewModel = viewModel;    
        }

        public override nfloat GetHeightForHeader(UITableView tableView, nint section)
        {
            return heightHeader;
        }

        public override UIView GetViewForHeader(UITableView tableView, nint section)
        {

            var header = new UITableViewHeaderFooterView();
            //          headerView.BackgroundColor = UIColor.FromRGB(173, 203, 209);
            header.TextLabel.TextColor = UIColor.FromRGB(64, 153, 171);
            header.TextLabel.Text = String.Format("Total Kkalories {0}",viewModel.SumKkal.ToString("F", CultureInfo.InvariantCulture));
            return header;
        }

        public override nint RowsInSection(UITableView tableview, nint section) => viewModel.Items.Count;

        public override nint NumberOfSections(UITableView tableView) => 1;

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = tableView.DequeueReusableCell(CELL_IDENTIFIER, indexPath) as CellImage;
            var item = viewModel.Items[indexPath.Row];
            cell.FillCell(item);
  
            return cell;
        }

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return heightRow;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            viewModel.DetailNavigateCommand.Execute(new FoodDetailViewModel(viewModel.Items[indexPath.Row]));
        }
    }
}
