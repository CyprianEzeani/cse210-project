public class HangmanScorer
{
    private int game1PartScore;
    private int game2PartScore;
    private int level2Bonus;
    private int level3Bonus;

    public HangmanScorer(int game1PartScore, int game2PartScore, int level2Bonus, int level3Bonus)
    {
        this.game1PartScore = game1PartScore;
        this.game2PartScore = game2PartScore;
        this.level2Bonus = level2Bonus;
        this.level3Bonus = level3Bonus;
    }

    public int CalculateScore(int incorrectGuesses, int numberOfLetters, bool isCategoryEnabled, string selectedCategory)
    {
        int score = 0;

        int remainingParts = HangmanGame.MaxIncorrectGuesses - incorrectGuesses;

        if (isCategoryEnabled)
        {
            score += game1PartScore * remainingParts;
        }
        else
        {
            score += game2PartScore * remainingParts;
        }

        score += numberOfLetters * (isCategoryEnabled ? game1PartScore : game2PartScore);

        if (remainingParts >= 6)
        {
            score += level2Bonus;
        }
        else if (remainingParts >= 3)
        {
            score += level3Bonus;
        }

        if (isCategoryEnabled && selectedCategory != null)
        {
            score += selectedCategory.Length;
        }

        return score;
    }
}