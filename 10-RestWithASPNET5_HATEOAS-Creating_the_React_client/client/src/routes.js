import React from "react";
import { BrowserRouter, Route, Routes} from "react-router-dom";

import Login from "./pages/Login";
import Books from "./pages/Books";
import NewBook from "./pages/NewBook";

export default function MyRoutes() {
    return(
        <BrowserRouter>
            <Routes>
                <Route path="/" exact Component={Login}/>
                <Route path="/books" Component={Books}/>
                <Route path="/book/new" Component={NewBook}/>
            </Routes>
        </BrowserRouter>
    );
}