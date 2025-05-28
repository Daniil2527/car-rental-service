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
        <form onSubmit={handleSubmit}>
            <h2>Регистрация</h2>
            <input
                name="firstName"
                placeholder="Имя"
                value={form.firstName}
                onChange={handleChange}
                required
            />
            <input
                name="lastName"
                placeholder="Фамилия"
                value={form.lastName}
                onChange={handleChange}
                required
            />
            <input
                name="email"
                type="email"
                placeholder="Email"
                value={form.email}
                onChange={handleChange}
                required
            />
            <input
                name="password"
                type="password"
                placeholder="Пароль"
                value={form.password}
                onChange={handleChange}
                required
            />
            <input
                name="phoneNumber"
                placeholder="Телефон"
                value={form.phoneNumber}
                onChange={handleChange}
                required
            />
            <button type="submit">Зарегистрироваться</button>
        </form>
    );
};

export default Register;
