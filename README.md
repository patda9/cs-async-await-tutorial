# C# Async Await Tutorial

## Requirements

- .NET 5.0 SDK

## Running Sequence

1. dotnet build
2. cd ApiService
3. dotnet run
4. cd ../UiClient
5. dotnet run

## Explaination

- Get Integers Button:
Make a request to get integers from `ApiService` synchronously, the UI window freezes and waits for the result(s) (1 x n) second(s) where n is random count of result integers.

- Get Integers Async Button:
Make a request to get integers from `ApiService` asynchronously, the UI window is not blocked by the operations but it waits for the result(s) (1 x n) second(s) where n is random count of result integers.

- Get Integers Async Parallel Button:
Make a request to get integers from `ApiService` asynchronously, the UI window is not blocked by the operations and despite how many results count is, it waits 1 only second.

- Test Button: Its purpose is to test wheter the UI is freezing or not.
