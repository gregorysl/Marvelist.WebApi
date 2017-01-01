import AppDispatcher from '../dispatchers/AppDispatcher';
import AppConstants from '../AppConstants';

let loginAction = function (payload) {
    AppDispatcher.dispatch(AppConstants.USER_LOGIN, payload);
};

let logOutAction = function (payload) {
    AppDispatcher.dispatch(AppConstants.USER_LOGOUT, payload);
};

let registerAction = function (payload) {
    AppDispatcher.dispatch(AppConstants.USER_REGISTER, payload);
};

let AccountActions = {
    login: loginAction,
    logOut: logOutAction,
    register: registerAction
};
export default AccountActions;