System.Console.Write("Enter department's name: ");
var departmentName = Console.ReadLine();

var department = new Department {
  Name = departmentName
};

System.Console.WriteLine("Enter worker data:");
System.Console.Write("Name: ");
var workerName = Console.ReadLine();
System.Console.Write("Level: ");
var workerLevel = Console.ReadLine();
System.Console.Write("Base salary: ");
var workerBaseSalary = double.Parse(Console.ReadLine());

var worker = new Worker {
  Name = workerName,
  Department = department,
  Level = Enum.Parse<WorkerLevel>(workerLevel),
  BaseSalary = workerBaseSalary,
};

System.Console.Write("How many contracts to this worker? ");
var contractsCount = int.Parse(Console.ReadLine());

var counter = 1;

while(counter <= contractsCount)
{
  System.Console.WriteLine($"Enter #{counter} contract data:");
  System.Console.Write("Date (DD/MM/YYYY): ");
  var contractDate = Console.ReadLine().Split("/");
  System.Console.Write("Value per hour: ");
  var contractValuePerHour = double.Parse(Console.ReadLine());
  System.Console.Write("Duration (hours): ");
  var contractHours = int.Parse(Console.ReadLine());

  var contract = new HourContract {
    Date = new DateTime(int.Parse(contractDate[2]), int.Parse(contractDate[1]), int.Parse(contractDate[0])),
    Hours = contractHours,
    ValuePerHour = contractValuePerHour
  };
  worker.AddContract(contract);

  counter++;
}

System.Console.Write("Enter month and year to calculate income (MM/YYYY): ");
var incomeDate = Console.ReadLine();
var splitIncomeDate = incomeDate.Split("/");

var workerIncome = worker.Income(int.Parse(splitIncomeDate[0]), int.Parse(splitIncomeDate[1]));

System.Console.WriteLine($"Name: {worker.Name}");
System.Console.WriteLine($"Department: {worker.Department.Name}");
System.Console.WriteLine($"Income for {incomeDate}: {workerIncome:F2}");
