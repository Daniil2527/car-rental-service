import React, { useEffect, useState } from "react";
import api from "../api";

const Orders: React.FC = () => {
    const [orders, setOrders] = useState([]);

    useEffect(() => {
        api.get("/orders")
            .then((res) => setOrders(res.data))
            .catch((err) => console.error("Ошибка загрузки заказов", err));
    }, []);

    return (
        <div>
            <h2>Ваши заказы</h2>
            {orders.map((order: any) => (
                <div key={order.id}>
                    <p>Машина: {order.car.brand} {order.car.model}</p>
                    <p>Тип: {order.type}</p>
                    <p>Статус: {order.status}</p>
                </div>
            ))}
        </div>
    );
};

export default Orders;