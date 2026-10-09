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
                new Food(45.50m, "Ukraine", "Milk", new DateTime(2026, 10, 7), "", new DateTime(2026, 10, 14), 1, "bottle"),
                new Book(550.00m, "USA", "48 Laws of Power", new DateTime(2023, 1, 15), "", 608, "Viking Press", "Robert Greene")
            };

            ProductsListView.ItemsSource = Products;
        }

        private async void OnAddProductClicked(object sender, EventArgs e)
        {
            string productType = await DisplayActionSheetAsync("Select Product Type", "Cancel", null, "Food", "Book");
            if (productType == "Cancel" || string.IsNullOrEmpty(productType))
            {
                return;
            }

            string name = await DisplayPromptAsync("New Product", "Enter product name:");
            if (string.IsNullOrWhiteSpace(name))
            {
                return;
            }

            string country = await DisplayPromptAsync("New Product", "Enter country of origin:");
            if (string.IsNullOrWhiteSpace(country))
            {
                country = "Unknown";
            }

            decimal price;
            string priceStr = await DisplayPromptAsync("New Product", "Enter price (UAH):", keyboard: Keyboard.Numeric);
            while (!decimal.TryParse(priceStr, out price) || price <= 0)
            {
                priceStr = await DisplayPromptAsync("Invalid Price!", "Please enter a valid positive price (UAH):", keyboard: Keyboard.Numeric);
                if (priceStr == null)
                {
                    return;
                }
            }

            DateTime manufactureDate;
            string dateStr = await DisplayPromptAsync("New Product", "Enter manufacture date (YYYY-MM-DD):", placeholder: "2026-10-09");

            while (!DateTime.TryParse(dateStr, out manufactureDate))
            {
                dateStr = await DisplayPromptAsync("Invalid Date!", "Please enter a valid manufacture date (YYYY-MM-DD):", placeholder: "2026-10-09");
                if (dateStr == null)
                {
                    return;
                }
            }

            if (productType == "Food")
            {
                DateTime expirationDate;
                string expDateStr = await DisplayPromptAsync("New Product", "Enter expiration date (YYYY-MM-DD):", placeholder: "2026-10-16");

                while (!DateTime.TryParse(expDateStr, out expirationDate))
                {
                    expDateStr = await DisplayPromptAsync("Invalid Date!", "Please enter a valid expiration date (YYYY-MM-DD):", placeholder: "2026-10-16");
                    if (expDateStr == null)
                    {
                        return;
                    }
                }

                Products.Add(new Food(price, country, name, manufactureDate, "", expirationDate, 1, "pcs"));
            }
            else if (productType == "Book")
            {
                string author = await DisplayPromptAsync("New Product", "Enter author:");
                if (string.IsNullOrWhiteSpace(author))
                {
                    author = "Unknown Author";
                }

                string publisher = await DisplayPromptAsync("New Product", "Enter publisher:");
                if (string.IsNullOrWhiteSpace(publisher))
                {
                    publisher = "Unknown Publisher";
                }

                Products.Add(new Book(price, country, name, manufactureDate, "", 350, publisher, author));
            }
        }

        private void OnRemoveProductItemClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Product productToRemove)
            {
                Products.Remove(productToRemove);
            }
        }
    }
}