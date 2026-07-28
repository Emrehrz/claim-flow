import { Routes, Route } from 'react-router-dom'
import { HomePage } from './pages/HomePage'
import Login from './pages/Login'
import { ProtectedRoute } from './components/ProtectedRoute'
import { ClaimDetailPage } from './pages/ClaimDetailPage'
import './App.css'

function App() {
  return (
    <Routes>
      <Route path="/login" element={<Login />} />
      <Route element={<ProtectedRoute />}>
        <Route path="/" element={<HomePage />} />
        <Route path="/claim/:id" element={<ClaimDetailPage />} />
      </Route>
    </Routes>
  )
}

export default App
