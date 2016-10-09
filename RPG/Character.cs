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
        

        /* DEFAULT CONSTRUCTOR */
        public Character()
        {
            this.Name = "";
            this.Level = 1;
            this.Health = 100;
            this.MaxHealth = 100;
            this.Strength = 1;
            this.Defence = 1;
        }

        /* ALTERNATE CONSTRUCTOR */
        public Character(string name, int level, int health, int maxHealth, int strength, int defence)
        {
            this.Name = name;
            this.Level = level;
            this.Health = health;
            this.MaxHealth = maxHealth;
            this.Strength = strength;
            this.Defence = defence;
        }

        // Property to handle name
        public string Name
        {
            get { return name;  }

            set
            {
                name = value;
            }
        }

        // Property to handle level
        public int Level
        {
            get { return level; }

            set
            {
                if (value < 0) value = 0;
                level = value;
            }
        }

        // Property to handle health
        public int Health
        {
            get { return health;  }

            set
            {
                if (value < 1) value = 1;
                if (value > MaxHealth) value = MaxHealth;
                health = value;
            }
        }

        // Property to handle maxHealth
        public int MaxHealth
        {
            get { return maxHealth;  }

            set
            {
                if (value < Health) value = health;
                MaxHealth = value;
            }
        }

        // Property to handle strength
        public int Strength
        {
            get { return strength; }

            set
            {
                if (value < 0) value = 0;
                strength = value;
            }
        }

        // Property to handle defence
        public int Defence
        {
            get { return defence;  }

            set
            {
                if (value < 0) value = 0;
                defence = value;
            }
        }

        /* Getters */
        public string getName()
        {
            return this.name;
        }

        public int getLevel()
        {
            return this.level;
        }

        public int getHealth()
        {
            return this.health;
        }

        public int getMaxHealth()
        {
            return this.maxHealth;
        }

        public int getStrength()
        {
            return this.strength;
        }

        public int getDefence()
        {
            return this.defence;
        }

        /* Setters */
        public void setName(string name)
        {
            this.name = name;
        }

        public void setHealth(int health)
        {
            this.health = health;

            if (health <= 0)
            {
                //run death function
            }
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }

        public void setMaxHealth(int maxHealth)
        {
            this.maxHealth = maxHealth;
        }

        public void setLevel(int level)
        {
            this.level = level;
        }

        public void setStrength(int strength)
        {
            this.strength = strength;
        }

        public void setDefence(int defence)
        {
            this.defence = defence;
        }
    }

    public class Player : Character
    {
        private int experience;
        private int maxExperience;
        private int money;

        public Player() : base()
        {
            this.Experience = 0;
            this.MaxExperience = 100;
            this.money = 0;
        }

        public Player(string name, int level, int health, int maxHealth, int strength, int defence, int experience, int maxExperience, int money) 
            : base(name, level, health, maxHealth, strength, defence)
        {
            this.experience = experience;
            this.MaxExperience = maxExperience;
            this.money = money;
        }

        // Property for handling experience
        public int Experience
        {
            get { return experience; }

            set
            {
                if (value < 0) value = 0;
                experience = value;
            }
        }

        // Property for handling maxExperience
        public int MaxExperience
        {
            get { return maxExperience;  }

            set
            {
                if (value < 0) value = 0;
                maxExperience = value;
            }
        }

        // Property for handling $$$$$$
        public int Money
        {
            get { return money;  }

            set
            {
                if (value < 0) value = 0;
                money = value;
            }
        }

        //Getters
        public int getExperience()
        {
            return this.experience;
        }

        public int getMoney()
        {
            return this.money;
        }

        //Setters
        public void setExperience(int experience)
        {
            this.experience = experience;
        }

        public void setMoney(int money)
        {
            this.money = money;
        }
    }

    public class Monster : Character
    {
        private int moneyDrop;
        private int experienceDrop;

        public Monster() : base()
        {
            this.moneyDrop = 10;
            this.experienceDrop = 10;
        }

        public Monster(string name, int level, int health, int maxHealth, int strength, int defence, int moneyDrop, int experienceDrop) : base(name, level, health,maxHealth, strength, defence)
        {
            this.moneyDrop = moneyDrop;
            this.experienceDrop = experienceDrop;
        }


        // Property for handling moneyDrop
        public int MoneyDrop
        {
            get { return moneyDrop;  }

            set
            {
                if (value < 0) value = 0;
                moneyDrop = value;
            }
        }

        // Property for handling experienceDrop
        public int ExperienceDrop
        {
            get { return experienceDrop; }

            set
            {
                if (value < 0) value = 0;
                experienceDrop = value;
            }
        }

        //Getters
        public int getMoneyDrop()
        {
            return this.moneyDrop;
        }

        public int getExperienceDrop()
        {
            return this.experienceDrop;
        }

        //Setters
        public void setMoneyDrop(int moneyDrop)
        {
            this.moneyDrop = moneyDrop;
        }

        public void setExperienceDrop(int experienceDrop)
        {
            this.experienceDrop = experienceDrop;
        }
    }
}
