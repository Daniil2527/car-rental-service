import { useEffect, useState } from "react";
import { api } from "../api";
import toast from "react-hot-toast";

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

    const [search, setSearch] = useState("");
    const [minPrice, setMinPrice] = useState("");
    const [maxPrice, setMaxPrice] = useState("");

    useEffect(() => {
        api
            .get("/cars")
            .then((res) => setCars(res.data))
            .catch(() => {
                toast.error("Не удалось загрузить список машин");
                setError("Не удалось загрузить список машин");
            })
            .finally(() => setLoading(false));
    }, []);

    const filteredCars = cars.filter((car) => {
        const matchesSearch =
            `${car.brand} ${car.model}`.toLowerCase().includes(search.toLowerCase());

        const matchesMin = minPrice ? car.price >= parseInt(minPrice) : true;
        const matchesMax = maxPrice ? car.price <= parseInt(maxPrice) : true;

        return matchesSearch && matchesMin && matchesMax;
    });

    return (
        <div className="max-w-6xl mx-auto mt-10 px-4">
            <h1 className="text-2xl font-bold mb-6 text-center">🚗 Доступные автомобили</h1>

            <div className="grid grid-cols-1 sm:grid-cols-3 gap-4 mb-6">
                <input
                    type="text"
                    placeholder="Поиск по модели или бренду..."
                    value={search}
                    onChange={(e) => setSearch(e.target.value)}
                    className="border rounded p-2"
                />
                <input
                    type="number"
                    placeholder="Мин. цена"
                    value={minPrice}
                    onChange={(e) => setMinPrice(e.target.value)}
                    className="border rounded p-2"
                />
                <input
                    type="number"
                    placeholder="Макс. цена"
                    value={maxPrice}
                    onChange={(e) => setMaxPrice(e.target.value)}
                    className="border rounded p-2"
                />
            </div>

            {loading ? (
                <div className="flex justify-center mt-10">
                    <div className="animate-spin rounded-full h-6 w-6 border-t-2 border-blue-600"></div>
                </div>
            ) : error ? (
                <p className="text-red-500">{error}</p>
            ) : filteredCars.length === 0 ? (
                <p className="text-center text-gray-600">Автомобили не найдены.</p>
            ) : (
                <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
                    {filteredCars.map((car) => (
                        <div key={car.id} className="border rounded p-4 shadow hover:shadow-lg transition">
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