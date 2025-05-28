import React, { useEffect, useState } from "react";
import api from "../api";

interface Car {
    id: string;
    brand: string;
    model: string;
    price: number;
}

const Cars: React.FC = () => {
    const [cars, setCars] = useState<Car[]>([]);

    useEffect(() => {
        const fetchCars = async () => {
            try {
                const response = await api.get("/cars");
                setCars(response.data);
            } catch (err) {
                console.error("Ошибка загрузки машин", err);
            }
        };

        fetchCars();
    }, []);

    return (
        <div>
            <h2>Список машин</h2>
            {cars.map((car) => (
                <div key={car.id}>
                    <h3>
                        {car.brand} {car.model}
                    </h3>
                    <p>Цена: {car.price}₽</p>
                </div>
            ))}
        </div>
    );
};

export default Cars;