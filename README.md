# Takeaway Finder

## Project Structure

### Pages
- `FindTakeaway.razor` - Will contain the UI Logic
- `FindTakeaway.razor.cs` - Will contain the page logic
- `FindTakeaway.razor.css` - Will contain any CSS styling

### Interop
- `GoogleMapsInterop.cs` - Will bridge JS

### Services
- `RestaurantService` - Will contain the API call to the Just Eat API
- `GoogleMapsService` - Will contain Google Maps logic e.g Add Marker

### Interfaces
- `IRestaurantService`
- `IGoogleMapsService`

### DTOs
- `TBC`

### Models
- `Restaurant.cs`
- `MenuItem.cs`
- `GeoLocation.cs`

### wwwroot
- `googleMapsInterop.js` - Will call the Google Maps API