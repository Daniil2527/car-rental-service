import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../api";

const CreateOrder: React.FC = () => {
    const [cars, setCars] = useState([]);
    const [carId, setCarId] = useState("");
    const [type, setType] = useState("rent");
    const navigate = useNavigate();

    useEffect(() => {
        api.get("/cars")
            .then((res) => setCars(res.data))
            .catch((err) => console.error("Ошибка загрузки машин", err));
    }, []);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            const user = JSON.parse(localStorage.getItem("user") || "{}");
            const payload = {
                carId,
                buyerId: user.id,
                type,
            };

            await api.post("/orders", payload);
            alert("Заказ создан!");
            navigate("/orders");
        } catch (err) {
            console.error("Ошибка создания заказа", err);
            alert("Ошибка при создании заказа");
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>Создать заказ</h2>
            <select value={carId} onChange={(e) => setCarId(e.target.value)} required>
                <option value="">Выберите машину</option>
                {cars.map((car: any) => (
                    <option key={car.id} value={car.id}>
                        {car.brand} {car.model}
                    </option>
                ))}
            </select>
            <select value={type} onChange={(e) => setType(e.target.value)} required>
                <option value="rent">Аренда</option>
                <option value="buy">Покупка</option>
            </select>
            <button type="submit">Оформить</button>
        </form>
    );
};

export default CreateOrder;