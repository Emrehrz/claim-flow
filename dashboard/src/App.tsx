import { Routes, Route, Navigate } from 'react-router-dom';
import { AdminDashboard } from './pages/AdminDashboard';
import Login from './pages/Login';
import './App.css';

export default function App() {
  // localStorage'da 'token' adında bir kayıt varsa true döner
  const isAuthenticated = !!localStorage.getItem('token');

  return (
    <Routes>
      <Route path="/login" element={<Login />} />
      <Route
        path="/"
        element={isAuthenticated ? <AdminDashboard /> : <Navigate to="/login" replace />}
      />
    </Routes>
  );
}