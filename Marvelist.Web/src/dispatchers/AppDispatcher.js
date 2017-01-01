let AppDispatcher = function () { };

let callbacks = [];

AppDispatcher.prototype.register = function (callback) {
    callbacks.push(callback);
};

AppDispatcher.prototype.dispatch = function (actionType,payload) {
    for (let i = 0; i < callbacks.length; i++) {
        callbacks[i](actionType, payload);
    }
};

export default new AppDispatcher();