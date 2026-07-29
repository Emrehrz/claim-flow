import React, { useState } from 'react';
import type { PolicyRequest, CompletePolicyRequestPayload } from '../services/policyRequestService';
import '../pages/AdminPolicyRequests.css';

interface ModalProps {
  request: PolicyRequest;
  onClose: () => void;
  onSubmit: (payload: CompletePolicyRequestPayload) => Promise<void>;
}

export const CompleteRequestModal: React.FC<ModalProps> = ({ request, onClose, onSubmit }) => {
  const [dummyPrice, setDummyPrice] = useState<number | ''>('');
  const [adminNote, setAdminNote] = useState('');
  const [loading, setLoading] = useState(false);

  const handleSubmit = async (status: number) => {
    if (status === 2 && (!dummyPrice || Number(dummyPrice) <= 0)) {
      alert('Lütfen geçerli bir teklif fiyatı giriniz.');
      return;
    }

    setLoading(true);
    try {
      await onSubmit({
        requestId: request.id,
        dummyPrice: Number(dummyPrice),
        adminNote,
        status
      });
      onClose();
    } catch (error) {
      console.error('İşlem başarısız:', error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="modal-backdrop">
      <div className="modal-content">
        <h3>Poliçe Talebi Yanıtla</h3>
        <p><strong>Talep Türü:</strong> {request.requestType === 1 ? 'Yenileme' : 'Teminat Güncelleme'}</p>
        <p><strong>Kullanıcı Notu:</strong> {request.description || 'Not belirtilmedi'}</p>

        <div className="form-group">
          <label>Teklif Fiyatı (Dummy Price - ₺):</label>
          <input
            type="number"
            value={dummyPrice}
            onChange={(e) => setDummyPrice(e.target.value === '' ? '' : Number(e.target.value))}
            placeholder="Örn: 4500"
          />
        </div>

        <div className="form-group">
          <label>Admin Açıklama / Not:</label>
          <textarea
            value={adminNote}
            onChange={(e) => setAdminNote(e.target.value)}
            placeholder="Müşteriye iletilecek açıklama..."
          />
        </div>

        <div className="modal-actions">
          <button onClick={onClose} disabled={loading}>İptal</button>
          <button onClick={() => handleSubmit(3)} disabled={loading} className="btn-reject">
            Reddet
          </button>
          <button onClick={() => handleSubmit(2)} disabled={loading} className="btn-approve">
            Tamamla ve Teklif Gönder
          </button>
        </div>
      </div>
    </div>
  );
};