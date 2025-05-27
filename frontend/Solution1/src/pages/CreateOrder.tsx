import { useEffect, useState } from "react";
import axios from "axios";
import { useAuth } from "../context/AuthContext";
import { useNavigate } from "react-router-dom";
import toast from "react-hot-toast";
import {api} from "../api.ts";

type Car = {
    id: string;
    brand: string;
    model: string;
};

type OrderDto = {
    carId: string;
    buyerId: string;
    type: string;
};

const CreateOrder = () => {
    const { user, token } = useAuth();
    const navigate = useNavigate();

    const [cars, setCars] = useState<Car[]>([]);
    const [form, setForm] = useState<OrderDto>({
        carId: "",
        buyerId: user?.id || "",
        type: "Purchase",
    });

    const [loading, setLoading] = useState(true);

    useEffect(() => {
        axios
            .get("http://localhost:5123/api/cars")
            .then((res) => setCars(res.data))
            .catch(() => toast.error("Не удалось загрузить машины"))
            .finally(() => setLoading(false));
    }, []);

    const handleChange = (e: React.ChangeEvent<HTMLSelectElement | HTMLInputElement>) => {
        setForm({ ...form, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const payload = {
                CarId: form.carId,
                BuyerId: form.buyerId,
                Type: form.type, // ← важен правильный регистр!
            };

            await api.post("/orders", payload, {
                headers: { Authorization: `Bearer ${token}` },
            });

            toast.success("Заказ успешно создан!");
            setTimeout(() => navigate("/orders"), 1000);
        } catch {
            toast.error("Не удалось создать заказ");
        }
    };

    return (
        <div className="max-w-lg mx-auto mt-10">
            <h1 className="text-2xl font-bold mb-6 text-center">Создание заказа</h1>

            {loading ? (
                <div className="flex justify-center">
                    <div className="animate-spin rounded-full h-6 w-6 border-t-2 border-blue-600"></div>
                </div>
            ) : (
                <form onSubmit={handleSubmit} className="space-y-4">
                    <select
                        name="carId"
                        value={form.carId}
                        onChange={handleChange}
                        required
                        className="w-full border rounded p-2"
                    >
                        <option value="">Выберите машину</option>
                        {cars.map((car) => (
                            <option key={car.id} value={car.id}>
                                {car.brand} {car.model}
                            </option>
                        ))}
                    </select>

                    <select
                        name="type"
                        value={form.type}
                        onChange={handleChange}
                        className="w-full border rounded p-2"
                    >
                        <option value="Purchase">Покупка</option>
                        <option value="Rent">Аренда</option>
                    </select>

                    <button
                        type="submit"
                        className="w-full bg-green-600 text-white py-2 rounded hover:bg-green-700"
                    >
                        Подтвердить заказ
                    </button>
                </form>
            )}
        </div>
    );
};

export default CreateOrder;