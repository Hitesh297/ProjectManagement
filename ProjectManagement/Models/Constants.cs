namespace ProjectManagement.Models
{
    public static class Constants
    {
        public static List<int> YearDropdown
        {
            get
            {
                List<int> YearDropdown = new List<int>();
                int startYear = DateTime.Now.Year - 50;
                int endYear = DateTime.Now.Year + 50;

                for (int i = startYear; i < endYear; i++)
                {
                    YearDropdown.Add(i);
                }
                return YearDropdown;
            }
        }
    }
}
