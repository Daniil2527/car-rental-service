import { useEffect, useState } from 'react';
import axios from 'axios';
import type  { OrderDto } from '../types'; // или путь к твоему типу
import { useAuth } from '../context/AuthContext';

const Orders = () => {
    const { token } = useAuth();
    const [orders, setOrders] = useState<OrderDto[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchOrders = async () => {
            try {
                const response = await axios.get<OrderDto[]>('http://localhost:5123/api/orders', {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                });
                setOrders(response.data);
            } catch (error) {
                console.error('Ошибка при получении заказов', error);
            } finally {
                setLoading(false);
            }
        };

        fetchOrders();
    }, [token]);

    if (loading) return <p>Загрузка...</p>;
    if (orders.length === 0) return <p>У вас пока нет заказов.</p>;

    return (
        <ul>
            {orders.map((order) => (
                <li key={order.id}>
                    ID: {order.id}, Тип: {order.type}, Авто: {order.carName}, Дата: {new Date(order.orderDate).toLocaleDateString()}
                </li>
            ))}
        </ul>
    );
};

export default Orders;