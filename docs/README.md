# Takeaway Finder

A web application that helps users find nearby takeaway restaurants using Google Maps integration and the Just Eat Takeaway API.

## Prerequisites

- .NET 10 SDK
- Google Cloud Platform account
- Git

## Getting Started

1. **Clone the Repository**
   ```bash
   git clone https://github.com/zain-ahmed0/TakeawayFinder.git
   cd TakeawayFinder
   ```

2. **Create a Google Cloud Project**
    - Go to the [Google Cloud Console](https://console.cloud.google.com/)
    - Create a new project.
    - Add a payment method to be billed.
    - Navigate to Google Maps Platform. An API key will be created automatically.
    - Select the **API restriction** option and tick **Maps JavaScript API**.

3. **Enable Maps JavaScript API**
    - Go to **APIs & Services**
    - Search for **Maps JavaScript API**
    - Click **Enable**

4. **Create a Map ID**
    - Go to **Map Management**
    - Click **Create Map ID**
    - Enter details and choose **JavaScript** as the Map type and **Vector**

5. **Add Credentials to the Project**
    - In `TakeawayFinder/Pages/FindTakeaway.razor`, replace `{GOOGLE_MAPS_API_KEY}` with your Google Maps API Key.
    - In `TakeawayFinder/wwwroot/js/googleMapsInterop.js`, replace `{MAP_ID}` with your Map ID.

## Running the Project Locally

The solution contains two projects:
- `TakeawayFinder` (Frontend)
- `TakeawayFinder.Api` (Backend)

### Run the Frontend locally

```bash
cd TakeawayFinder
dotnet run
```

### Run the Backend locally

```bash
cd TakeawayFinder.Api
dotnet run
```

Once running, open your browser at:

```
http://localhost:5273
```

To use the website, go to the **Find Takeaway** page and enter a UK postcode to view nearby restaurants. 

Alternatively, you can just run the Frontend as the Backend is hosted on Render.