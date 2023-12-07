import React from "react";
import { BrowserRouter, Route, Routes} from "react-router-dom";

import Login from "./pages/Login";
import Book from "./pages/Book";

export default function MyRoutes() {
    return(
        <BrowserRouter>
            <Routes>
                <Route path="/" exact Component={Login}/>
                <Route path="/book" Component={Book}/>
            </Routes>
        </BrowserRouter>
    );
}