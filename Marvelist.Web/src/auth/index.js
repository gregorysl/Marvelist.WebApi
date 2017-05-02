import Axios from 'axios';

let auth = {
    login(username, password) {
        if (auth.loggedIn())
            return Promise.resolve(true);
        debugger
        return server
            .login(username, password)
            .then(response => {
                localStorage.setItem("access_token", response.data.access_token);
                localStorage.setItem("expires", response.data[".expires"]);
                localStorage.setItem("username", response.data.userName);
                return Promise.resolve(response);
            });
    },
    logout() {
        return new Promise(resolve => {
            localStorage.removeItem("expires");
            localStorage.removeItem("access_token");
            localStorage.removeItem("username");
            resolve(true);
        });
    },
    loggedIn() {
        let token = localStorage.getItem("access_token");
        return !!token && !this.expired();
    },
    expired() {
        let expiryDate = localStorage.getItem("expires");
        let expired = !expiryDate || (new Date(expiryDate) < new Date());
        if (expired) {
            this.logout();
        }
        return expired;
    },
    username() {
        let username = localStorage.getItem('username');
        return this.loggedIn() && username ? username : "";
    },
    register(username, password, email) {
        return server
            .register(username, password, email)
            .then(() => auth.login(username, password));
    }
};

export default auth;
const api = 'http://localhost/Marvelist/';
let server = {
    login(username, password) {
        return new Promise((resolve, reject) => {
            const apiUrl = api + "Token";
            let querystring = require('querystring');

            Axios.post(apiUrl, querystring.stringify({ username, password, 'grant_type': 'password' }), {
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded"
                }
            }).then(response => {
                if (response.status >= 200 && response.status < 300) {
                    resolve({ authenticated: true, data: response.data });
                }
            }).catch(error => {
                reject(new Error(error.response.data.error_description));
            });

        });
    },
    register(username, password, email) {
        return new Promise((resolve, reject) => {
            const apiUrl = api + '/api/Register';
            Axios
                .post(apiUrl, { username, password, email })
                .then(response => {
                    if (response.status >= 200 && response.status < 300) {
                        resolve({ registered: true });
                    }
                })
                .catch(error => {
                    reject(new Error('Username already in use. Error: ' + error));
                });

        });
    }
};
