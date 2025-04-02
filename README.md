# BasicWCFServiceApplication&ClientConsoleApplication

Project Blog Article Here: 
https://portfolio.katiegirl.net/2019/03/14/basic-wcf-service-application-client-console-tester/
----------------------------------------
This project presents a basic WCF Service Application and client "tester" console application in same Visual Studio solution. The WCF Service was hosted using IIS Express. A simple console "test" application connected to the service through a proxy. The service provides basic mathematical operations contracts including:

        [OperationContract]
        double Add(double value1, double value2);

        [OperationContract]
        double Subtract(double value1, double value2);

        [OperationContract]
        double Multiply(double value1, double value2);

        [OperationContract]
        double Divide(double value1, double value2);

        [OperationContract]
        double CircleArea(double radius);

The client is expected to access the service using information available through the WSDL. I created my test client application by building a proxy using svcutil.exe http://localhost:portnumber/MathService.svcutil

Note: You should update the client proxy or reference to the server before running this in your Visual Studio IDE by first going to TestClient (Console Application) --> Connected Services --> MathServiceRef and selecting "Update Service Reference".

