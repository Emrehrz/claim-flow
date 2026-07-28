import React, { useState } from 'react';
import {
  View,
  Text,
  StyleSheet,
  TouchableOpacity,
  Image,
  ScrollView,
  ActivityIndicator,
  Alert
} from 'react-native';
import * as ImagePicker from 'expo-image-picker';
import { uploadClaimPhoto } from '../services/claimService';

interface Photo {
  id: string;
  fileUrl: string;
  uploadedAt: string;
}

interface ClaimDetailScreenProps {
  claimId: string;
  photos: Photo[];
  onRefresh: () => void; // Fotoğraf yüklendikten sonra detay sayfasını yenilemek için
}

export const ClaimDetailScreen: React.FC<ClaimDetailScreenProps> = ({ claimId, photos, onRefresh }) => {
  const [uploading, setUploading] = useState(false);

  const handlePickAndUpload = async (useCamera: boolean) => {
    try {
      // 1. İzin İsteme
      const permissionResult = useCamera
        ? await ImagePicker.requestCameraPermissionsAsync()
        : await ImagePicker.requestMediaLibraryPermissionsAsync();

      if (!permissionResult.granted) {
        Alert.alert('İzin Gerekli', 'Fotoğraf yüklemek için kamera/galeri izni vermeniz gerekiyor.');
        return;
      }

      // 2. Fotoğraf Seçme / Çekme
      const result = useCamera
        ? await ImagePicker.launchCameraAsync({
          mediaTypes: ImagePicker.MediaTypeOptions.Images,
          quality: 0.8,
        })
        : await ImagePicker.launchImageLibraryAsync({
          mediaTypes: ImagePicker.MediaTypeOptions.Images,
          quality: 0.8,
        });

      if (result.canceled || !result.assets[0]) return;

      const asset = result.assets[0];

      // 3. Dosya Boyutu Kontrolü (5MB Limit)
      if (asset.fileSize && asset.fileSize > 5 * 1024 * 1024) {
        Alert.alert('Hata', 'Seçilen fotoğraf 5MB sınırını aşmaktadır.');
        return;
      }

      // 4. Backend'e Yükleme
      setUploading(true);
      await uploadClaimPhoto(claimId, asset.uri, asset.mimeType);

      Alert.alert('Başarılı', 'Fotoğraf başarıyla yüklendi.');
      onRefresh(); // Detayları ve fotoğraf listesini güncelle
    } catch (error: any) {
      const errorMsg = error?.response?.data?.message || 'Fotoğraf yüklenirken bir hata oluştu.';
      Alert.alert('Hata', errorMsg);
    } finally {
      setUploading(false);
    }
  };

  return (
    <ScrollView style={styles.container}>
      <Text style={styles.sectionTitle}>Hasar Fotoğrafları</Text>

      {/* Yüklenen Fotoğraflar Galerisi */}
      <ScrollView horizontal showsHorizontalScrollIndicator={false} style={styles.photoList}>
        {photos && photos.length > 0 ? (
          photos.map((photo) => (
            <Image
              key={photo.id}
              source={{ uri: photo.fileUrl }}
              style={styles.photoThumbnail}
            />
          ))
        ) : (
          <Text style={styles.emptyText}>Henüz fotoğraf eklenmemiş.</Text>
        )}
      </ScrollView>

      {/* Fotoğraf Ekleme Butonları */}
      <View style={styles.actionContainer}>
        {uploading ? (
          <ActivityIndicator size="large" color="#0066CC" />
        ) : (
          <View style={styles.buttonGroup}>
            <TouchableOpacity
              style={[styles.button, styles.primaryButton]}
              onPress={() => handlePickAndUpload(false)}
            >
              <Text style={styles.buttonText}>Galeriden Seç</Text>
            </TouchableOpacity>

            <TouchableOpacity
              style={[styles.button, styles.secondaryButton]}
              onPress={() => handlePickAndUpload(true)}
            >
              <Text style={styles.buttonText}>Kamera Aç</Text>
            </TouchableOpacity>
          </View>
        )}
      </View>
    </ScrollView>
  );
};

const styles = StyleSheet.create({
  container: { flex: 1, padding: 16 },
  sectionTitle: { fontSize: 18, fontWeight: 'bold', marginBottom: 12, color: '#333' },
  photoList: { flexDirection: 'row', marginBottom: 16 },
  photoThumbnail: { width: 100, height: 100, borderRadius: 8, marginRight: 8 },
  emptyText: { color: '#888', fontStyle: 'italic', marginVertical: 20 },
  actionContainer: { marginTop: 10, alignItems: 'center' },
  buttonGroup: { flexDirection: 'row', justifyContent: 'space-between', width: '100%' },
  button: { flex: 1, padding: 12, borderRadius: 8, alignItems: 'center', marginHorizontal: 4 },
  primaryButton: { backgroundColor: '#0066CC' },
  secondaryButton: { backgroundColor: '#28A745' },
  buttonText: { color: '#FFF', fontWeight: '600' },
});