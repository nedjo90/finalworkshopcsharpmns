import axios from "axios";

const baseUrl = 'http://mysql:5040/api/authentication'

const registration = (username, email, password) => {
    const userData = {
        username: username,
        email: email,
        password: password
    };

    return axios.post(baseUrl, userData)
        .then(response => {
            return response;
        })
};

const login = (username, password) => {
    const userData = {
        username: username,
        password: password
    };

    return axios.post(`${baseUrl}/login`, userData)
        .then(response => {
            return response;
        })
};

export default {registration, login}
