import axios from "axios";
import { toast } from "react-hot-toast";

// Переменные для доступа к logout() вне React-контекста
let logoutCallback: (() => void) | null = null;
let navigateCallback: ((path: string) => void) | null = null;

export const setAuthHandlers = (
    logoutFn: () => void,
    navigateFn: (path: string) => void
) => {
    logoutCallback = logoutFn;
    navigateCallback = navigateFn;
};

// Основной экземпляр axios
export const api = axios.create({
    baseURL: "http://localhost:5123/api",
});

// Интерцептор ошибок
api.interceptors.response.use(
    res => res,
    err => {
        if (err.response?.status === 401 && logoutCallback && navigateCallback) {
            logoutCallback();
            toast.error("Сессия истекла. Войдите снова.");
            navigateCallback("/login");
        }
        return Promise.reject(err);
    }
);