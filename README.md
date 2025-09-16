# Kevin Lockerby Solution <br /> C# Refactoring and unit test exercises

I wanted to provided a comprehensive refactoring solution that encompassed the following characteristics

- Code Smells to look for:
    - Introducing Locals to replace complex expressions
    - Promote Local Variable to Parameter
    - Replace property data value with object (replace string customer name with Customer object)
    - Wrap parameters/properties into a class
    - Move common subclass properties/methods to base class
    - Convert to Expression bodied member
    - Use nameof() when referencing args
    - Use guard clauses to throw exceptions (Refactoring with C# p. 231)
    - Replace Magic Numbers
    - Use required modifier for properties where relevant
    - No side effects in methods
    - No impure method calls
    - Extract Methods
    - Replace vars
    - Immutable State
 
 - Apply Solid Principles:
    - Single Responsibility Principle
        - Refactor classes and methods such that they provide a single responsibility and is easily testable
    - Open Closed Principle
        - Remove lengthy If-Then-Else and switch statements by using provider model and factory method pattern
    - Interface Segregation Principle
        - Multiple concise Interfaces
    - Dependency Inversion Principle
        - Constructor property injection used

- Unit Tests
    - Provide Unit Tests using XUnit
    - Used NSubstitute, and Autofixture for mocking and boilerplate
    - Used Shouldy library for fluent assertions
