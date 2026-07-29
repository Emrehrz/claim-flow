import React, { useEffect, useState } from 'react';
import type { PolicyRequest } from '../services/policyRequestService';
import { PolicyRequestAdminService } from '../services/policyRequestService';
import { CompleteRequestModal } from '../components/CompleteRequestModal';

export const HomePage: React.FC = () => {
  const [requests, setRequests] = useState<PolicyRequest[]>([]);
  const [selectedRequest, setSelectedRequest] = useState<PolicyRequest | null>(null);
  const [loading, setLoading] = useState(true);

  const fetchRequests = async () => {
    setLoading(true);
    try {
      const data = await PolicyRequestAdminService.getPendingRequests();
      setRequests(data);
    } catch (err) {
      console.error('Kuyruk yüklenirken hata:', err);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchRequests();
  }, []);

  const handleComplete = async (payload: any) => {
    await PolicyRequestAdminService.completeRequest(payload);
    // Kuyruğu güncelle (işlenen talep listeden düşer)
    fetchRequests();
  };

  if (loading) return <div>Talepler yükleniyor...</div>;

  return (
    <div className="queue-container">
      <h2>Bekleyen Poliçe Talepleri Kuyruğu</h2>
      {requests.length === 0 ? (
        <p>Bekleyen talep bulunmamaktadır.</p>
      ) : (
        <table className="queue-table">
          <thead>
            <tr>
              <th>Tarih</th>
              <th>Talep Tipi</th>
              <th>Açıklama</th>
              <th>İşlem</th>
            </tr>
          </thead>
          <tbody>
            {requests.map((req) => (
              <tr key={req.id}>
                <td>{new Date(req.createdAt).toLocaleString('tr-TR')}</td>
                <td>{req.requestType === 1 ? 'Yenileme' : 'Teminat Güncelleme'}</td>
                <td>{req.description || '-'}</td>
                <td>
                  <button onClick={() => setSelectedRequest(req)}>
                    Talebi Yanıtla
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      )}

      {selectedRequest && (
        <CompleteRequestModal
          request={selectedRequest}
          onClose={() => setSelectedRequest(null)}
          onSubmit={handleComplete}
        />
      )}
    </div>
  );
};