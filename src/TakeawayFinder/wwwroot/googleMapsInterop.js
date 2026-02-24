let map;
let infoWindow;

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

    const { Map, Circle } = await google.maps.importLibrary("maps");

    map = new Map(document.getElementById("map"), {
        center: { lat: latitude, lng: longitude },
        zoom: zoom,
        mapId: "{MAP_ID}"
    });
    
    // const cityCircle = new Circle({
    //     strokeColor: "#FF0000",
    //     strokeOpacity: 0.8,
    //     strokeWeight: 2,
    //     fillColor: "#FF0000",
    //     fillOpacity: 0.35,
    //     map: map,
    //     center: {lat: 51.53721, lng: 0.04687},
    //     radius: 15000
    // })
}

// export async function addMarkerAsync(latitude, longitude, title, description) {
//     const { AdvancedMarkerElement } = await google.maps.importLibrary("marker");
//     const { InfoWindow } = await google.maps.importLibrary("maps");
//
//     const marker = new AdvancedMarkerElement({
//         map: map,
//         position: { lat: latitude, lng: longitude },
//         title: title,
//         gmpClickable: true,
//     });
//    
//     const contentString = `<h1>${marker.title}</h1>` + `<h2>Restaurant: <a href="${description}"</a>${marker.title}</h2>`;
//
//     marker.addListener('click', ({ domEvent, latLng }) => {
//         const { target } = domEvent;
//         if (infoWindow) {
//             infoWindow.close();
//         }
//         infoWindow = new InfoWindow({
//             content: contentString
//         })
//
//         infoWindow.open(map, marker);
//     });
// }

export async function addMarkerAsync(restaurant) {
    const { AdvancedMarkerElement } = await google.maps.importLibrary("marker");
    const { InfoWindow } = await google.maps.importLibrary("maps");

    restaurant.forEach(r => {
        const marker = new AdvancedMarkerElement({
            map,
            position: { lat: r.address.latitude, lng: r.address.longitude },
            title: r.name,
            gmpClickable: true,
        });
        
        const contentString = `<h1>${r.name}</h1>` + `<h2>Restaurant: <a href="${r.url}"</a>${r.name}</h2>`;

        marker.addListener('click', ({ domEvent, latLng }) => {
            const { target } = domEvent;
            if (infoWindow) {
                infoWindow.close();
            }
            infoWindow = new InfoWindow({
                content: contentString
            })

            infoWindow.open(map, marker);
        });
    })
}
