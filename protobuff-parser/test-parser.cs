static void Main(string[] args)
{

	// creating an instance of Employee
	Employee employee = new Employee() { Id = 1, FullName = "john smith", Email = "johnsmith@gmail.com" };

	//store bytes
	byte[] employeeBytes;

	// Write to a stream
	using (MemoryStream stream = new MemoryStream())
	{
		employee.WriteTo(stream);
		employeeBytes = stream.ToArray();
	}
	// Read from a stream bytes
	Employee.Parser.ParseFrom(employeeBytes);


	// Write to a file
	using (Stream output = File.OpenWrite("mydata.data"))
	{
		employee.WriteTo(output);
	}

	// Read from a data file
	using (Stream output = File.OpenRead("mydata.data"))
	{
		var employeeFromFile = Employee.Parser.ParseFrom(output);
	}

}