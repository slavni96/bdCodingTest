# BeatData.CodingTest

A REST Web API project that:

- Calls, combines, and returns the result of the following mock services:

  - https://jsonplaceholder.typicode.com/users
  - https://jsonplaceholder.typicode.com/todos

- Allow filtering on the user id field, so as to return only the task of specific user

There are two endpoint, one to retrieve all todos (paginated) and one that filter todos given a userId:

- i.e /getAllTask?limit=10&offset=100
- i.e /getTaskByUser?userId=1&limit=10&offset=100

### How To Run

```cmd
> cd BeatData.CodingTest
> dotnet build
> dotnet run
```
