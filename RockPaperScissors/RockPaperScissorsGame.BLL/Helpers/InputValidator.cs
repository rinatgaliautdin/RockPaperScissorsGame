namespace RockPaperScissorsGame.BLL.Helpers
{
    public static class InputValidator
    {
        public static bool IsInputValid(string text)
        {
            return text.ToLower().Equals("r") || text.ToLower().Equals("s") || text.ToLower().Equals("p");
        }

    }
}
