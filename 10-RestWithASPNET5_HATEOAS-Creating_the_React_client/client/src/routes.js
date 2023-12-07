import React from "react";
import { BrowserRouter, Route, Routes} from "react-router-dom";

import Login from "./pages/Login";

export default function MyRoutes() {
    return(
        <BrowserRouter>
            <Routes>
                <Route path="/" Component={Login}/>
            </Routes>
        </BrowserRouter>
    );
}