let map = null;
let infoWindow = null;
let AdvancedMarkerElement = null;
let markers = [];
let clusterer = null;

const escapeHtml = (str) => {
    const div = document.createElement("div");

    div.appendChild(document.createTextNode(str ?? ""));

    return div.innerHTML;
};

const buildInfoWindowContent = (restaurant) => {
    const restaurantName = escapeHtml(restaurant.name);
    const restaurantAddress = escapeHtml(restaurant.address?.firstLine);
    const restaurantUrl = encodeURI(restaurant.url);
    const restaurantLogoUrl = encodeURI(restaurant.logourl);

    const restaurantLogo = `<img src="${restaurantLogoUrl}" alt="${restaurantName}'s logo" class="rounded object-fit-contain flex-shrink-0 bg-light" width="32" height="32"/>`;

    return `
        <div class="card border-0" style="max-width: 260px;">
            <div class="card-body p-2">
                <div class="d-flex align-items-center gap-2 mb-2">
                    ${restaurantLogo}
                    <div class="overflow-hidden">
                        <h6 class="card-title mb-0 fw-semibold text-dark text-break">
                            ${restaurantName}
                        </h6>
                        <small class="text-body-secondary">${restaurantAddress}</small>
                    </div>
                </div>
                <a href="${restaurantUrl}" target="_blank" rel="noopener noreferrer" class="btn btn-primary btn-sm w-100">View Restaurant</a>
            </div>
        </div>
    `;
}

export const initMapAsync = async (latitude, longitude, zoom) => {
    const {Map, InfoWindow} = await google.maps.importLibrary("maps");
    ({AdvancedMarkerElement} = await google.maps.importLibrary("marker"));

    map = new Map(document.getElementById("map"), {
        center: {lat: latitude, lng: longitude},
        zoom: zoom,
        mapId: "{MAP_ID}"
    });

    infoWindow = new InfoWindow({
        ariaLabel: "Restaurant Information"
    });
}

export const addMarkerAsync = async (restaurants) => {
    if (clusterer) {
        clusterer.clearMarkers();
    }

    markers = [];
    infoWindow.close();

    for (const restaurant of restaurants) {
        const marker = new AdvancedMarkerElement({
            position: {
                lat: restaurant.address.latitude,
                lng: restaurant.address.longitude
            },
            title: restaurant.name,
        });

        marker.addListener("gmp-click", () => {
            infoWindow.setContent(buildInfoWindowContent(restaurant));
            infoWindow.open({
                anchor: marker,
                map
            });
        });

        markers.push(marker);
    }

    if (!clusterer) {
        clusterer = new markerClusterer.MarkerClusterer({
            map,
            markers,
            algorithmOptions: {
                radius: 90,
                maxZoom: 18
            }
        });
    } else {
        clusterer.addMarkers(markers);
    }
}
