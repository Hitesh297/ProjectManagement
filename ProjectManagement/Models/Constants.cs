namespace ProjectManagement.Models
{
    public static class Constants
    {
        public static List<int> YearDropdown
        {
            get
            {
                List<int> YearDropdown = new List<int>();
                int startYear = DateTime.Now.Year - 6;
                int endYear = DateTime.Now.Year + 6;

                for (int i = startYear; i < endYear; i++)
                {
                    YearDropdown.Add(i);
                }
                return YearDropdown;
            }
        }

        public static List<Company> CompanyDropdown 
        {
            get
            {
                List<Company> companyList = new List<Company>();
                companyList.Add(new Company() { Id = 1, Name = "Atlantis" });
                companyList.Add(new Company() { Id = 2, Name = "Apptoza" });
                return companyList;
            }
                }
    }

}
