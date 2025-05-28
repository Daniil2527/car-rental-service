import { useEffect, useState } from "react";
import api from "../api";

interface Order {
    Id: string;
    BuyerId: string;
    CarId: string;
    OrderDate: string;
    BuyerName: string;
    CarName: string;
    Type: string;
}

const Orders = () => {
    const [orders, setOrders] = useState<Order[]>([]);

    useEffect(() => {
        const fetchOrders = async () => {
            try {
                const response = await api.get("/orders");
                console.log("Загруженные заказы:", response.data);
                setOrders(response.data);
            } catch (error) {
                console.error("Ошибка при загрузке заказов:", error);
            }
        };

        fetchOrders();
    }, []);

    return (
        <div>
            <h2>Ваши заказы</h2>
            {orders.map((order) => (
                <div key={order.Id}>
                    <p><strong>Машина:</strong> {order.CarName}</p>
                    <p><strong>Покупатель:</strong> {order.BuyerName}</p>
                    <p><strong>Тип:</strong> {order.Type}</p>
                    <p><strong>Дата заказа:</strong> {new Date(order.OrderDate).toLocaleString()}</p>
                    <hr />
                </div>
            ))}
        </div>
    );
};

export default Orders;