namespace Builder_ImplementationExample
{
    public interface IMonsterBuilder
    {
        void setName(string name);
        void setHealthLevel(int health);
        void setUltimatePower(int power);
        void setAttack(int attack);

        void setDefense(int defense);

        void setVictoryCelebration(string victoryCelebration);

        Monster GetMonster();
    }

    public class MonstroBuilder : IMonsterBuilder
    {
        private Monster _monster = new Monster();

        public void setName(string name)
        {
            _monster.Name = name;
        }
        public void setHealthLevel(int health)
        {
            _monster.HealthLevel = health;
        }
        public void setUltimatePower(int power)
        {
            _monster.UltimatePower = power;
        }
        public void setAttack(int attack)
        {
            _monster.Attack = attack;
        }
        public void setDefense(int defense)
        {
            _monster.Defense = defense;
        }
        public void setVictoryCelebration(string victoryCelebration)
        {
            _monster.VictoryCelebration = victoryCelebration;
        }
        public Monster GetMonster()
        {
            return _monster;
        }
    }

    public class Monster
    {
        public string Name { get; set; }
        public int HealthLevel { get; set; }
        public int UltimatePower { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public string VictoryCelebration { get; set; }



        public void SpawnMonster()
        {
            Console.WriteLine($"Monster: {Name}");
            Console.WriteLine($"HealthLevel: {HealthLevel}");
            Console.WriteLine($"Ultimate Power: {UltimatePower}");
            Console.WriteLine($"Attack: {Attack}");
            Console.WriteLine($"Defense: {Defense}");
            Console.WriteLine($"Victory Celebration: {VictoryCelebration}");
            Console.WriteLine();
        }
    }

    public class MonsterDirector
    {
        private readonly IMonsterBuilder _builder;

        public MonsterDirector(IMonsterBuilder builder)
        {
            _builder = builder;
        }

        public void BuildWeakMonster()
        {
            _builder.setName("Goblin");
            _builder.setHealthLevel(100);
            _builder.setUltimatePower(45);
            _builder.setAttack(25);
            _builder.setDefense(12);
            _builder.setVictoryCelebration("You lost! You are died!");
        }

        public void BUildBossMonster()
        {
            _builder.setName("BigSnake");
            _builder.setHealthLevel(500);
            _builder.setUltimatePower(120);
            _builder.setAttack(45);
            _builder.setDefense(30);
            _builder.setVictoryCelebration("[Deafening scream]");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = new MonstroBuilder();
            var director = new MonsterDirector(builder);

            director.BuildWeakMonster();
            var goblin = builder.GetMonster();
            goblin.SpawnMonster();

            director.BUildBossMonster();
            var boss = builder.GetMonster();
            boss.SpawnMonster();
        }
    }
}
