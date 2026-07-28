import api from './api'; // Hazır axios instance'ın

export interface ClaimPhoto {
  id: string;
  fileUrl: string;
  uploadedAt: string;
}

export interface ClaimDetail {
  id: string;
  title: string;
  description: string;
  status: string;
  aiSummary?: string;
  photos: ClaimPhoto[];
  createdAt: string;
}

export const getClaimById = async (claimId: string): Promise<ClaimDetail> => {
  const response = await api.get(`/api/claims/${claimId}`);
  return response.data;
};