import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../api";

const Register = () => {
    const navigate = useNavigate();
    const [form, setForm] = useState({
        firstName: "",
        lastName: "",
        email: "",
        password: "",
        phoneNumber: "",
    });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setForm((prev) => ({ ...prev, [e.target.name]: e.target.value }));
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        const { firstName, lastName, email, password, phoneNumber } = form;
        const fullName = `${firstName} ${lastName}`.trim();

        try {
            await api.post("/users", {
                fullName,
                email,
                password,
                phoneNumber,
            });

            alert("Регистрация прошла успешно");
            navigate("/login");
        } catch (err: any) {
            const msg =
                err?.response?.data?.error ||
                "Ошибка регистрации. Проверьте введённые данные.";
            alert(msg);
            console.error(err);
        }
    };

    return (
        <div className="min-h-screen flex items-center justify-center bg-gradient-to-br from-red-600 to-pink-100 font-sans px-4">
            <form
                onSubmit={handleSubmit}
                className="bg-white p-8 rounded-2xl shadow-lg w-full max-w-md"
            >
                <h2 className="text-3xl font-bold text-center mb-6 text-gray-800">Регистрация</h2>

                <input
                    name="firstName"
                    placeholder="Имя"
                    value={form.firstName}
                    onChange={handleChange}
                    required
                    className="mb-4 w-full p-3 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-red-400"
                />
                <input
                    name="lastName"
                    placeholder="Фамилия"
                    value={form.lastName}
                    onChange={handleChange}
                    required
                    className="mb-4 w-full p-3 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-red-400"
                />
                <input
                    name="email"
                    type="email"
                    placeholder="Email"
                    value={form.email}
                    onChange={handleChange}
                    required
                    className="mb-4 w-full p-3 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-red-400"
                />
                <input
                    name="password"
                    type="password"
                    placeholder="Пароль"
                    value={form.password}
                    onChange={handleChange}
                    required
                    className="mb-4 w-full p-3 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-red-400"
                />
                <input
                    name="phoneNumber"
                    placeholder="Телефон"
                    value={form.phoneNumber}
                    onChange={handleChange}
                    required
                    className="mb-6 w-full p-3 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-red-400"
                />
                <button
                    type="submit"
                    className="w-full bg-red-500 hover:bg-red-600 text-white font-semibold py-3 rounded-md transition"
                >
                    Зарегистрироваться
                </button>
            </form>
        </div>
    );
};

export default Register;

