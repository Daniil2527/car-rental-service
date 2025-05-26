import { useEffect, useState } from "react";
import axios from "axios";

type Car = {
    id: string;
    brand: string;
    model: string;
    year: number;
    price: number;
    isForRent: boolean;
};

const Cars = () => {
    const [cars, setCars] = useState<Car[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState("");

    useEffect(() => {
        axios
            .get("http://localhost:5123/api/cars")
            .then((res) => setCars(res.data))
            .catch(() => setError("Не удалось загрузить список машин"))
            .finally(() => setLoading(false));
    }, []);

    return (
        <div className="max-w-5xl mx-auto mt-10 px-4">
            <h1 className="text-2xl font-bold mb-6 text-center">🚗 Доступные автомобили</h1>

            {loading ? (
                <p>Загрузка машин...</p>
            ) : error ? (
                <p className="text-red-500">{error}</p>
            ) : cars.length === 0 ? (
                <p>Автомобили не найдены.</p>
            ) : (
                <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
                    {cars.map((car) => (
                        <div key={car.id} className="border rounded p-4 shadow">
                            <h2 className="text-xl font-semibold mb-1">
                                {car.brand} {car.model}
                            </h2>
                            <p className="text-sm text-gray-600">
                                Год: {car.year} — Цена: {car.price} ₽
                            </p>
                            <p className="text-sm text-gray-500">
                                Доступна для {car.isForRent ? "аренды и покупки" : "покупки"}
                            </p>
                        </div>
                    ))}
                </div>
            )}
        </div>
    );
};

export default Cars;