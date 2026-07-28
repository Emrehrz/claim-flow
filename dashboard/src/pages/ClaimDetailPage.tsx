import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { getClaimById } from '../services/claimService';
import type { ClaimDetail } from '../services/claimService';

export const ClaimDetailPage: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const [claim, setClaim] = useState<ClaimDetail | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    if (!id) return;

    getClaimById(id)
      .then((data) => setClaim(data))
      .catch((err) => setError(err.response?.data?.message || 'Detaylar yüklenemedi.'))
      .finally(() => setLoading(false));
  }, [id]);

  if (loading) return <div className="p-6">Yükleniyor...</div>;
  if (error) return <div className="p-6 text-red-500">{error}</div>;
  if (!claim) return <div className="p-6">Hasar dosyası bulunamadı.</div>;

  return (
    <div className="p-6 space-y-6 max-w-6xl mx-auto">
      {/* Başlık ve Durum */}
      <div className="flex justify-between items-center border-b pb-4">
        <div>
          <h1 className="text-2xl font-bold text-gray-800">{claim.title}</h1>
          <p className="text-sm text-gray-500">Dosya No: {claim.id}</p>
        </div>
        <span className="px-3 py-1 bg-blue-100 text-blue-800 rounded-full text-sm font-medium">
          {claim.status}
        </span>
      </div>

      {/* Yapay Zeka (AI) Hasar Özet Kartı */}
      <div className="bg-gradient-to-r from-purple-50 to-indigo-50 border border-purple-200 rounded-lg p-5 shadow-sm">
        <div className="flex items-center space-x-2 mb-2">
          <span className="text-purple-600 font-bold text-lg">🤖 AI Hasar Değerlendirme Özeti</span>
        </div>
        {claim.aiSummary ? (
          <p className="text-gray-700 leading-relaxed font-medium">
            {claim.aiSummary}
          </p>
        ) : (
          <p className="text-gray-400 italic">
            Bu dosya için henüz AI özeti üretilmedi veya analiz devam ediyor.
          </p>
        )}
      </div>

      {/* Açıklama */}
      <div className="bg-white p-4 border rounded-lg shadow-sm">
        <h3 className="text-lg font-semibold text-gray-700 mb-2">Müşteri Beyanı</h3>
        <p className="text-gray-600">{claim.description}</p>
      </div>

      {/* Fotoğraf Galerisi */}
      <div className="bg-white p-4 border rounded-lg shadow-sm">
        <h3 className="text-lg font-semibold text-gray-700 mb-4">
          Görsel Kanıtlar ({claim.photos?.length || 0})
        </h3>

        {claim.photos && claim.photos.length > 0 ? (
          <div className="grid grid-cols-2 md:grid-cols-4 gap-4">
            {claim.photos.map((photo) => (
              <div key={photo.id} className="relative group overflow-hidden rounded-lg border bg-gray-100 aspect-square">
                <img
                  src={photo.fileUrl}
                  alt="Hasar Görseli"
                  className="w-full h-full object-cover transition-transform duration-300 group-hover:scale-105"
                />
                <a
                  href={photo.fileUrl}
                  target="_blank"
                  rel="noreferrer"
                  className="absolute inset-0 bg-black bg-opacity-40 opacity-0 group-hover:opacity-100 flex items-center justify-center text-white text-sm font-medium transition-opacity"
                >
                  Tam Boyut Gör
                </a>
              </div>
            ))}
          </div>
        ) : (
          <p className="text-gray-400 italic">Bu dosyaya henüz fotoğraf eklenmemiş.</p>
        )}
      </div>
    </div>
  );
};