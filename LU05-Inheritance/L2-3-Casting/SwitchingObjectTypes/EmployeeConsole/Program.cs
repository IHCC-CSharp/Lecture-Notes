using EmployeeLibrary;

//create a list of Employee type (which is the base)
List<Employee> empList = new List<Employee>();

//add an Employee (base) object to the list
empList.Add(new Employee());

//CANNOT cast Employee object (base) to CommissionEmployee object (child)
// CommissionEmployee c = (CommissionEmployee)empList[0];  

//add a CommissionEmployee (child) object to the list        
empList.Add(new CommissionEmployee());

//CAN cast CommissionEmployee object (child) to Employee object (base)    
//Employee e = (Employee)empList[1];        


//set some properties of Employee object
empList[0].Id = 123;
empList[0].Salary = 20_000.00;
//empList[0].CommissionRate = .06;      //CommissionRate is not a property of Employee class

//set some properties of CommissionEmployee object
empList[1].Id = 456;
empList[1].Salary = 20_000.00;
//empList[1].CommissionRate = .06;     //empList[1] is still of Employee type, so CommissionRate not available

//check to see if underlying object type is a CommissionEmployee, if so, set the commission rate
if (empList[1] is CommissionEmployee)
{
    CommissionEmployee ce = (CommissionEmployee)empList[1]; //address of list object is assigned to ce
    ce.CommissionRate = .06; //this indirectly changes the list object            
}

//print out list
foreach (var item in empList)
{
    Console.WriteLine(item.ToString());
}

Console.ReadLine();

//time to switch object references in the list
//Employee[0] is now a CommissionEmployee, Employee[1] is now an Employee
//Employee to CommissionEmployee (base to child)
CommissionEmployee cEmp = new CommissionEmployee(); //first create a temp CommissionEmployee object (new address)
cEmp.Id = empList[0].Id; //capture the current IdNum and Salary
cEmp.Salary = empList[0].Salary;
cEmp.CommissionRate = .08; //set the CommissionRate
empList[0] = cEmp; //then assign back to the list (assigns address of cEmp)

//CommissionEmployee to Employee (child to base)
Employee emp = new Employee(); //first create a temp Employee object
emp.Id = empList[1].Id; //capture the current IdNum and Salary
emp.Salary = empList[1].Salary;
//emp.CommissionRate = .06;                 //Employee objects don't have commission rate       
empList[1] = emp; //then assign back to the list (assigns address of emp)

//print out list
foreach (var item in empList)
{
    Console.WriteLine(item.ToString());
}