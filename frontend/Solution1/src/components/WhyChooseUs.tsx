import React from "react";

const features = [
    {
        title: "Широкий выбор авто",
        description: "У нас вы найдете автомобили на любой вкус: от эконом до бизнес-класса.",
        emoji: "🚗",
    },
    {
        title: "Простое бронирование",
        description: "Интуитивный интерфейс позволяет оформить аренду за пару кликов.",
        emoji: "🖱️",
    },
    {
        title: "Надёжность и поддержка",
        description: "Каждый автомобиль проходит проверку, а мы всегда на связи.",
        emoji: "🛠️",
    },
    {
        title: "Выгодные цены",
        description: "Прозрачная система цен без скрытых платежей.",
        emoji: "💰",
    },
];

const WhyChooseUs: React.FC = () => {
    return (
        <section style={{ padding: "60px 20px", backgroundColor: "#fff" }}>
            <h2 style={{ fontSize: "28px", fontWeight: 700, textAlign: "center", marginBottom: "40px", color: "#1f2937" }}>
                Почему нас выбирают
            </h2>

            <div style={{
                display: "grid",
                gridTemplateColumns: "repeat(auto-fit, minmax(260px, 1fr))",
                gap: "24px",
                maxWidth: "1200px",
                margin: "0 auto",
            }}>
                {features.map((item, idx) => (
                    <div
                        key={idx}
                        style={{
                            backgroundColor: "#f9fafb",
                            borderRadius: "12px",
                            padding: "24px",
                            boxShadow: "0 4px 10px rgba(0,0,0,0.05)",
                            textAlign: "center",
                        }}
                    >
                        <div style={{ fontSize: "36px", marginBottom: "16px" }}>{item.emoji}</div>
                        <h3 style={{ fontSize: "18px", fontWeight: 600, marginBottom: "8px", color: "#111827" }}>{item.title}</h3>
                        <p style={{ fontSize: "14px", color: "#4b5563" }}>{item.description}</p>
                    </div>
                ))}
            </div>
        </section>
    );
};

export default WhyChooseUs;