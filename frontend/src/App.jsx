import {useState} from 'react';
import './App.css';
import './Components/Home.jsx';
import Home from "./Components/Home.jsx";
import authService from "./services/Authentication.js";
import {toast} from 'react-toastify';

function App() {
    const [isSign, setIsSignIn] = useState(false);
    const [isLogin, setIsLogin] = useState(false);
    const [username, setUsername] = useState('');
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');

    const handleRegistration = async () => {
        const response = await authService.registration(username, email, password);
        if (response.status === 201) {
            setIsSignIn(true);
        }
    };

    const handleLogin = async () => {
        const response = await authService.login(username, password);
        if (response.status === 200) {
            setIsLogin(true);
        }
        if (response.status === 400) {
            toast.error('wrong');
        }
    };
    return (
        <>
            {
                isSign ?
                    isLogin ?
                        <Home username={username}/> :
                        <div>
                            <h2>Login</h2>
                            <ul style={{listStyleType: "none"}}>
                                <li>
                                    <input type="text" value={username} onChange={(e) => setUsername(e.target.value)}
                                           placeholder="UserName"/>
                                </li>
                                <li>
                                    <input type="password" value={password}
                                           onChange={(e) => setPassword(e.target.value)}
                                           placeholder="Password"/>
                                </li>
                                <button onClick={handleLogin}>Login</button>
                            </ul>
                        </div>
                    : <div>
                        <h2>Sign In</h2>
                        <ul style={{listStyleType: "none"}}>
                            <li>
                                <input type="text" value={username} onChange={(e) => setUsername(e.target.value)}
                                   placeholder="UserName"/>
                            </li>
                            <li>
                                <input type="email" value={email} onChange={(e) => setEmail(e.target.value)}
                                   placeholder="Email"/>
                            </li>
                            <li>
                                <input type="password" value={password} onChange={(e) => setPassword(e.target.value)}
                                   placeholder="Password"/>
                            </li>
                            <button onClick={handleRegistration}>Sign In</button>
                        </ul>
                    </div>
            }
        </>
    );
}

export default App;
