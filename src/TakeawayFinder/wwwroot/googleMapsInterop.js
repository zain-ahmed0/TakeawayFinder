let map;

async function waitForGoogleMaps() {
    return new Promise((resolve) => {
        if (typeof google !== 'undefined' && google.maps) {
            resolve();
            return;
        }

        const checkInterval = setInterval(() => {
            if (typeof google !== 'undefined' && google.maps) {
                clearInterval(checkInterval);
                resolve();
            }
        }, 100);
    });
}

export async function initMapAsync(latitude, longitude, zoom) {
    await waitForGoogleMaps();

    const { Map } = await google.maps.importLibrary("maps");

    map = new Map(document.getElementById("map"), {
        center: { lat: latitude, lng: longitude },
        zoom: zoom,
        mapId: "MAP_ID"
    });
}

export async function addMarkerAsync(latitude, longitude) {
    const { AdvancedMarkerElement } = await google.maps.importLibrary("marker");

    new AdvancedMarkerElement({
        map: map,
        position: { lat: latitude, lng: longitude }
    });
}
