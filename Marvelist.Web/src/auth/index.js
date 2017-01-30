import Axios from 'axios';

let auth = {
    login(username, password) {
        // if (auth.loggedIn()) 
        //     return Promise.resolve(true);
        
        return server
            .login(username, password)
            .then(response => {
                localStorage.setItem("access_token", response.data.access_token);
                localStorage.setItem("username", response.data.userName);
                return Promise.resolve(response);
            });
    },
    logout() {
        return new Promise(resolve => {

            localStorage.removeItem("access_token");
            localStorage.removeItem("username");
            resolve(true);
        });
    },
    loggedIn() {
        let token = localStorage.getItem("access_token");
        return !!token;
    },
    register(username, password) {
        return server
            .register(username, password)
            .then(() => auth.login(username, password));
    },
    onChange() {}
};

export default auth;
const api = 'http://localhost/Marvelist/';
let server = {
    login(username, password) {
        return new Promise((resolve, reject) => {
            const apiUrl = api + "Token";
            let querystring = require('querystring');

            Axios.post(apiUrl, querystring.stringify({username, password, 'grant_type': 'password'}), {
                headers: {
                    "Content-Type": "application/x-www-form-urlencoded"
                }
            }).then(response => {
                if (response.status >= 200 && response.status < 300) {
                    resolve({authenticated: true, data: response.data});
                }
            }).catch(error => {
                reject(error);
            });

        });
    },
    register(username, password) {
        return new Promise((resolve, reject) => {
            const apiUrl = api +'/api/Register';
            Axios
                .post(apiUrl, {username, password})
                .then(response => {
                    if (response.status >= 200 && response.status < 300) {

                        resolve({registered: true});
                        //resolve({authenticated: true, token: response.token});
                    }
                })
                .catch(error => {
                    reject(new Error('Username already in use'));
                });

        });
    }
};
