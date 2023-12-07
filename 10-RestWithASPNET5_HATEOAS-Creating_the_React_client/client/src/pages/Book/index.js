import React from "react";
import { Link } from "react-router-dom";
import { FiPower} from 'react-icons/fi'
import './style.css';

import logoImage from '../../assets/logo.svg'

export default function Book() {
    return (
        <div className="book-container">
            <header>
                <img src={logoImage} alt="Erudio" />
                <span>Welcome, <strong>Evandro</strong>!</span>
                <Link className="button" to="book/new">Add New Book</Link>
                <button type="button">
                    <FiPower size={18} color="#251fc5" />
                </button>
            </header>
        </div>
    );
}