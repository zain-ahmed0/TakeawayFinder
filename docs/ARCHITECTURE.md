## Project Structure

### Pages
- `FindTakeaway.razor` - Will contain the UI Logic
- `FindTakeaway.razor.cs` - Will contain the page logic
- `FindTakeaway.razor.css` - Will contain any CSS styling

### Interop
- `GoogleMapsInterop.cs` - Will bridge JS

### Services
- `RestaurantService.cs` - Will contain the API call to the Just Eat API
- `GoogleMapsService.cs` - Will contain Google Maps logic e.g Add Marker

### Interfaces - Sits inside Services
- `IRestaurantService.cs`
- `IGoogleMapsService.cs`

### DTOs - TBC
- `TBC`

### Models - In a different project
- `Restaurant.cs`
- `MenuItem.cs`
- `GeoLocation.cs`

### wwwroot
- `googleMapsInterop.js` - Will call the Google Maps API