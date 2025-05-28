import React from "react";
import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";

const Navbar: React.FC = () => {
    const { user, logout } = useAuth();
    const navigate = useNavigate();

    const handleLogout = () => {
        logout();
        navigate("/login");
    };

    return (
        <nav>
            <Link to="/">Car Rental & Sales</Link>
            <Link to="/cars">Машины</Link>
            {user ? (
                <>
                    <Link to="/orders">Заказы</Link>
                    <Link to="/create-order">Создать заказ</Link>
                    <button onClick={handleLogout}>Выйти</button>
                </>
            ) : (
                <>
                    <Link to="/login">Войти</Link>
                    <Link to="/register">Регистрация</Link>
                </>
            )}
        </nav>
    );
};

export default Navbar;