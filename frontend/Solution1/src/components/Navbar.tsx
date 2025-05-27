import { Link, useNavigate } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import toast from 'react-hot-toast';
const Navbar = () => {
    const { user, logout } = useAuth();
    const navigate = useNavigate();

    const handleLogout = () => {
        logout();
        toast("Вы вышли из системы");
        navigate("/login");
    };

    return (
        <nav className="bg-white shadow-md px-6 py-4 flex flex-col sm:flex-row justify-between items-center gap-2 sm:gap-0">
            <div className="text-xl font-bold text-blue-600">
                <Link to="/">Car Rental & Sales</Link>
            </div>

            <div className="flex flex-wrap gap-4 items-center text-sm">
                <Link to="/cars" className="hover:underline">
                    Машины
                </Link>

                {user && (
                    <>
                        <Link to="/orders" className="hover:underline">
                            Мои заказы
                        </Link>
                        <Link to="/create-order" className="hover:underline">
                            Создать заказ
                        </Link>
                        <span className="text-gray-600 hidden sm:inline">|</span>
                        <button
                            onClick={handleLogout}
                            className="text-red-600 hover:underline"
                        >
                            Выйти
                        </button>
                    </>
                )}

                {!user && (
                    <>
                        <Link to="/login" className="hover:underline">
                            Войти
                        </Link>
                        <Link to="/register" className="hover:underline">
                            Регистрация
                        </Link>
                    </>
                )}
            </div>
        </nav>
    );
};

export default Navbar;