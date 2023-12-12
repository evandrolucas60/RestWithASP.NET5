import Reac, {useState, useEffect} from "react";
import { Link, useNavigate } from "react-router-dom";
import { FiPower, FiEdit, FiTrash2} from 'react-icons/fi'
import './style.css';

import logoImage from '../../assets/logo.svg'

import api from "../../services/api";

export default function Books() {

    const [books, setBooks] = useState([]);

    const username = localStorage.getItem('username');

    const accessToken = localStorage.getItem('accessToken');

    const navigate = useNavigate();

    useEffect(()=>{
        api.get('api/Book/v1/asc/5/1',  {
            headers : {
                'Content-Type' : 'application/json',
                'Accept' : 'application/json',
                'Authorization' : `Bearer ${accessToken}`
              }
        }).then(response=>{
            setBooks(response.data.list)
        })
    }, [accessToken]);

    return (
        <div className="book-container">
            <header>
                <img src={logoImage} alt="Erudio" />
                <span>Welcome, <strong>{username.toUpperCase()}</strong>!</span>
                <Link className="button" to="/book/new">Add New Book</Link>
                <button type="button">
                    <FiPower size={18} color="#251fc5" />
                </button>
            </header>

            <h1>Resgistered Books</h1>
            <ul>
               {books.map(book=>(
                    <li key={book.id}>
                        <strong>Title</strong>
                        <p>{book.title}</p>
                        <strong>Author:</strong>
                        <p>{book.author}</p>
                        <strong>Price</strong>
                        <p>{Intl.NumberFormat('pt-BR', {style: 'currency', currency: 'BRL'}).format(book.price)}</p>
                        <strong>Release</strong>
                        <p>{Intl.DateTimeFormat('pt-BR').format(new Date(book.launchDate))}</p>

                        <button type="button">
                            <FiEdit size={20} color="#251fc5" />
                        </button>

                        <button type="button">
                            <FiTrash2 size={20} color="#251fc5" />
                        </button>
                    </li>
               ))}
            </ul>
        </div>
    );
}