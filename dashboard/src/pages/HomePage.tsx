import { MetricCard } from '../components/MetricCard';
import { API_BASE_URL } from '../services/api';

const foundationItems = [
  'Backend solution and layered project structure are initialized.',
  'PostgreSQL connectivity is prepared through environment-based configuration.',
  'Dashboard and mobile shells are ready for later feature work.',
  'No business module logic is introduced in Sprint 00.',
];

const metrics = [
  {
    label: 'Backend',
    value: 'ASP.NET Core + EF Core',
    description: 'Clean Architecture foundation with database connectivity.',
  },
  {
    label: 'Dashboard',
    value: 'React + Vite + TypeScript',
    description: 'A polished shell for future insurer operations workflows.',
  },
  {
    label: 'Mobile',
    value: 'React Native + Expo',
    description: 'A lightweight mobile starter with shared design direction.',
  },
];

export function HomePage() {
  return (
    <main className="dashboard-shell">
      <div className="dashboard-container">
        <header className="dashboard-header">
          <div className="brand">
            <span className="brand__eyebrow">ClaimFlow / Sprint 00</span>
            <h1 className="brand__title">Insurance Operations Portal</h1>
            <p className="brand__subtitle">
              The foundation is in place for backend, dashboard, and mobile workstreams.
              This shell keeps the implementation production-oriented without adding any
              business feature scope yet.
            </p>
          </div>

          <div className="status-chip">Local API: {API_BASE_URL}</div>
        </header>

        <section className="hero-grid">
          <article className="panel panel--hero">
            <p className="panel__label">Current focus</p>
            <h2>Architecture first, features later</h2>
            <p className="panel__copy">
              Sprint 00 establishes the repository structure, local development flow, and
              environment wiring so later sprints can move quickly without revisiting the
              foundational setup.
            </p>
          </article>

          <aside className="panel panel--side">
            <div>
              <p className="panel__label">Database</p>
              <p className="panel__copy">PostgreSQL container ready for local development.</p>
            </div>
            <div>
              <p className="panel__label">API contract</p>
              <p className="panel__copy">REST-style endpoints will remain thin and versionable.</p>
            </div>
            <div>
              <p className="panel__label">Future direction</p>
              <p className="panel__copy">Claims, policies, and authentication enter later sprints.</p>
            </div>
          </aside>
        </section>

        <section className="stats-grid">
          {metrics.map((metric) => (
            <MetricCard
              key={metric.label}
              label={metric.label}
              value={metric.value}
              description={metric.description}
            />
          ))}
        </section>

        <section className="foundation-grid">
          <article className="panel section-card">
            <h2 className="section-card__title">Sprint 00 deliverables</h2>
            <ul className="checklist">
              {foundationItems.map((item) => (
                <li key={item}>
                  <span className="checklist__bullet" />
                  <span>{item}</span>
                </li>
              ))}
            </ul>
          </article>

          <article className="panel section-card">
            <h2 className="section-card__title">Environment contract</h2>
            <p className="panel__copy">
              The dashboard reads the backend URL from the local environment so the shell can
              talk to the API without hard-coded values.
            </p>
            <div className="api-box">VITE_API_BASE_URL = http://localhost:5144</div>
            <p className="footer-note">
              This setup is intentionally small and easy to replace with feature-specific
              routing and data fetching in future sprints.
            </p>
          </article>
        </section>
      </div>
    </main>
  );
}