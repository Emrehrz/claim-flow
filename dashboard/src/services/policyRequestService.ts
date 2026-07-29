import api from './api'; // Axios instance veya fetch wrapper'ınız

export interface PolicyRequest {
  id: string;
  policyId: string;
  userId: string;
  requestType: number; // 1: Renewal, 2: Update
  status: number;      // 1: Pending, 2: Completed, 3: Rejected
  description?: string;
  dummyPrice?: number;
  adminNote?: string;
  createdAt: string;
}

export interface CompletePolicyRequestPayload {
  requestId: string;
  dummyPrice: number;
  adminNote: string;
  status: number; // 2: Completed, 3: Rejected
}

export const PolicyRequestAdminService = {
  // Bekleyen talepleri getir
  getPendingRequests: async (): Promise<PolicyRequest[]> => {
    const response = await api.get('/policyrequests/pending');
    return response.data;
  },

  // Talebi yanıtla / tamamla
  completeRequest: async (payload: CompletePolicyRequestPayload): Promise<PolicyRequest> => {
    const response = await api.put('/policyrequests/complete', payload);
    return response.data;
  }
};