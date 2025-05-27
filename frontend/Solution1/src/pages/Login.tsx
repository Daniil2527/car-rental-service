import { useState } from "react";
import axios from "axios";
import { useAuth } from "../context/AuthContext";
import { useNavigate } from "react-router-dom";

const Login = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();
    const { login } = useAuth();

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const response = await axios.post("/auth/login", {
                email,
                password,
            });

            const { token, user } = response.data;

            // Корректно сериализуем перед сохранением
            localStorage.setItem("token", JSON.stringify(token));
            localStorage.setItem("user", JSON.stringify(user));

            login(user, token);
            navigate("/");
        } catch (error) {
            alert("Ошибка входа");
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>Вход</h2>
            <input
                type="email"
                placeholder="Email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
            />
            <input
                type="password"
                placeholder="Пароль"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
            />
            <button type="submit">Войти</button>
        </form>
    );
};

export default Login;