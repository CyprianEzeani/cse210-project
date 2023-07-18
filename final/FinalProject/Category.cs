public class HangmanCategory
    {
        private List<string> categories;
        private int selectedCategory;

        public HangmanCategory()
        {
            categories = new List<string>()
            {
                "Animals", "Music", "Beach", "Party", "City", "School", "Grocery", "Sports", "Leisure", "Wild West"
            };
        }

        public List<string> GetCategories()
        {
            return categories;
        }

        public void SetSelectedCategory(int categoryIndex)
        {
            selectedCategory = categoryIndex;
        }

        public string GetSelectedCategory()
        {
            return categories[selectedCategory];
        }

        public bool CategoryEnabled
        {
            get { return selectedCategory >= 0 && selectedCategory < categories.Count; }
        }
    }