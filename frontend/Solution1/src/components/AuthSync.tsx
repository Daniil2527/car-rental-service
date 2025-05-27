import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import { setAuthHandlers } from "../api";

const AuthSync = () => {
    const { logout } = useAuth();
    const navigate = useNavigate();

    useEffect(() => {
        setAuthHandlers(logout, navigate);
    }, [logout, navigate]);

    return null; // компонент без визуала, только для синхронизации
};

export default AuthSync;