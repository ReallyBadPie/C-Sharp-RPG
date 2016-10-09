namespace RPG
{
    class Item
    {
        protected int price;
        protected string name;


        // TODO: add more attributes for the item to modify from character

        /**
         * DEFAULT CONSTRUCTOR
         * IMPORT: None EXPORT: None
         */ 
        public Item()
        {
            this.price = 0;
            this.name = "DEFAULT ITEM";
        }

        /**
         * ALTERNATE CONSTRUCTOR 01
         * IMPORT: (int) price, (string) name
         * EXPORT: None
         */
        public Item(int price, string name)
        {
            this.price = price;
            this.name = name;
        }

        // Property for managing price
        public int Price
        {
            get { return price; }

            set {
                // Ensure value is within suited range
                if (value < 0)
                {
                    value = 0;
                }
                price = value;
            }
        }

        // Propertty for managing name
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    class Weapon : Item
    {
        private int strengthBonus;
        private int defenceBonus;
        private int healthBonus;

        private int levelRequirement;

        private string type;

        public Weapon(string name, int price, int strengthBonus, int defenceBonus, int healthBonus, int levelRequirement)
            :base(price, name)
        {
            this.StrengthBonus = strengthBonus;
            this.DefenceBonus = DefenceBonus;
            this.HealthBonus = healthBonus;
            this.LevelRequirement = levelRequirement;
        }

        // Property for managing strengthBonus
        public int StrengthBonus
        {
            get { return strengthBonus; }

            set
            {
                // Ensure within valid range
                if (value < 0) value = 0;
                strengthBonus = value;
            }
        }

        // Property for managing defenceBonus
        public int DefenceBonus
        {
            get { return defenceBonus; }

            set
            {
                if (value < 0) value = 0;
                defenceBonus = value;
            }
        }

        // Property for managing healthBonus
        public int HealthBonus
        {
            get { return healthBonus; }

            set
            {
                if (value < 0) value = 0;
                healthBonus = value;
            }
        }

        // Property for managing level requirements
        public int LevelRequirement
        {
            get { return levelRequirement; }
            set {
                if (value < 0) value = 0;
                levelRequirement = value;
            }
        }

    }

}
