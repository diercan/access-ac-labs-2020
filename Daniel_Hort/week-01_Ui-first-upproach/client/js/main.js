var platform = new H.service.Platform({
  'apikey': 'HZ6HSspCNdZzt1YaNzLDdZRGClicUYkX-aVfSdF_9V4'
});
var service = platform.getSearchService();
var defaultLayers = platform.createDefaultLayers();

var positions = [
  {coord: {lat:45.752289, lng:21.224296}, link: 'https://littlehanoi.ro/'},
  {coord: {lat:45.749901, lng:21.241012}, link: 'https://pizzanapoleon.ro/'}
]
var svg = '<svg style="display:block;" xmlns="http://www.w3.org/2000/svg" width="38" height="47" viewBox="0 0 38 47" style="margin: -45px 0px 0px -19px; z-index: 0; transform: matrix(1, 0, 0, 1, 464.8, 250.4); position: absolute;"><g fill="none"><path fill="#0F1621" fill-opacity=".4" d="M15 46c0 .317 1.79.574 4 .574s4-.257 4-.574c0-.317-1.79-.574-4-.574s-4 .257-4 .574z"></path><path fill="#01b6b2" d="M33.25 31.652A19.015 19.015 0 0 0 38 19.06C38 8.549 29.478 0 19 0S0 8.55 0 19.059c0 4.823 1.795 9.233 4.75 12.593L18.975 46 33.25 31.652z"></path><path fill="#6A6D74" fill-opacity=".5" d="M26.862 37.5l4.714-4.77c3.822-3.576 5.924-8.411 5.924-13.62C37.5 8.847 29.2.5 19 .5S.5 8.848.5 19.11c0 5.209 2.102 10.044 5.919 13.614l4.719 4.776h15.724zM19 0c10.493 0 19 8.525 19 19.041 0 5.507-2.348 10.454-6.079 13.932L19 46 6.079 32.973C2.348 29.495 0 24.548 0 19.04 0 8.525 8.507 0 19 0z"></path></g></svg>';
coord = {
  lat: (45.752289+45.749901)/2,
  lng: (21.224296+21.241012)/2}

var map = new H.Map(
  document.getElementById('mapContainer'),
  defaultLayers.vector.normal.map,{
    zoom: 13.5,
    center: coord,
});
positions.forEach(item => {
  map.addObject(new H.map.DomMarker(item.coord,
    {icon: new H.map.DomIcon('<div><a target="_blank" href="'+item.link+'">'+svg+'</a></div>')}
  ));
});

window.addEventListener('resize', () => map.getViewPort().resize());
var behavior = new H.mapevents.Behavior(new H.mapevents.MapEvents(map));
