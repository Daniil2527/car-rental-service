import { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";
import { useAuth } from "../context/AuthContext";
import toast from "react-hot-toast";

const Register = () => {
    const { login } = useAuth();
    const navigate = useNavigate();

    const [form, setForm] = useState({
        fullName: "",
        email: "",
        phoneNumber: "",
        password: "",
    });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const response = await axios.post("http://localhost:5123/api/users", form);
            const { token, user } = response.data;

            login(token, user);
            toast.success("Регистрация прошла успешно!");
            setTimeout(() => navigate("/orders"), 1000);
        } catch {
            toast.error("Не удалось зарегистрироваться.");
        }
    };

    return (
        <div className="max-w-md mx-auto mt-10">
            <h2 className="text-2xl font-bold mb-6 text-center">Регистрация</h2>
            <form onSubmit={handleSubmit} className="space-y-4">
                <input
                    name="fullName"
                    type="text"
                    placeholder="ФИО"
                    value={form.fullName}
                    onChange={handleChange}
                    required
                    className="w-full border rounded p-2"
                />
                <input
                    name="email"
                    type="email"
                    placeholder="Email"
                    value={form.email}
                    onChange={handleChange}
                    required
                    className="w-full border rounded p-2"
                />
                <input
                    name="phoneNumber"
                    type="text"
                    placeholder="Телефон"
                    value={form.phoneNumber}
                    onChange={handleChange}
                    required
                    className="w-full border rounded p-2"
                />
                <input
                    name="password"
                    type="password"
                    placeholder="Пароль"
                    value={form.password}
                    onChange={handleChange}
                    required
                    className="w-full border rounded p-2"
                />

                <button
                    type="submit"
                    className="w-full bg-blue-600 text-white py-2 rounded hover:bg-blue-700"
                >
                    Зарегистрироваться
                </button>
            </form>
        </div>
    );
};

export default Register;
