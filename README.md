# HalloweenNameWCFService

Simple WCF Halloween Name Service Application & Client "Tester" Console Application

Project Blog Article here: 


About


This project presents a simple, but fun WCF Halloween Name Service Application. The service provides either a single Halloween name (string), or an array of Halloween names. It is hosted using IIS Express to quickly demo and test the service with a client. 
A client “tester” console application tests the service and provides output to the user.  


Architecture


The demo project consists of these component topics:

•	Halloween Name WCF Service Application

o	Name (Data Model Contract)
o	Name Helper (Helper Class)
o	IHalloweenService (Interface for Service)
o	HalloweenService (Code that Implements the Service Interface)

•	Client “Tester to Service” Console Application
o	Connected Service “Proxy Reference” HalloweenNameServiceRef
o	Main Program
