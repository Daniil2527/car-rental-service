import React, { useEffect, useState } from "react";
import api from "../api";

interface Car {
    Id: string;
    Brand: string;
    Model: string;
    Price: number;
    Color: string;
}

const Cars: React.FC = () => {
    const [cars, setCars] = useState<Car[]>([]);

    useEffect(() => {
        const fetchCars = async () => {
            try {
                const response = await api.get("/cars");
                console.log("🚗 Загруженные машины:", response.data);
                setCars(response.data);
            } catch (error) {
                console.error("❌ Ошибка при загрузке машин:", error);
            }
        };
        fetchCars();
    }, []);

    return (
        <div>
            <h2>Список машин</h2>
            {cars.length === 0 ? (
                <p>Нет доступных машин</p>
            ) : (
                cars.map((car) => (
                    <div key={car.Id}>
                        <p>{car.Brand} {car.Model}</p>
                        <p>Цена: {car.Price} ₽</p>
                        <p>Цвет: {car.Color}</p>
                    </div>
                ))
            )}
        </div>
    );
};

export default Cars;