import React from "react";
import { Link } from "react-router-dom";
import PopularCars from "../components/PopularCars";
import WhyChooseUs from "../components/WhyChooseUs";

const Home: React.FC = () => {
    return (
        <div className="flex items-center justify-center min-h-screen">
            <div className="text-center px-6">
                {/* Выразительное приветствие */}
                <p className="text-2xl font-bold text-white drop-shadow-sm mb-8">
                    Добро пожаловать в <span className="text-white underline underline-offset-4">Car Rental & Sales</span>
                </p>

                <PopularCars />
                <WhyChooseUs />

                {/* Подпись */}
                <p className="text-white text-lg mt-8">
                    У нас вы можете арендовать или купить авто с комфортом
                </p>

                {/* Кнопка */}
                <Link
                    to="/cars"
                    className="inline-block mt-4 bg-white text-red-600 font-semibold px-6 py-3 rounded-full shadow hover:bg-red-100 transition duration-300"
                >
                    Посмотреть автомобили
                </Link>
            </div>
        </div>
    );
};

export default Home;
