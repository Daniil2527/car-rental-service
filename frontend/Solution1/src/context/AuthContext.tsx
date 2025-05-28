import React, { createContext, useContext, useState, useEffect } from "react";

export interface User {
    id: string;
    fullName: string;
    email: string;
    phoneNumber: string;
}

export interface AuthContextType {
    user: User | null;
    token: string | null;
    login: (user: User, token: string) => void;
    logout: () => void;
}

const AuthContext = createContext<AuthContextType>({} as AuthContextType);

export const AuthProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const [user, setUser] = useState<User | null>(null);
    const [token, setToken] = useState<string | null>(null);

    useEffect(() => {
        const storedUser = localStorage.getItem("user");
        const storedToken = localStorage.getItem("token");

        if (storedUser && storedUser !== "undefined") {
            try {
                setUser(JSON.parse(storedUser));
            } catch {
                localStorage.removeItem("user");
            }
        }

        if (storedToken && storedToken !== "undefined") {
            setToken(storedToken);
        }
    }, []);

    const login = (user: User, token: string) => {
        setUser(user);
        setToken(token);
        localStorage.setItem("user", JSON.stringify(user));
        localStorage.setItem("token", token);
    };

    const logout = () => {
        setUser(null);
        setToken(null);
        localStorage.removeItem("user");
        localStorage.removeItem("token");
    };

    return (
        <AuthContext.Provider value={{ user, token, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => useContext(AuthContext);