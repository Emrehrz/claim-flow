type MetricCardProps = {
  label: string;
  value: string;
  description: string;
};

export function MetricCard({ label, value, description }: MetricCardProps) {
  return (
    <article className="stat-card">
      <span className="stat-card__label">{label}</span>
      <h2 className="stat-card__value">{value}</h2>
      <p className="stat-card__meta">{description}</p>
    </article>
  );
}