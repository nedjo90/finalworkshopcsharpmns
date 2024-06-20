import axios from "axios";

const baseUrl = 'http://localhost:5040/api/races';

const getAll = () =>{
    return axios.get(`${baseUrl}`)
        .then(response => {
            return response.data
        })
}

const deleteRace = (id) => {
    return axios.delete(`${baseUrl}/${id}`);
}

const updateRace = (id, name, description, animalid) => {
    const race = {
        id: id,
        name: name,
        description: description,
        animalid: animalid * 1
    }
    return axios.put(`${baseUrl}/${id}`, race);
}

const createRace = (name, description, animalid) =>{
    const newAnimal = {
        name: name,
        description: description,
        animalid: animalid
    }
    const axiosInstance = axios.create({
        timeout: 10000, // Timeout de 10 secondes (ou plus si nécessaire)
    });
    return axiosInstance.post(`${baseUrl}`, newAnimal)
        .then(response => {
            return response;
        })
}

export default {getAll, deleteRace, updateRace, createRace}