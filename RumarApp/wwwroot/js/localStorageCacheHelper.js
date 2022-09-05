$.getDataAndSaveToCache = function (localStorageName, url, cacheExpirationMinutes = undefined) {
    $.get(url, function (data) {
        localStorage.setItem("cache_" + localStorageName, JSON.stringify(data));

        if (cacheExpirationMinutes !== undefined) {
            var millis = cacheExpirationMinutes * 60 * 1000;
            var cacheControl = {
                expiration: Date.now() + millis,
                url: url,
                expirationMinutes: cacheExpirationMinutes
            };

            localStorage.setItem("cache_control_" + localStorageName, JSON.stringify(cacheControl));
        }
    });
}

$.getCacheItem = function (localStorageName, _func) {
    var data = null;

    try {
        var cacheControl = JSON.parse(localStorage.getItem("cache_control_" + localStorageName));
        var cacheExpiration = cacheControl ? cacheControl.expiration : undefined;
        var isCacheExpired = false;

        if (cacheExpiration) {
            isCacheExpired = Date.now() > cacheExpiration;
        }

        if (!isCacheExpired) {
            data = JSON.parse(localStorage.getItem("cache_" + localStorageName));
        } else {
            $.removeCacheItem(localStorageName);

            $.getDataAndSaveToCache(localStorageName, cacheControl.url, cacheControl.expirationMinutes);

            setTimeout(function () {
                $.getCacheItem(localStorageName, _func);
            }, 500);

            return;
        }
    } catch (ex) {
        console.log("getCacheItem Error: Catch in JSON.parse");
    }

    _func(data);
}

$.removeCacheItem = function (localStorageName) {
    localStorage.removeItem("cache_" + localStorageName);
}

$.cacheConstants = {
    sessionCacheUrl: "/Security/LoadSession",
    sessionCacheName: "session",
    serverDataServerDateCacheExpireMinutes: 60
};