import React, { useEffect, useState } from "react";
import { Await, Link, useNavigate, useParams } from "react-router-dom";
import { FiArrowLeft} from 'react-icons/fi'


import './style.css';

import logoImage from '../../assets/logo.svg'

import api from "../../services/api";

export default function NewBook() {

    const [id, setId] = useState(null);
    const [author, setAuthor] = useState('');
    const [title, setTitle] = useState('');
    const [launchDate, setLaunchDate] = useState('');
    const [price, setPrice] = useState('');

    const {bookId }= useParams();

    const navigate = useNavigate();

    const accessToken = localStorage.getItem('accessToken');
    const authorization = {
        headers : {
            'Content-Type' : 'application/json',
            'Accept' : 'application/json',
            'Authorization' : `Bearer ${accessToken}`
          }
    }

    useEffect(()=> {
        if (bookId === '0') return;
        else loadBook();
    }, bookId);

    async function loadBook(){
        try {
          const response = await api.get(`api/book/v1/${bookId}`, authorization)  

          let adjustedDate = response.data.launchDate.split("T", 10)[0];

          setId(response.data.id);
          setTitle(response.data.title);
          setAuthor(response.data.author);
          setLaunchDate(adjustedDate);
          setPrice(response.data.price);

        } catch (error) {
            alert('Erro recovering Book! Try again!');
            navigate('/books');
        }
    }

    async function createNewBook(e) {
        e.preventDefault();

        const data = {
            title,
            author,
            launchDate,
            price,
        }

        console.log(`Bearer ${accessToken.toString()}`);

        try {
            await api.post('api/Book/v1', data, authorization);
            navigate('/books');
        } catch (error) {
            alert('Error while recording Book! Try again!');
            console.log(error.message);
        }
    }

    return (
        <div className="new-book-container">
            <div className="content">
                <section className="form">
                    <img src={logoImage} alt="Erudio" />
                    <h1>Add New Book</h1>
                    <p>Enter the book infomation an click on 'Add'! ##### ${bookId} </p>
                    <Link className="back-link" to="/books">
                        <FiArrowLeft size={16} color="#251fc5" />
                        Home
                    </Link>
                </section>

                <form onSubmit={createNewBook}>
                    <input 
                        placeholder="Title" 
                        value={title}
                        onChange={ e => setTitle(e.target.value)}
                    />
                    
                    <input 
                        placeholder="Author" 
                        value={author}
                        onChange={ e => setAuthor(e.target.value)}
                    />

                    <input 
                        type="date"
                        placeholder="Date"
                        value={launchDate}
                        onChange={ e => setLaunchDate(e.target.value)} 
                    />

                    <input 
                        placeholder="Price" 
                        value={price}
                        onChange={ e => setPrice(e.target.value)}
                    />

                    <button className="button" type="submit">Add</button>
                </form>
            </div>
        </div>

    );
}