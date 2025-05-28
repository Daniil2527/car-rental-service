import { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { useAuth } from "../context/AuthContext";

const Login = () => {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const navigate = useNavigate();
    const { login } = useAuth();

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const response = await axios.post("http://localhost:5123/api/users/login", {
                email,
                password,
            });

            const { Token, User } = response.data;

            console.log("Login response:", response.data);

            if (Token && User) {
                login(Token, User); // сохраняем в контекст
                localStorage.setItem("token", Token); // ✅ правильно сохраняем
                localStorage.setItem("user", JSON.stringify(User)); // ✅ правильно сохраняем
                navigate("/"); // переходим на главную
            } else {
                alert("Ошибка входа: неверный формат ответа от сервера");
            }
        } catch (error: any) {
            console.error("Ошибка логина:", error);
            alert("Ошибка входа: неверный email или пароль");
        }
    };

    return (
        <div>
            <h2>Вход</h2>
            <form onSubmit={handleSubmit}>
                <div>
                    <label>Email:</label>
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div>
                    <label>Пароль:</label>
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Войти</button>
            </form>
        </div>
    );
};

export default Login;