$.getDataAndSaveToCache = function (localStorageName, url) {
    $.get(url, function (data) {
        localStorage.setItem('cache_' + localStorageName, JSON.stringify(data));
    });
}

$.getCacheItem = function (localStorageName, _func) {
    var data = null;

    try {
        data = JSON.parse(localStorage.getItem('cache_' + localStorageName));
    } catch {
        console.log('getCacheItem Error: Catch in JSON.parse');
    }

    _func(data);
}

$.removeCacheItem = function (localStorageName) {
    localStorage.removeItem('cache_' + localStorageName);
}

$.cacheConstants = {
    countryCacheUrl: "/Lookups/GetCountries",
    countryCacheName: 'countries',
    identicationTypesForLocalCustomersCacheUrl: "/Lookups/GetIdenticationTypesForLocalCustomers",
    identicationTypesForLocalCustomersCacheName: 'identicationTypesForLocalCustomers',
    identicationTypesForInternacionalCustomersCacheUrl: "/Lookups/GetIdenticationTypesForInternacionalCustomers",
    identicationTypesForInternacionalCustomersCacheName: 'identicationTypesForInternacionalCustomers'
};