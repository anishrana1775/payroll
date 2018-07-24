#Future enchansements:

Currently api is working fine. 
As for future we can enhance more. Security can be added (e.g. token authintication) so that only authenticated user can access. 
Instance level null checking for each class constroctor, becuase as this is api project it can be access by simple URl which can some how have null instance issue.

Calculation of tax can be yearly basis as tax slab chganges each year. For that need one more column "Year".
Currently tax slab data is hardcoded in rpositiry, for future it should be from database as it is easy to maintain from databse.
Database related code shoul be under EmployeePayslipRepositiry.Domain project.

More test case need to add for insance and exception level tests.

"Want to cover more test cases but not able to do so due to time shortage"

#Technologies User
c#, Web Api (Core 2.0)
Inbuilt DI injection
Unit Test with NUnit and Moq

#Pattern Used
Repository (Reposiroty layer), Facade (Business Layer)
DI as SOLID prinicple.

#Project Setup
Easy to set up.
1. Open the project in VS and set EmployeePayslip.Api as Startup project
2. Run the project
3. Open Postman and setup for POST request (url:http://localhost:52297/api/payslip)
4. Click "Body" and select "raw" and select JSON(application/json)
5. Type for json data type to send in post request, below is the sample input
    {
	"FirstName" : "Ram",
	"LastName" : "Kumar",
	"AnnualSalary" : "90000",
	"PaymentStartDate" : "1 March - 31 March",
	"SuperRate" : 9
}

6. Click send button and check the response, below is the sample output
    {
    "name": "Ram Kumar",
    "pay-period": "1 March - 31 March",
    "gross-income": 7500,
    "income-tax": 1744,
    "net-income": 5756,
    "super-amount": 0
}
