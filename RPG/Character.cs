using System;

namespace RPG
{
    public class Character
    {
        protected string name;

        protected int level;
 
        protected int health;
        protected int maxHealth;
        protected int strength;
        protected int defence;
        protected int speed;
        
        /* DEFAULT CONSTRUCTOR */
        public Character()
        {
            Name = "DEFAULT";
            Level = 1;
            Health = 100;
            MaxHealth = 100;
            Strength = 1;
            Defence = 1;
            Speed = 5;

        }

        /* ALTERNATE CONSTRUCTOR */
        public Character(string name, int level, int health, int maxHealth, int strength, int defence, int speed)
        {
            Name = name;
            Level = level;
            MaxHealth = maxHealth;
            Health = health;
            Strength = strength;
            Defence = defence;
            Speed = speed;
        }

        // Property to handle name
        public string Name
        {
            get { return this.name;  }

            set
            {
                this.name = value;
            }
        }

        // Property to handle level
        public int Level
        {
            get { return this.level; }

            set
            {
                if (value < 0) value = 0;
                this.level = value;
            }
        }

        // Property to handle health
        public int Health
        {
            get { return this.health;  }

            set
            {
                if (value < 0) value = 0;
                if (value > this.maxHealth) value = this.maxHealth;
                this.health = value;
            }
        }

        // Property to handle maxHealth
        public int MaxHealth
        {
            get { return this.maxHealth;  }

            set
            {
                if (value < 0) value = 0;
                this.maxHealth = value;
            }
        }

        // Property to handle strength
        public int Strength
        {
            get { return this.strength; }

            set
            {
                if (value < 0) value = 0;
                this.strength = value;
            }
        }

        // Property to handle defence
        public int Defence
        {
            get { return this.defence;  }

            set
            {
                if (value < 0) value = 0;
                this.defence = value;
            }
        }

        // Property to handle speed
        public int Speed
        {
            get { return this.speed; }

            set
            {
                if (value < 0) value = 0;
                this.speed = value;
            }
        }
    }

    public class Player : Character
    {
        private int experience;
        private int maxExperience;
        private int money;
        private int killed;

        public Player() : base()
        {
            Experience = 0;
            MaxExperience = 100;
            Money = 0;
            Killed = 0;
        }

        public Player(string name, int level, int health, int maxHealth, int strength, int defence, int experience, int maxExperience, int money, int speed) 
            : base(name, level, health, maxHealth, strength, defence, speed)
        {
            Experience = experience;
            MaxExperience = maxExperience;
            Money = money;
            Killed = killed;
        }

        // Property for handling experience
        public int Experience
        {
            get { return this.experience; }

            set
            {
                if (value < 0) value = 0;
                this.experience = value;
            }
        }

        // Property for handling maxExperience
        public int MaxExperience
        {
            get { return this.maxExperience;  }

            set
            {
                if (value < 0) value = 0;
                this.maxExperience = value;
            }
        }

        // Property for handling $$$$$$
        public int Money
        {
            get { return this.money;  }

            set
            {
                if (value < 0) value = 0;
                this.money = value;
            }
        }

        // Property for handling monsterKills
        public int Killed
        {
            get { return this.killed; }

            set
            {
                if (value < 0) value = 0;
                this.killed = value;
            }
        }
    }

    public class Monster : Character
    {
        private int moneyDrop;
        private int experienceDrop;

        public Monster() : base()
        {
            MoneyDrop = 10;
            ExperienceDrop = 10;
        }

        public Monster(string name, int level, int health, int maxHealth, int strength, int defence, int speed, int moneyDrop, int experienceDrop) 
            : base(name, level, health,maxHealth, strength, defence, speed)
        {
            MoneyDrop = moneyDrop;
            ExperienceDrop = experienceDrop;
        }


        // Property for handling moneyDrop
        public int MoneyDrop
        {
            get { return this.moneyDrop;  }

            set
            {
                if (value < 0) value = 0;
                this.moneyDrop = value;
            }
        }

        // Property for handling experienceDrop
        public int ExperienceDrop
        {
            get { return this.experienceDrop; }

            set
            {
                if (value < 0) value = 0;
                this.experienceDrop = value;
            }
        }
    }
}
