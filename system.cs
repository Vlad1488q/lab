using System;

namespace DamageSystemDemo
{
    public interface IDamageable
    {
        void TakeDamage(int amount);
    }

    public abstract class Projectile
    {
        protected int damage;

        public Projectile(int damage)
        {
            this.damage = damage;
        }

        public abstract void HitTarget(IDamageable target);
    }

    public class Bullet : Projectile
    {
        public Bullet(int damage) : base(damage) { }

        public override void HitTarget(IDamageable target)
        {
            Console.WriteLine($"Куля влучила у ціль, завдає {damage} шкоди.");
            target.TakeDamage(damage);
        }
    }

    public class Enemy : IDamageable
    {
        private int health;

        public Enemy(int health)
        {
            this.health = health;
        }

        public void TakeDamage(int amount)
        {
            health -= amount;
            Console.WriteLine($"Ворог отримав {amount} шкоди. Здоров'я: {health}");

            if (health <= 0)
            {
                Console.WriteLine("Ворог знищений!");
            }
        }
    }

    public class BreakableWall : IDamageable
    {
        private int durability;

        public BreakableWall(int durability)
        {
            this.durability = durability;
        }

        public void TakeDamage(int amount)
        {
            durability -= amount;
            Console.WriteLine($"Стіна отримала {amount} шкоди. Міцність: {durability}");

            if (durability <= 0)
            {
                Console.WriteLine("Стіна зруйнована!");
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Bullet bullet = new Bullet(30);

            Enemy enemy = new Enemy(50);
            BreakableWall wall = new BreakableWall(40);

            Console.WriteLine("=== Атака по ворогу ===");
            bullet.HitTarget(enemy);

            Console.WriteLine("\n=== Атака по стіні ===");
            bullet.HitTarget(wall);
        }
    }
}