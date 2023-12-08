import React, { useState } from "react";
import { useNavigate  } from 'react-router-dom';

import api from "../../services/api";

import './style.css';

import logoImage from '../../assets/logo.svg'
import padlock from '../../assets/padlock.png'

export default function Login() {
    const [username, setUserName] = useState('');
    const [password, setPassword] = useState('');

    const history = useNavigate();

    async function login(e) {
        e.preventDefault();

        const data = {
            username,
            password,
        };

        try {
          const response = await api.post('api/Auth/v1/signin', data);

          localStorage.setItem('username', username);
          localStorage.setItem('accessToken', JSON.stringify(response.data.accessToken));
          localStorage.setItem('refreshToken', JSON.stringify(response.data.refreshToken));

          history('/books');

        } catch (error) {
            alert("Login Failed! Try again!");
            console.log(error);
        }
    }

    return (
        <div className="login-container">
            <section className="form">
                <img src={logoImage} alt="Erudio Logo" />
                <form onSubmit={login}>
                    <h1>Access your Account</h1>

                    <input
                        placeholder="Username"
                        value={username}
                        onChange={e => setUserName(e.target.value)}
                    />
                    
                    <input 
                        type="password" 
                        placeholder="password" 
                        value={password}
                        onChange={e => setPassword(e.target.value)}
                    />

                    <button className="button" type="submit">Login</button>
                </form>
            </section>
            <img src={padlock} alt="Login" />
        </div>
    );
}