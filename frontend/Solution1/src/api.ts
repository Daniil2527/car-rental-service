import axios from "axios";

const api = axios.create({
    baseURL: "http://localhost:5123/api",
});

// Добавляем токен авторизации ко всем запросам
api.interceptors.request.use((config) => {
    const token = localStorage.getItem("token");

    if (token && config.headers) {
        // Удаляем лишние кавычки, если вдруг токен сохранён как JSON-строка
        const jwt = token.startsWith('"') ? JSON.parse(token) : token;
        config.headers.Authorization = `Bearer ${jwt}`;
    }

    return config;
});

// Обработка ошибки 401 (Unauthorized)
api.interceptors.response.use(
    (response) => response,
    (error) => {
        if (
            error.response &&
            error.response.status === 401 &&
            window.location.pathname !== "/login"
        ) {
            localStorage.removeItem("token");
            localStorage.removeItem("user");

            // Принудительный редирект на логин
            window.location.href = "/login";
        }

        return Promise.reject(error);
    }
);

export default api;