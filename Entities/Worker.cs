using System.Diagnostics.Contracts;

class Worker
{
  public string Name { get; set; }
  public WorkerLevel Level { get; set; }
  public double BaseSalary { get; set; }
  public Department Department { get; set; }
  public List<HourContract> Contracts  = new();

  public void AddContract(HourContract contract)
  {
    Contracts.Add(contract);
  }

  public void RemoveContract(HourContract contract)
  {
    Contracts.Remove(contract);
  }

  public double Income(int year, int month)
  {
    double totalIncome = BaseSalary;

    foreach(var contract in Contracts)
    {
      if (contract.Date.Year == year && contract.Date.Month == month) {
        totalIncome += contract.TotalValue();
      }
    }

    return totalIncome;
  }
}