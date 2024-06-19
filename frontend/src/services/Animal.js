import axios from "axios";

const baseUrl = 'http://localhost:5040/api/animals';

const getById = (id) =>{
    return axios.get(`${baseUrl}/id`)
        .then(response => {
            return JSON.parse(response.data);
        })
}

const getAll = () =>{
    return axios.get(`${baseUrl}`)
        .then(response => {
            return response.data;
        })
}

const create = (name, description) =>{
    const newAnimal = {
        name: name,
        description: description
    }
    const axiosInstance = axios.create({
        timeout: 10000, // Timeout de 10 secondes (ou plus si nécessaire)
    });
    return axiosInstance.post(`${baseUrl}`, newAnimal)
        .then(response => {
            return response;
        })
}

export default {create, getAll, getById}