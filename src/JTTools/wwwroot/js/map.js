function mapInit() {
    console.debug("mapinit");
    //延迟加载下
    setTimeout(() => {
        window.map = new AMap.Map('mapContainer', {
            zoom: 12,
            center: [114.085947, 22.547]
        });
    }, 1500)
}

function createMarker(gcj02_lng,gcj02_lat) {
    console.debug("Marker", gcj02_lng, gcj02_lat);
    var marker = new AMap.Marker({
        position: new AMap.LngLat(gcj02_lng, gcj02_lat), // 经纬度对象，也可以是经纬度构成的一维数组[116.39, 39.9]
        icon: new AMap.Icon({
            imageSize: new AMap.Size(36, 36),
        })
    });
    window.map.add(marker);
    window.map.setFitView(marker);
}
