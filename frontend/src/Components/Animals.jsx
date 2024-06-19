import React, {
    useState,
    useEffect
} from 'react';
import animalService from '../services/AnimalService.js';

const Animals = ({username}) => {
    const [searchByName, setSearchByName] = useState('');
    const [newAnimalName, setNewAnimalName] = useState('');
    const [newAnimalDescription, setNewAnimalDescription] = useState('');
    const [listOfAnimals, setListOfAnimals] = useState([]);
    const [error, setError] = useState(null);
    const [idToUpdate, setIdToUpdate] = useState(-1);
    const [nameUpdate, setNameUpdate] = useState('');
    const [descriptionUpdate, setDescriptionUpdate] = useState('');

    useEffect(() => {
        fetchAnimals();
    }, []);

    const fetchAnimals = async () => {
        const data = await animalService.getAll();
        setListOfAnimals(data);
    };

    const handleDeleteAnimal = async (id) => {
        await animalService.deleteAnimal(id);
        fetchAnimals();
    };

    const handleUpdateAnimal = async () => {
        await animalService.updateAnimal(idToUpdate, nameUpdate, descriptionUpdate);
        setIdToUpdate(-1);
        setNameUpdate('');
        setDescriptionUpdate('');
        await fetchAnimals();
    };

    const handleCreateAnimal = async (e) => {
        e.preventDefault();

        try {
            const createdAnimal = await animalService.create(newAnimalName, newAnimalDescription);
            console.log('Animal created:', createdAnimal);

            await fetchAnimals();

            setNewAnimalName('');
            setNewAnimalDescription('');
            setError(null);
        }
        catch (error) {
            console.error('Error creating animal:', error);
            setError(error);

            // Gérer spécifiquement les erreurs liées aux tokens JWT ici
            if (error.response && error.response.status === 401) {
                // Redirection vers la page de login ou affichage d'un message d'erreur
                console.log('Unauthorized access or token expired. Redirecting to login page...');
            }
        }
    };

    return (<div style={{

        margin: 'auto',
        padding: '20px',
        border: '1px solid #ccc',
        borderRadius: '5px'
    }}>
        {error && <p style={{
            color: 'red',
            marginBottom: '10px'
        }}>Error: {error.message}</p>}

        <h1 style={{
            fontSize: '18px',
            marginBottom: '30px'
        }}>Animals</h1>
        <label>Search: </label>
        <input type="text" value={searchByName} onChange={(event) => {setSearchByName(event.target.value);}}/>
        <ul style={{
            display: "flex",
            flexDirection: "column",
            alignItems: "center",
            listStyleType: 'none',
            padding: '10px'
        }}>
            {listOfAnimals.filter((e) => {
                if (searchByName === '')
                    return true;
                return e.name.toLowerCase()
                    .startsWith(searchByName.toLowerCase());
            })
                .map(item => (item.id !== idToUpdate ? <>
                    <li key={item.id} style={{
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

                        <strong>{item.name}:</strong>

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
                            }} onClick={() => handleDeleteAnimal(item.id)}>Delete
                            </button>
                            <button style={{
                                height: "50px",
                                width: "100px"
                            }} onClick={() => {
                                setIdToUpdate(item.id);
                                setNameUpdate(item.name);
                                setDescriptionUpdate(item.description);
                            }}>Update
                            </button>
                        </div>
                    </li>
                </> : <>
                    <li key={item.id} style={{
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
                    }}><input value={nameUpdate}
                              onChange={(event) => {setNameUpdate(event.target.value);}}></input>
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
                            }} onClick={() => handleUpdateAnimal()}>Ok
                            </button>
                            <button style={{
                                height: "50px",
                                width: "100px"
                            }} onClick={() => {
                                setIdToUpdate(-1);
                                setNameUpdate('');
                                setDescriptionUpdate('');
                            }}>Cancel
                            </button>
                        </div>
                    </li>
                </>))}
        </ul>

        <h3 style={{
            fontSize: '16px',
            marginTop: '20px',
            marginBottom: '30px'
        }}>Add a New Animal:</h3>
        <form onSubmit={handleCreateAnimal} style={{
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
                    value={newAnimalName}
                    onChange={e => setNewAnimalName(e.target.value)}
                    style={{
                        marginLeft: '10px',
                        padding: '5px',
                        borderRadius: '3px',
                        border: '1px solid #ccc'
                    }}
                />
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
                    value={newAnimalDescription}
                    onChange={e => setNewAnimalDescription(e.target.value)}
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

export default Animals;
