import Animals from "./Animals.jsx";
import React, {useState} from "react";
import Races from "./Races.jsx";

const Home = ({username}) => {
    const [animalsPage, setAnimalsPage] = useState(true);

    return (<div>
            <h1 style={{
                fontSize: '20px',
                marginBottom: '20px'
            }}>Welcome, {username === '' ? 'John Doe' : username}!</h1>
            <div style={{
                display: "flex",
                justifyContent: "space-around",
                marginBottom: "30px"
            }}>
                <button style={{
                    width: "20%",
                    background: "white",
                    color: "black"
                }}
                        onClick={() => {if (animalsPage === false) setAnimalsPage(true);}}
                >Animals
                </button>
                <button style={{
                    width: "20%",
                    background: "white",
                    color: "black"
                }} onClick={() => {if (animalsPage === true) setAnimalsPage(false);}}> Races
                < /button>
            </div>
            {animalsPage ?
                <Animals username={username}/>
                : <Races username={username}/>}
        </div>
    );
};

export default Home;
