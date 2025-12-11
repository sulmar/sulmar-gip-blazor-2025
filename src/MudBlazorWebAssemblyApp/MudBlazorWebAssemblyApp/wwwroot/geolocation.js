window.getLocation = (dotnet) => {

    navigator.geolocation.getCurrentPosition(position => {

        console.log(position.coords.latitude);
        console.log(position.coords.longitude);
        
        dotnet.invokeMethodAsync("OnLocationChanged", position.coords.latitude, position.coords.longitude);
    });
};