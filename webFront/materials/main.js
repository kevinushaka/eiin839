
var xhr = new XMLHttpRequest();
var stations = [];

function getDistanceFrom2GpsCoordinates(lat1, lon1, lat2, lon2) {
    // Radius of the earth in km
    var earthRadius = 6371;
    var dLat = deg2rad(lat2 - lat1);
    var dLon = deg2rad(lon2 - lon1);
    var a =
        Math.sin(dLat / 2) * Math.sin(dLat / 2) +
        Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
        Math.sin(dLon / 2) * Math.sin(dLon / 2)
        ;
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    var d = earthRadius * c; // Distance in km
    return d;
}

function deg2rad(deg) {
    return deg * (Math.PI / 180)
}

function contractsRetrieved () {
    var contracts = JSON.parse(xhr.responseText);
    var datalist = document.getElementById('contracts-name');
    for(var i = 0; i < contracts.length; i++) {
        var obj = contracts[i];
        var newValue = document.createElement("option");
        newValue.setAttribute("value", obj.name);

        datalist.appendChild(newValue);
    }

}

function stationsRetrieved() {
    stations = JSON.parse(xhr.responseText);
    console.log(stations);
}

function getClosestStation() {
    var latitude = document.getElementById('latitude');
    var longitude = document.getElementById('longitude');
    var minDistance = getDistanceFrom2GpsCoordinates(stations[0].position.latitude, stations[0].position.longitude, latitude.value, longitude.value); 
    var obj = stations[0];
    stations.forEach(station => {
        var distance = getDistanceFrom2GpsCoordinates(station.position.latitude, station.position.longitude, latitude.value, longitude.value);
        if (distance < minDistance) {
            minDistance = distance;
            obj = station;
        }
    })
    var latitude = document.getElementById('location');
    var text = document.createTextNode("The closest station is " + obj.name + ".");
    latitude.appendChild(text);

}

function retrieveContractStations() {
    let apiKey = document.getElementById('apiKey');
    let contract_name = document.getElementById('contracts-choice');
    xhr.open('GET', 'https://api.jcdecaux.com/vls/v3/stations?contract=' + contract_name.value+'&apiKey=' + apiKey.value, true);
    xhr.setRequestHeader("Accept", "application/json");
    xhr.onload = stationsRetrieved;
    xhr.send(null);
}

function retrieveAllContracts() {
    let apiKey = document.getElementById('apiKey');
    console.log('ApiKey :'+apiKey.value);

    
    xhr.open('GET', 'https://api.jcdecaux.com/vls/v3/contracts?apiKey=' + apiKey.value, true);
    xhr.setRequestHeader("Accept","application/json");
    xhr.onload = contractsRetrieved ;
    xhr.send(null);

}

