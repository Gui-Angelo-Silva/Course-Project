import React from 'react'
import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';
import Login from './pages/login';
import Home from './pages/home';
import MyRestaurant from './pages/myrestaurant';

const AppRoutes = () => {
    return (
        <Router>
            <Routes>
                <Route path='/' element={<Login />} />
                <Route path='/inicio' element={<Home />} />
                <Route path='/restaurante' element={<MyRestaurant />} />
            </Routes>
        </Router>
    )
}

export default AppRoutes