# Employee Management System With Builder Pattern

This is a simple Employee Management System project that demonstrates the use of the Builder design pattern and adherence to SOLID principles.

## Introduction

This project showcases the creation of employee objects using the Builder design pattern. It provides separate builder classes for internal and external employees, allowing you to create employees with specific attributes such as full name, email, and username.

## Builder Design Pattern

The Builder design pattern simplifies the construction of complex objects by abstracting the construction process into a series of steps. In this project:

- `IEmployeeBuilder` interface defines the steps to create an employee.
- `InternalEmployeeBuilder` and `ExternalEmployeeBuilder` classes implement this interface and create employees with distinct properties.

## SOLID Principles

The project adheres to the SOLID principles as follows:

- **Single Responsibility Principle (SRP)**: Each class and interface has a single responsibility, keeping the codebase clean and maintainable.

- **Open/Closed Principle (OCP)**: The code is closed for modification but open for extension, allowing easy addition of new employee types.

- **Liskov Substitution Principle (LSP)**: Subclasses (`InternalEmployee` and `ExternalEmployee`) can be used interchangeably with the base class (`BaseEmployee`).

- **Interface Segregation Principle (ISP)**: Builder classes implement a common interface, ensuring that all required methods are implemented.

- **Dependency Inversion Principle (DIP)**: The Builder pattern abstracts the object creation process, promoting dependency inversion.

