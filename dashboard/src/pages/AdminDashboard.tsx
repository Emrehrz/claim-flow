import React, { useState } from 'react';
import { HomePage } from './HomePage'; // Kuyruk ekranını temsil eden HomePage'i çağırıyoruz
import './AdminDashboard.css';

// --- DUMMY BİLEŞENLER ---

const DashboardOverview: React.FC = () => (
  <div className="dashboard-overview">
    <div className="stats-grid">
      <div className="stat-card">
        <h4>Toplam Müşteri</h4>
        <div className="value">1,248</div>
        <div className="trend positive">+12% (Bu Ay)</div>
      </div>
      <div className="stat-card">
        <h4>Aktif Poliçeler</h4>
        <div className="value">856</div>
        <div className="trend positive">+5% (Bu Ay)</div>
      </div>
      <div className="stat-card">
        <h4>Açık Hasar Dosyaları (Claims)</h4>
        <div className="value warning">34</div>
        <div className="trend negative">-2 (Geçen Haftaya Göre)</div>
      </div>
      <div className="stat-card">
        <h4>Bekleyen Poliçe Talepleri</h4>
        <div className="value primary">12</div>
        <div className="trend">İşlem Bekliyor</div>
      </div>
    </div>

    <div className="recent-activity">
      <h3>Son Aktiviteler</h3>
      <table className="queue-table">
        <thead>
          <tr>
            <th>Tarih</th>
            <th>İşlem</th>
            <th>Müşteri</th>
            <th>Durum</th>
          </tr>
        </thead>
        <tbody>
          <tr><td>Bugün 10:45</td><td>Yeni Hasar İhbarı (Kaza)</td><td>Ahmet Yılmaz</td><td><span className="badge warning">İnceleniyor</span></td></tr>
          <tr><td>Bugün 09:30</td><td>Poliçe Yenileme Ödemesi</td><td>Ayşe Demir</td><td><span className="badge success">Tamamlandı</span></td></tr>
          <tr><td>Dün 16:15</td><td>Teminat Güncelleme Talebi</td><td>Mehmet Kaya</td><td><span className="badge primary">Beklemede</span></td></tr>
        </tbody>
      </table>
    </div>
  </div>
);

const DummyClaimsList: React.FC = () => (
  <div className="dummy-page">
    <h2>Hasar Dosyaları (Claims)</h2>
    <p>Bu modül Sprint 7'de geliştirilecektir. Mevcut açık hasar dosyaları burada listelenecek.</p>
  </div>
);

const DummyCustomersList: React.FC = () => (
  <div className="dummy-page">
    <h2>Müşteri Yönetimi</h2>
    <p>Kayıtlı sigortalıların listesi, poliçe geçmişleri ve risk skorları burada yer alacaktır.</p>
  </div>
);

// --- ANA LAYOUT BİLEŞENİ ---

export const AdminDashboard: React.FC = () => {
  const [activeTab, setActiveTab] = useState<'overview' | 'requests' | 'claims' | 'customers'>('overview');

  const renderContent = () => {
    switch (activeTab) {
      case 'overview': return <DashboardOverview />;
      case 'requests': return <HomePage />; // Burada AdminPolicyRequestsQueue yerine HomePage'i render ediyoruz
      case 'claims': return <DummyClaimsList />;
      case 'customers': return <DummyCustomersList />;
      default: return <DashboardOverview />;
    }
  };

  return (
    <div className="admin-layout">
      {/* Sidebar */}
      <aside className="sidebar">
        <div className="sidebar-header">
          <h2>ClaimFlow Admin</h2>
        </div>
        <nav className="sidebar-nav">
          <button className={activeTab === 'overview' ? 'active' : ''} onClick={() => setActiveTab('overview')}>
            📊 Genel Bakış
          </button>
          <button className={activeTab === 'requests' ? 'active' : ''} onClick={() => setActiveTab('requests')}>
            📝 Poliçe Talepleri
          </button>
          <button className={activeTab === 'claims' ? 'active' : ''} onClick={() => setActiveTab('claims')}>
            🚗 Hasar Dosyaları
          </button>
          <button className={activeTab === 'customers' ? 'active' : ''} onClick={() => setActiveTab('customers')}>
            👥 Müşteriler
          </button>
        </nav>
      </aside>

      {/* Main Content Area */}
      <main className="main-content">
        <header className="top-header">
          <div className="header-title">
            {activeTab === 'overview' && 'Genel Bakış'}
            {activeTab === 'requests' && 'Poliçe Talepleri Yönetimi'}
            {activeTab === 'claims' && 'Hasar Yönetimi'}
            {activeTab === 'customers' && 'Müşteri Yönetimi'}
          </div>
          <div className="user-profile">
            <span>Admin Yetkilisi</span>
            <div className="avatar">A</div>
          </div>
        </header>

        <div className="content-wrapper">
          {renderContent()}
        </div>
      </main>
    </div>
  );
};