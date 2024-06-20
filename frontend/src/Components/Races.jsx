import React, {
    useEffect,
    useState
} from "react";
import raceService from "../services/RaceService.js";
import animalService from '../services/AnimalService.js';

const Races = () => {
    const [searchByName, setSearchByName] = useState('');
    const [newRaceName, setNewRaceName] = useState('');
    const [newRaceDescription, setNewRaceDescription] = useState('');
    const [newRaceAnimalId, setNewRaceAnimalId] = useState(-1);
    const [listOfRaces, setListOfRaces] = useState([]);
    const [listOfAnimals, setListOfAnimals] = useState([]);
    const [error, setError] = useState(null);
    const [idToUpdate, setIdToUpdate] = useState(-1);
    const [animalidToUpdate, setAnimalidToUpdate] = useState(-1);
    const [nameUpdate, setNameUpdate] = useState('');
    const [descriptionUpdate, setDescriptionUpdate] = useState('');

    useEffect(() => {
        fetchRaces()
            .then(() => {});

    }, []);
    const fetchRaces = async () => {
        await fetchAnimals();
        const data = await raceService.getAll();
        setListOfRaces(data);
    };

    const fetchAnimals = async () => {
        const data = await animalService.getAll();
        setListOfAnimals(data);
    };

    const handleDeleteRace = async (id) => {
        await raceService.deleteRace(id);
        await fetchRaces();
    };

    const typeOfAnimal = (id) => {
        const animal = listOfAnimals.find(a => a.id === id);
        if (animal) return animal.name;
        return 'error animal id';
    };

    const handleUpdateRace = async () => {
        await raceService.updateRace(idToUpdate, nameUpdate, descriptionUpdate, animalidToUpdate);
        setIdToUpdate(-1);
        setAnimalidToUpdate(-1);
        setNameUpdate('');
        setDescriptionUpdate('');
        await fetchRaces();
    };

    const handleChangeAnimalType = (event) => {
        setAnimalidToUpdate(event.target.value);
    };

    const handleCreateRace = async (e) => {
        e.preventDefault();
        try {
            await raceService.createRace(newRaceName, newRaceDescription, newRaceAnimalId);

            await fetchRaces();

            setNewRaceName('');
            setNewRaceDescription('');
            setNewRaceAnimalId(-1);
            setError(null);
        }
        catch (error) {
            console.error('Error creating animal:', error);
            setError(error);
            if (error.response && error.response.status === 401) {
                console.log('Unauthorized access or token expired. Redirecting to login page...');
            }
        }
    };

    const AnimalTypeId = (event) => {
        setNewRaceAnimalId(event.target.value);
    };

    return (<div style={{

        margin: 'auto',
        padding: '20px',
        border: '1px solid #ccc',
        borderRadius: '5px'
    }}>{error && <p style={{
        color: 'red',
        marginBottom: '10px'
    }}>Error: {error.message}</p>}
        <h1 style={{
            fontSize: '18px',
            marginBottom: '30px'
        }}>Races</h1>
        <label>Search: </label>
        <input type="text" value={searchByName} onChange={(event) => {setSearchByName(event.target.value);}}/>
        <ul style={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            listStyleType: 'none',
            padding: '10px'
        }}>
            {listOfRaces.filter((e) => {
                if (searchByName === '') return true;
                return e.name.toLowerCase()
                    .startsWith(searchByName.toLowerCase());
            })
                .map(item => (item.id !== idToUpdate ? <li key={item.id} style={{
                    width: "100%",
                    display: "flex",
                    flexDirection: "row",
                    justifyContent: "space-between",
                    alignItems: "center",
                    gap: "5px",
                    marginBottom: '100px',
                    border: '1px solid #eee',
                    padding: '10px',
                    borderRadius: '5px'
                }}>
                    <div style={{
                        display: "flex",
                        flexDirection: "column",
                        justifyContent: "space-around"
                    }}>
                        <strong>{item.name}:</strong>
                        <strong><i>Type of animal</i>: {typeOfAnimal(item.animal.id)}</strong>
                    </div>
                    <p style={{
                        wordWrap: "break-word",
                        width: "50%"
                    }}>{item.description}</p>
                    <div style={{
                        display: "flex",
                        gap: "10px"
                    }}>
                        <button style={{
                            height: "50px",
                            width: "100px"
                        }} onClick={() => {
                            handleDeleteRace(item.id)
                                .then(() => {});
                        }}>Delete
                        </button>
                        <button style={{
                            height: "50px",
                            width: "100px"
                        }} onClick={() => {
                            setIdToUpdate(item.id);
                            setNameUpdate(item.name);
                            setDescriptionUpdate(item.description);
                            setAnimalidToUpdate(item.animal.id);
                        }}>Update
                        </button>
                    </div>
                </li> : <li key={item.id} style={{
                    width: "100%",
                    display: "flex",
                    flexDirection: "row",
                    justifyContent: "space-between",
                    alignItems: "center",
                    gap: "5px",
                    marginBottom: '100px',
                    border: '1px solid #eee',
                    padding: '10px',
                    borderRadius: '5px'
                }}>
                    <div
                        style={{
                            display: "flex",
                            flexDirection: "column",
                            justifyContent: "space-around"
                        }}
                    >
                        <input value={nameUpdate}
                               onChange={(event) => {setNameUpdate(event.target.value);}}></input>
                        <label><i>Type of animal</i></label>
                        <select value={animalidToUpdate} onChange={handleChangeAnimalType}>
                            <option value="" disabled>Select an option</option>
                            {listOfAnimals.map((animal, index) => (<option key={index} value={animal.id}
                                                                           selected={animal.id === animalidToUpdate}>{animal.name}</option>))}
                        </select>
                    </div>
                    <textarea style={{
                        wordWrap: "break-word",
                        width: "50%"
                    }}
                              value={descriptionUpdate}
                              onChange={(event) => {setDescriptionUpdate(event.target.value);}}
                    ></textarea>
                    <div style={{
                        display: "flex",
                        gap: "10px"
                    }}>
                        <button style={{
                            height: "50px",
                            width: "100px"
                        }} onClick={handleUpdateRace}>Ok
                        </button>
                        <button style={{
                            height: "50px",
                            width: "100px"
                        }} onClick={() => {
                            setIdToUpdate(-1);
                            setAnimalidToUpdate(-1);
                            setNameUpdate('');
                            setDescriptionUpdate('');
                        }}>Cancel
                        </button>
                    </div>
                </li>))}
        </ul>


        <h3 style={{
            fontSize: '16px',
            marginTop: '20px',
            marginBottom: '30px'
        }}>Add a New Race:</h3>
        <form onSubmit={handleCreateRace} style={{
            marginBottom: '20px',
            display: "flex",
            flexDirection: "column",
            gap: "20px",
            alignItems: "center",
            justifyContent: "space-around"
        }}>
            <div
                style={{
                    width: "50%",
                    display: "flex",
                    flexDirection: "row",
                    justifyContent: "space-around"
                }}>

                <label style={{
                    marginBottom: '10px'
                }}>
                    Name:
                </label>
                <input
                    type="text"
                    value={newRaceName}
                    onChange={e => setNewRaceName(e.target.value)}
                    style={{
                        marginLeft: '10px',
                        padding: '5px',
                        borderRadius: '3px',
                        border: '1px solid #ccc'
                    }}
                />
                <label><i>Type of animal</i></label>
                <select value={newRaceAnimalId} onChange={(event) => {AnimalTypeId(event);}}>
                    <option value="" selected={true}>Select an option</option>
                    {listOfAnimals.map((animal, index) => (<option key={index} value={animal.id}
                    >{animal.name}</option>))}
                </select>
            </div>
            <br/>
            <div
                style={{
                    width: "50%",
                    display: "flex",
                    flexDirection: "row",
                    justifyContent: "space-around"
                }}>

                <label style={{
                    display: 'block',
                    marginBottom: '10px'
                }}>
                    Description:
                </label>
                <textarea
                    value={newRaceDescription}
                    onChange={e => setNewRaceDescription(e.target.value)}
                    style={{
                        marginLeft: '10px',
                        padding: '5px',
                        borderRadius: '3px',
                        border: '1px solid #ccc'
                    }}
                />
            </div>
            <br/>
            <button type="submit" style={{
                padding: '8px 20px',
                backgroundColor: '#007bff',
                color: '#fff',
                border: 'none',
                borderRadius: '3px',
                cursor: 'pointer'
            }}>Create Animal
            </button>
        </form>
    </div>);
};

export default Races;
