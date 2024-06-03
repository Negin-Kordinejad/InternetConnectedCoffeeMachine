# TechReady Developer Technical Test
- [Description](Description)
- [Architecture](Architecture)
- [Logging](Logging)

## Description
Design and implement an HTTP API that controls an imaginary internet-connected coffee machine.

## Branching
- master: initial project.
- extra-credit: add weather check feature.

## Architecture
- InternetConnectedCoffeeMachine:
  - A REST API Project, injecting a mediator to chain handlers as pipeline behaviours using the [MediatR] library
  -Infrastructure:
  -Queries:
      - GetCoffeeQuery handler to provide a regular coffee.
  -Common/Behaviours
    - Pipeline behaviours that perform chained actions before executing GetCoffeeQuery and apply the business rules.
  -Services
   - functions to use in handlers and behaviours.
   - 
- InternetConnectedCoffeeMachine.IntegrationTests
  - Tests to satisfy the business scenarios

## Logging
- Logs the duration takes for any query handler to execute
- Logs the exceptions that are thrown by the API

## Test
- Swagger open Api / Postman
- Integration tests

## ToDo
- Refactoring.
- At the moment all responses codes are verifying in the controller. Need to find best practise to remove them from the controller. there are two ways:
   -  Every handler will return a proper action result so controller we no need to verifying.
   -  Every handler will throw a custom exception and global error handling middleware will catch and verify them.
- Add more unit tests.
