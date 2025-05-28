import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Navbar from "./components/Navbar";
import Home from "./pages/Home";
import Cars from "./pages/Cars";
import Orders from "./pages/Orders";
import CreateOrder from "./pages/CreateOrder";
import Login from "./pages/Login";
import Register from "./pages/Register";
import NotFound from "./pages/NotFound";
import { AuthProvider } from "./context/AuthContext";
import PrivateRoute from "./components/PrivateRoute";
import AuthSync from "./components/AuthSync";

const App: React.FC = () => {
    return (
        <AuthProvider>
            <BrowserRouter>
                <AuthSync />
                <Navbar />
                <Routes>
                    <Route path="/" element={<Home />} />
                    <Route path="/cars" element={<Cars />} />
                    <Route path="/orders" element={
                        <PrivateRoute>
                            <Orders />
                        </PrivateRoute>
                    } />

                    <Route path="/create-order" element={
                        <PrivateRoute>
                            <CreateOrder />
                        </PrivateRoute>
                    } />
                    <Route path="/login" element={<Login />} />
                    <Route path="/register" element={<Register />} />
                    <Route path="*" element={<NotFound />} />
                </Routes>
            </BrowserRouter>
        </AuthProvider>
    );
};

export default App;