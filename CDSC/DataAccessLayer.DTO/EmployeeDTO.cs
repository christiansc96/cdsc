namespace DataAccessLayer.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public decimal HourlySalary { get; set; }
        public decimal MonthlySalary { get; set; }
        public decimal AnnualSalary()
        {
            decimal anualSalary;
            switch (this.ContractTypeName)
            {
                case "HourlySalaryEmployee":
                    {
                        anualSalary = 120 * HourlySalary * 12;
                        break;
                    }
                case "MonthlySalaryEmployee":
                    {
                        anualSalary = MonthlySalary * 12;
                        break;
                    }
                default:
                    anualSalary = 0;
                    break;
            }
            return anualSalary;
        }
    }
}