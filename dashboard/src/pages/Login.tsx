import { useState } from 'react';
import { useAuth } from '../contexts/AuthContext';
import api from '../services/api';
import { useNavigate } from 'react-router-dom';
import '../Login.css'

export default function Login() {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const { setToken } = useAuth();
  const navigate = useNavigate();

  const handleLogin = async (e: React.FormEvent) => {
    e.preventDefault();

    // API çağrısı veya sunum için basit doğrulama
    if (email && password) {
      // 1. Sisteme giriş yapıldığını belirten dummy token'ı kaydet
      localStorage.setItem('token', 'claimflow-admin-token');

      // 2. Ana sayfaya (Dashboard) yönlendir
      navigate('/');
    }
  };

  return (
    <div className="login-container">
      {/* Arka plan efekti */}
      <div className="login-background-glow" />

      <div className="login-card">
        {/* Header / Logo Alanı */}
        <div className="login-header">
          <div className="login-logo">
            <span className="login-logo-text">CF</span>
          </div>
          <h1 className="login-title">ClaimFlow&apos;a Hoş Geldiniz</h1>
          <p className="login-subtitle">Hesabınıza erişmek için bilgilerinizi girin</p>
        </div>

        {/* Form */}
        <form onSubmit={handleLogin} className="login-form">
          <div className="form-group">
            <label className="form-label">E-posta</label>
            <input
              type="email"
              value={email}
              onChange={(e) => setEmail(e.target.value)}
              placeholder="ornek@claimflow.com"
              className="form-input"
              required
            />
          </div>

          <div className="form-group">
            <label className="form-label">Şifre</label>
            <input
              type="password"
              value={password}
              onChange={(e) => setPassword(e.target.value)}
              placeholder="••••••••"
              className="form-input"
              required
            />
          </div>

          <button type="submit" className="submit-btn">
            Giriş Yap
          </button>
        </form>
      </div>
    </div>
  );
}