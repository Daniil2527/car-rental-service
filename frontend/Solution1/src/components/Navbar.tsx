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

    const navStyle: React.CSSProperties = {
        display: "flex",
        justifyContent: "space-between",
        alignItems: "center",
        padding: "16px 32px",
        backgroundColor: "rgba(255, 255, 255, 0.9)",
        position: "sticky",
        top: 0,
        zIndex: 1000,
        borderBottom: "1px solid #ddd",
        backdropFilter: "blur(6px)",
    };

    const linkContainerStyle: React.CSSProperties = {
        display: "flex",
        gap: "24px",
        fontSize: "14px",
        fontWeight: 500,
    };

    const linkStyle: React.CSSProperties = {
        color: "#1f2937",
        textDecoration: "none",
        transition: "color 0.3s",
    };

    const linkHoverStyle = {
        color: "#dc2626",
    };

    return (
        <nav style={navStyle}>
            <Link to="/" style={{ ...linkStyle, fontSize: "20px", fontWeight: 700, color: "#dc2626" }}>
                Car Rental & Sales
            </Link>

            <div style={linkContainerStyle}>
                <Link to="/cars" style={linkStyle}>Машины</Link>

                {user ? (
                    <>
                        <Link to="/orders" style={linkStyle}>Заказы</Link>
                        <Link to="/create-order" style={linkStyle}>Создать заказ</Link>
                        <button
                            onClick={handleLogout}
                            style={{ ...linkStyle, background: "none", border: "none", cursor: "pointer" }}
                        >
                            Выйти
                        </button>
                    </>
                ) : (
                    <>
                        <Link to="/login" style={linkStyle}>Войти</Link>
                        <Link to="/register" style={linkStyle}>Регистрация</Link>
                    </>
                )}
            </div>
        </nav>
    );
};

export default Navbar;

