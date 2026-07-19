import { StyleSheet, Text, View } from 'react-native';
import { InfoCard } from '../components/InfoCard';
import { API_BASE_URL } from '../services/api';
import { colors } from '../theme/colors';

const highlights = [
  {
    title: 'Foundation ready',
    description: 'The app shell is wired for future navigation, screens, and API work.',
  },
  {
    title: 'Shared API contract',
    description: `Mobile points to the backend through ${API_BASE_URL} for local development.`,
  },
  {
    title: 'Sprint discipline',
    description: 'No business rules or claim workflows are introduced during Sprint 00.',
  },
];

export function HomeScreen() {
  return (
    <View style={styles.safeArea}>
      <View style={styles.container}>
        <View style={styles.hero}>
          <Text style={styles.eyebrow}>ClaimFlow / Mobile</Text>
          <Text style={styles.title}>Insurance Operations Portal</Text>
          <Text style={styles.subtitle}>
            A clean mobile starter for claim-related workflows, prepared to consume the
            backend API once business features are added.
          </Text>
        </View>

        <View style={styles.apiBox}>
          <Text style={styles.apiLabel}>Backend endpoint</Text>
          <Text style={styles.apiValue}>{API_BASE_URL}</Text>
        </View>

        <View style={styles.cards}>
          {highlights.map((item) => (
            <InfoCard key={item.title} title={item.title} description={item.description} />
          ))}
        </View>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  safeArea: {
    flex: 1,
    backgroundColor: colors.background,
  },
  container: {
    flex: 1,
    paddingHorizontal: 20,
    paddingTop: 16,
    paddingBottom: 24,
    gap: 20,
    backgroundColor: colors.background,
  },
  hero: {
    gap: 10,
  },
  eyebrow: {
    color: '#93C5FD',
    fontSize: 12,
    letterSpacing: 1.4,
    textTransform: 'uppercase',
  },
  title: {
    color: colors.text,
    fontSize: 34,
    lineHeight: 38,
    fontWeight: '800',
  },
  subtitle: {
    color: colors.textMuted,
    fontSize: 15,
    lineHeight: 22,
  },
  apiBox: {
    backgroundColor: colors.surface,
    borderRadius: 20,
    padding: 16,
    borderWidth: 1,
    borderColor: 'rgba(148, 163, 184, 0.16)',
  },
  apiLabel: {
    color: '#93C5FD',
    fontSize: 12,
    letterSpacing: 1.1,
    textTransform: 'uppercase',
    marginBottom: 8,
  },
  apiValue: {
    color: colors.text,
    fontSize: 14,
    fontFamily: 'monospace',
  },
  cards: {
    gap: 12,
  },
});