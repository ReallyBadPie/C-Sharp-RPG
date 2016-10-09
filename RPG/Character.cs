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
            this.name = "";
            this.level = 1;
            this.health = 100;
            this.maxHealth = 100;
            this.strength = 50;
            this.defence = 5;
            this.speed = 5;
        }

        /* ALTERNATE CONSTRUCTOR */
        public Character(string name, int level, int health, int maxHealth, int strength, int defence, int speed)
        {
            this.name = name;
            this.level = level;
            this.health = health;
            this.maxHealth = maxHealth;
            this.strength = strength;
            this.defence = defence;
            this.speed = speed;
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

        public int getSpeed()
        {
            return this.speed;
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
        
        public void setSpeed(int speed)
        {
            this.speed = speed;
        }
    }

    public class Player : Character
    {
        private int experience;
        private int maxExp;
        private int money;
        private int killed;

        public Player() : base()
        {
            this.experience = 0;
            this.maxExp = 100;
            this.money = 0;
            this.killed = 0;
        }

        public Player(string name, int level, int health, int maxHealth, int strength, int defence,int speed, int experience, int maxExp, int money, int killed) : base(name, level, health, maxHealth, strength, defence, speed)
        {

            this.experience = experience;
            this.maxExp = maxExp;
            this.money = money;
            this.killed = killed;
        }

        //Getters
        public int getExperience()
        {
            return this.experience;
        }

        public int getMaxExp ()
        {
            return this.maxExp;
        }

        public int getMoney()
        {
            return this.money;
        }

        public int getKilled()
        {
            return this.killed;
        }

        //Setters
        public void setExperience(int experience)
        {
            this.experience = experience;
        }

        public void setMaxExp (int maxExp)
        {
            this.maxExp = maxExp;
        }

        public void setMoney(int money)
        {
            this.money = money;
        }

        public void setKilled(int killed)
        {
            this.killed = killed;
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

        public Monster(string name, int level, int health, int maxHealth, int strength, int defence, int speed, int moneyDrop, int experienceDrop) : base(name, level, health,maxHealth, strength, defence, speed)
        {
            this.moneyDrop = moneyDrop;
            this.experienceDrop = experienceDrop;
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
