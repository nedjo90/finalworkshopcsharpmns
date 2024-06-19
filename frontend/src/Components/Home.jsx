import React, {
    useState,
    useEffect
} from 'react';
import animalService from '../services/Animal';

const Home = ({username}) => {
    const [animals, setAnimals] = useState([]);
    const [newAnimalName, setNewAnimalName] = useState('');
    const [newAnimalDescription, setNewAnimalDescription] = useState('');
    const [listOfAnimals, setListOfAnimals] = useState([]);
    const [error, setError] = useState(null);

    useEffect(() => {
        fetchAnimals();
    }, []);

    const fetchAnimals = async () => {
        const data = await animalService.getAll();
        setListOfAnimals(data);
    };

    const handleDeleteAnimal = async () => {

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

    return (
        <div style={{
            maxWidth: '1000px',
            margin: 'auto',
            padding: '20px',
            border: '1px solid #ccc',
            borderRadius: '5px'
        }}>
            <p style={{
                fontSize: '20px',
                marginBottom: '20px'
            }}>Welcome, {username}!</p>

            {error && <p style={{
                color: 'red',
                marginBottom: '10px'
            }}>Error: {error.message}</p>}

            <h2 style={{
                fontSize: '18px',
                marginBottom: '10px'
            }}>Animals:</h2>
            <ul style={{
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
                listStyleType: 'none',
                padding: '10px'
            }}>
                {listOfAnimals.map(item => (
                    <>
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
                        }}><strong>{item.name}:</strong>
                            <p style={{
                                wordWrap: "break-word",
                                width: "50%"
                            }}>{item.description}</p>
                            <button style={{
                                height: "50px",
                                width: "100px"
                            }} onClick={() => handleDeleteAnimal(item.id)}>Delete
                            </button>
                        </li>
                    </>
                ))}
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
                    <input
                        type="text"
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
        </div>
    );
};

export default Home;
