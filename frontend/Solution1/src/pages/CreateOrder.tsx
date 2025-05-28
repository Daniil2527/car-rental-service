import React, { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import api from "../api";

interface Car {
    Id: string;
    Brand: string;
    Model: string;
}

const CreateOrder: React.FC = () => {
    const [cars, setCars] = useState<Car[]>([]);
    const [carId, setCarId] = useState("");
    const [type, setType] = useState("rent");
    const navigate = useNavigate();

    useEffect(() => {
        const fetchCars = async () => {
            try {
                const response = await api.get("/cars");
                console.log("🚗 Загруженные машины:", response.data);
                setCars(response.data);
            } catch (error) {
                console.error("Ошибка загрузки машин:", error);
            }
        };
        fetchCars();
    }, []);

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        try {
            const userRaw = localStorage.getItem("user");
            if (!userRaw) {
                alert("Пользователь не найден. Пожалуйста, войдите заново.");
                return;
            }

            const user = JSON.parse(userRaw);
            const userId = user.id || user.Id;

            if (!userId) {
                alert("Ошибка: ID пользователя не найден.");
                return;
            }

            const payload = {
                BuyerId: userId,
                CarId: carId,
                OrderDate: new Date().toISOString(),
                Type: type === "rent" ? "Rent" : "Purchase",
            };

            console.log("📦 Отправляемый заказ:", payload);

            await api.post("/orders", payload);
            alert("Заказ успешно создан!");
            navigate("/orders");
        } catch (error) {
            console.error("❌ Ошибка создания заказа:", error);
            alert("Не удалось создать заказ");
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <h2>Создать заказ</h2>

            <select value={carId} onChange={(e) => setCarId(e.target.value)} required>
                <option value="">Выберите машину</option>
                {cars.map((car) => (
                    <option key={car.Id} value={car.Id}>
                        {car.Brand} {car.Model}
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