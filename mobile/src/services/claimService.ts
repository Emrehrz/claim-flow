import axios from 'axios';

export const uploadClaimPhoto = async (claimId: string, fileUri: string, mimeType?: string) => {
  const formData = new FormData();

  const fileType = mimeType || 'image/jpeg';
  // Dosya uzantısını belirleme
  const extension = fileType.split('/')[1] || 'jpg';
  const fileName = `claim_${claimId}_${Date.now()}.${extension}`;

  formData.append('file', {
    uri: fileUri,
    type: fileType,
    name: fileName,
  } as any);

  const response = await axios.post(`/api/claims/${claimId}/photos`, formData, {
    headers: {
      'Content-Type': 'multipart/form-data',
    },
  });

  return response.data;
};