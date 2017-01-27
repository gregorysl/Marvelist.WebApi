import Axios from 'axios';
//localStorage = global.window.localStorage;

let auth = {
    login(username, password) {
        if (auth.loggedIn()) 
            return Promise.resolve(true);
        
        return request
            .post('/login', {username, password})
            .then(response => {
              //  localStorage.token = response.token;
                return Promise.resolve(true);
            });
    },
    logout() {
        return request.post('/logout');
    },
    loggedIn() {
        return true//!!localStorage.token;
    },
    register(username, password) {
        return request
            .post('/register', {username, password})
            .then(() => auth.login(username, password));
    },
    onChange() {}
};

export default auth;

let request = {
    post(endpoint, data) {
        switch (endpoint) {
            case '/login':
                return server.login(data.username, data.password);
            case '/register':
                return server.register(data.username, data.password);
            case '/logout':
                return server.logout();
            default:
                break;
        }
    }
};

let server = {
    login(username, password) {
        return new Promise((resolve, reject) => {
            const apiUrl = "uri";
            Axios
                .post(apiUrl, {username, password})
                .then(response => {
                    if (response.status >= 200 && response.status < 300) {
                        resolve({authenticated: true, token: response.token});
                    }
                })
                .catch(error => {
                    reject(error);
                });

        });
    },
    register(username, password) {
        return new Promise((resolve, reject) => {

            const apiUrl = "uri";
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
    },
    logout() {
        return new Promise(resolve => {
           // localStorage.removeItem('token');
            resolve(true);
        });
    }
};
