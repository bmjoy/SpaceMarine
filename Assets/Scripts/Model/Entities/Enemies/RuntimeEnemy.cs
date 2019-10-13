using SpaceMarine.Model;
using Tools.Patterns.GameEvents;
using UnityEngine;

namespace SpaceMarine.Data
{
    public abstract class RuntimeEnemy : IEnemy
    {
        protected RuntimeEnemy(EnemyData data, Vector3 startPosition)
        {
            Data = data;
            Id = data.Id;
            Health = data.Health;
            StartLocalPosition = startPosition;
        }

        public EnemyId Id { get; }
        public EnemyData Data { get; }
        public bool IsDead { get; private set; }
        public int Health { get; private set; }

        public Vector3 StartLocalPosition { get; }

        public void TakeDamage(int amount)
        {
            Health -= amount;
            OnTakeDamage(amount);
            EvaluateDeath();
        }

        public void Destroy() => GameEvents.Instance.Notify<GameEvent.IDestroyEnemy>(i => i.OnDestroyEnemy(this));

        void EvaluateDeath()
        {
            IsDead = Health <= 0;
            if (IsDead)
                Destroy();
        }

        void OnTakeDamage(int damage) =>
            GameEvents.Instance.Notify<GameEvent.IEnemyTakeDamage>(i => i.OnTakeDamage(this, damage));
    }
}