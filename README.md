# Grocery App (.NET MAUI, .NET 8)

Cross‑platform grocery app built with .NET MAUI and CommunityToolkit.Mvvm. Browse categories, view products per category, and see product details like stock, THT date (Ten minste houdbaar tot), and price.

## Features
- Category overview
  - Preloaded categories: “zuivel”, “brood beleg”, “vlees”, “ontbijt”, “avond eten”.
  - Selecting a category loads its products via `ProductCategoriesViewModel`.
- Product list per category
  - Observable, instant UI updates using `ObservableCollection<Product>`.
- Product details
  - Stock: bound via `[ObservableProperty]` generated `Stock` property.
  - THT (shelf life): `Product.ShelfLife` (`DateOnly`).
  - Price: `Product.Price` (`decimal`).
  - Defaults: price 0.00 and unspecified THT when not provided.
- Grocery lists
  - In-memory sample lists with due dates and color tags.

## Tech Stack
- .NET 8, C# 12
- .NET MAUI (Android, iOS, Windows, macOS)
- CommunityToolkit.Mvvm (source generators for MVVM)

## Project Structure
- `Grocery.App` (UI)
  - Views (e.g., `ProductView.xaml`)
  - ViewModels (e.g., `ProductCategoriesViewModel`)
- `Grocery.Core` (Domain + Data)
  - Models (e.g., `Product`, `Category`, `GroceryList`)
  - Repositories (e.g., `CategoryRepository`, `GroceryListRepository`)

## Getting Started

Prerequisites
- Visual Studio 2022 with .NET MAUI workload
- .NET 8 SDK
- For Android/iOS: required platform SDKs/emulators

Install MAUI workload (if needed)

dotnet workload install maui

Clone and run
1. Clone the repo and open the solution in Visual Studio 2022.
2. Restore packages: __Restore NuGet Packages__.
3. Set startup project to `Grocery.App`: __Set as Startup Project__.
4. Select a target (Android Emulator, Windows, etc.).
5. Build and run: __Build__ → __Start Debugging__.

Command line (optional)
dotnet build

## Example to run Android:
dotnet build -t:Run -f net8.0-android

## UI Binding Tips (THT and Prices)

- Format THT (DateOnly) in XAML:
<Label Text="{Binding ShelfLife, StringFormat='{}{0:dd-MM-yyyy}'}" />

- Format price using current culture:
<Label Text="{Binding Price, StringFormat='{}{0:C}'}" />

- For Dutch formatting across the app, set the culture at startup (optional):
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("nl-NL"); CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("nl-NL");


## Navigation Flow
1. Open category overview.
2. Select a category to see its products.
3. Tap a product to view details: stock, THT, price.

## Known Limitations
- Repositories are in-memory; no persistence layer included.
- Price defaults to 0.00 if not set.
- Ensure date/price formatting matches the desired locale.

## Contributing
- Use feature branches and pull requests.
- Keep MVVM patterns consistent (CommunityToolkit.Mvvm).
- Add/update unit tests where applicable.