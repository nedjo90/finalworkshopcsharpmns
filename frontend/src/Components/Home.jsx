import React, {
    useState,
    useEffect
} from 'react';
import animalService from '../services/Animal';

const Home = ({username}) => {
    const [animals, setAnimals] = useState([]);
    const [newAnimalName, setNewAnimalName] = useState('');
    const [newAnimalDescription, setNewAnimalDescription] = useState('');
    const [error, setError] = useState(null);

    const fetchAnimals = async () => {
        await animalService.getAll()
            .then(data => {
                setAnimals(data);
                setError(null);
            })
            .catch(error => {
                console.error('Error fetching animals:', error);
                setError(error);
            });
    };

    const handleCreateAnimal = async () => {
        await animalService.create(newAnimalName, newAnimalDescription)
            .then(createdAnimal => {
                console.log('Animal created:', createdAnimal);
                fetchAnimals();
                setNewAnimalName('');
                setNewAnimalDescription('');
                setError(null);
            })
            .catch(error => {
                console.error('Error creating animal:', error);
                setError(error);
            });
    };

    return (
        <div style={{
            maxWidth: '600px',
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
                listStyleType: 'none',
                padding: '0'
            }}>
                {animals.map(animal => (
                    <li key={animal.id} style={{
                        marginBottom: '10px',
                        border: '1px solid #eee',
                        padding: '10px',
                        borderRadius: '5px'
                    }}>
                        <strong>{animal.name}</strong>: {animal.description}
                    </li>
                ))}
            </ul>

            <h3 style={{
                fontSize: '16px',
                marginTop: '20px',
                marginBottom: '10px'
            }}>Add a New Animal:</h3>
            <form onSubmit={handleCreateAnimal} style={{marginBottom: '20px'}}>
                <label style={{
                    display: 'block',
                    marginBottom: '10px'
                }}>
                    Name:
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
                </label>
                <br/>
                <label style={{
                    display: 'block',
                    marginBottom: '10px'
                }}>
                    Description:
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
                </label>
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
