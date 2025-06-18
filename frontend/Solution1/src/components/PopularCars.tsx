import React from "react";

const cars = [
    {
        name: "BMW 5 Series",
        image: "/images/bmw.jpg", 
        price: "от 6 500 ₽/день",
    },
    {
        name: "Mercedes-Benz E-Class",
        image: "/images/mercedes.jpg",
        price: "от 7 200 ₽/день",
    },
    {
        name: "Audi A6",
        image: "/images/audi.jpg",
        price: "от 6 900 ₽/день",
    },
    {
        name: "Toyota Camry",
        image: "/images/camry.jpg",
        price: "от 5 000 ₽/день",
    },
];

const PopularCars: React.FC = () => {
    return (
        <section style={{ padding: "40px 20px" }}>
            <h2 style={{ fontSize: "28px", fontWeight: 700, marginBottom: "24px", textAlign: "center", color: "#1f2937" }}>
                Популярные автомобили
            </h2>

            <div style={{
                display: "grid",
                gridTemplateColumns: "repeat(auto-fit, minmax(260px, 1fr))",
                gap: "24px",
                maxWidth: "1200px",
                margin: "0 auto",
            }}>
                {cars.map((car, index) => (
                    <div
                        key={index}
                        style={{
                            background: "#fff",
                            borderRadius: "12px",
                            boxShadow: "0 4px 12px rgba(0,0,0,0.1)",
                            overflow: "hidden",
                            transition: "transform 0.3s",
                        }}
                    >
                        <img src={car.image} alt={car.name} style={{ width: "100%", height: "180px", objectFit: "cover" }} />
                        <div style={{ padding: "16px" }}>
                            <h3 style={{ fontSize: "18px", fontWeight: 600, marginBottom: "8px" }}>{car.name}</h3>
                            <p style={{ fontSize: "14px", color: "#4b5563", marginBottom: "12px" }}>{car.price}</p>
                            <button
                                style={{
                                    backgroundColor: "#dc2626",
                                    color: "#fff",
                                    padding: "8px 16px",
                                    borderRadius: "8px",
                                    border: "none",
                                    cursor: "pointer",
                                }}
                            >
                                Подробнее
                            </button>
                        </div>
                    </div>
                ))}
            </div>
        </section>
    );
};

export default PopularCars;