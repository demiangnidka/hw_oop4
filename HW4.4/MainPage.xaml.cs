using System.Collections.ObjectModel;

namespace HW4._4
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Product> Products { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Products = new ObservableCollection<Product>
            {
                new Food(45.50m, "Ukraine", "Milk", DateTime.Now.AddDays(-2), "Pasteurized 2.5%", DateTime.Now.AddDays(5), 1, "bottle"),
                new Book(550.00m, "USA", "48 Laws of Power", new DateTime(2023, 1, 15), "Psychology of influence and strategic thinking", 608, "Viking Press", "Robert Greene")
            };

            ProductsListView.ItemsSource = Products;
        }

        private void OnAddProductClicked(object sender, EventArgs e)
        {
            Products.Add(new Food(120.00m, "Italy", "Cheese", DateTime.Now, "Hard Parmesan", DateTime.Now.AddDays(30), 1, "kg"));
        }

        private void OnRemoveProductClicked(object sender, EventArgs e)
        {
            if (ProductsListView.SelectedItem is Product selectedProduct)
            {
                Products.Remove(selectedProduct);
            }
            else if (Products.Count > 0)
            {
                Products.RemoveAt(Products.Count - 1);
            }
        }
    }
}