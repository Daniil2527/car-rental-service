import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from './pages/Home';
import Login from './pages/Login';
import NotFound from './pages/NotFound';
import PrivateRoute from './components/PrivateRoute';
import Orders from './pages/Orders';
import Register from "./pages/Register";
import CreateOrder from "./pages/CreateOrder";
import Cars from "./pages/Cars";

function App() {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/login" element={<Login />} />
                <Route path="/register" element={<Register />} />
                <Route
                    path="/orders"
                    element={
                        <PrivateRoute>
                            <Orders />
                        </PrivateRoute>
                    }
                />
                <Route
                    path="/create-order"
                    element={
                        <PrivateRoute>
                            <CreateOrder />
                        </PrivateRoute>
                    }
                />
                <Route path="/cars" element={<Cars />} />
                <Route path="*" element={<NotFound />} />
            </Routes>
        </Router>
    );
}

export default App;