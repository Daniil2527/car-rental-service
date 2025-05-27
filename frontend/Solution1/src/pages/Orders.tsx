import { useEffect, useState } from 'react';
import { useAuth } from '../context/AuthContext';
import { api } from '../api';
import type { OrderDto } from '../types';
import toast from 'react-hot-toast';

const Orders = () => {
    const { token } = useAuth();
    const [orders, setOrders] = useState<OrderDto[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        if (!token) return; // не делать запрос без токена

        const fetchOrders = async () => {
            try {
                const response = await api.get<OrderDto[]>("/orders", {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                });
                setOrders(response.data);
            } catch (error) {
                toast.error("Ошибка при загрузке заказов");
            } finally {
                setLoading(false);
            }
        };

        fetchOrders();
    }, [token]);

    if (loading) return (
        <div className="flex justify-center mt-10">
            <div className="animate-spin rounded-full h-6 w-6 border-t-2 border-blue-600"></div>
        </div>
    );

    if (orders.length === 0) return <p className="text-center mt-10 text-gray-600">У вас пока нет заказов.</p>;

    return (
        <div className="max-w-5xl mx-auto mt-10 px-4">
            <h1 className="text-2xl font-bold mb-6 text-center">📦 Ваши заказы</h1>
            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 gap-6">
                {orders.map((order) => (
                    <div
                        key={order.id}
                        className="border rounded-lg p-4 shadow hover:shadow-lg transition"
                    >
                        <h2 className="text-lg font-semibold mb-2">
                            🚘 {order.carName}
                        </h2>
                        <p className="text-sm text-gray-600">
                            Тип: <span className="font-medium">{order.type === "Purchase" ? "Покупка" : "Аренда"}</span>
                        </p>
                        <p className="text-sm text-gray-600">
                            Дата: {new Date(order.orderDate).toLocaleDateString('ru-RU')}
                        </p>
                        <p className="text-xs text-gray-400 mt-2">ID заказа: {order.id}</p>
                    </div>
                ))}
            </div>
        </div>
    );
};

export default Orders;