import { useState } from 'react';
import axios from 'axios';

const Login = () => {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');

    const handleLogin = async (e: React.FormEvent) => {
        e.preventDefault();
        setError('');

        try {
            const response = await axios.post('http://localhost:5123/api/users/login', {
                email,
                password,
            });

            const token = response.data.token;
            localStorage.setItem('token', token);
            alert('Успешный вход!');
        } catch (err) {
            setError('Неверный email или пароль');
        }
    };

    return (
        <div className="flex flex-col items-center mt-10">
            <h2 className="text-2xl mb-4">🔐 Вход</h2>
            <form onSubmit={handleLogin} className="flex flex-col gap-4 w-80">
                <input
                    type="email"
                    placeholder="Email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    className="p-2 border rounded"
                    required
                />
                <input
                    type="password"
                    placeholder="Пароль"
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    className="p-2 border rounded"
                    required
                />
                <button type="submit" className="bg-blue-600 text-white p-2 rounded">
                    Войти
                </button>
                {error && <p className="text-red-500 text-center">{error}</p>}
            </form>
        </div>
    );
};

export default Login;