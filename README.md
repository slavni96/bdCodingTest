# BeatData.CodingTest

### Functionalities

- Calls, combines, and returns the result of the following mock services:

  - https://jsonplaceholder.typicode.com/users
  - https://jsonplaceholder.typicode.com/todos

- Allow filtering on the user id field, so as to return only the task of specific user

### Endpoints

- Retrieve all todos 
	- i.e /getAllTask?limit=10&offset=100
- Filter todos given a userId
	- i.e /getTaskByUser?userId=1&limit=10&offset=100 	

### Changes

- TaskController
	- GetTaskByUser(...)
		- Changed one  of the two variable name from UserId to Limit	

- TaskService
	- GetTasks(int? limit, int? offset)
		- Made the method Async
		
	- GetTasksByUser(int? limit, int? offset, int userId)
		- Made the method Async
		- Corrected the return type of the method
		
	- GetFilteredTasks(int? limit, int? offset, int? userId = null)
		- Inserted the null check in: var tasks = (await this.GetTasksData())?.AsQueryable();
		- Modified the block   if (userId != null){...}    in    if (userId != null && userId > 0){...}     and deleted the block       if (UserId == 0){...}
		- Added ckeck on negative value for Limit   in     if (limit != null && limit > 0){...}

### Unit Test

  - Created some Unit Test for the method GetTasksByUser:
	- CountValues: Check if the number of value is the one expected 
	- NullCheckUser: Check on null or not correct value
	- CheckTitle: check if the title of a specific toDo is the one expected

### How To Run

```cmd
> cd BeatData.CodingTest
> dotnet build
> dotnet run
```
