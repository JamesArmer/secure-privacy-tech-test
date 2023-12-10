# secure-privacy-tech-test

A simple web application which displays a list of users in a table with the following fields:

- name
- email
- phone number

There is a button on the home page which takes the user to a form which allows them to create a new user.

All code for the application (frontend/backend/tests) is held in this mono-repo

## How to run

Makefiles are used to run each of the frontend and backend with the `make run` command for standardisation.

To run MongoDB locally use the `make up` command in the `/backend` folder which will use the `docker-compose.yaml` file to run MongoDB in a container.

## Angular 17 Frontend

The Angular frontend uses routing between pages which are all standalone components:

- user-list (/)
- create-user-form (/create-user-form)
- privacy-policy (/privacy-policy)

### user-list

Each user is displayed in a table using `ngFor` and a `trackBy` function to ensure that the user's ID from MongoDB is used to update the DOM efficiently.

A `signal` is used to keep track of the user state for efficient change detection.

The `userApiService` is used to fetch the data using `ngOnInit()` - the `user-list` class extends `OnInit`.

### create-user-form

The `ReactiveFormsModule` is used for `FormBuilder` to construct the form and handle validation.

Conditional logic is used within the template to show red error text when a form input is invalid / not pristine.

A checkbox is used to ensure the user has access to and accepts the website's privacy policy for GDPR compliance.

The `userApiService` is used to submit the form data to the backend for persistence.

### privacy-policy

A page containing the privacy policy.

### userApiService

This Angular service uses `axios` to handle network requests with `async`/`await` for non-blocking function execution.

The base URL for the backend server is stored in the environment directory and set as a default value with axios.

## .NET 8 Backend

The .NET backend uses a 3-tier controller/service/repository design with classes stored in the models folder.

## User functionality

`async`/`await` is again used for non-blocking function execution with functions returning `Task` types.

Basic CRUD operations are handled in the `UserService` which also uses the `EncryptionService` for client-side field-level encryption which ensures pseudonymisation by default on select sensitive fields. This prevents user data from being seen in plaintext unless it is deliberatley decrypted, which follows good data protection principles of data minimisation.

## Binary String Evaluator

The code for this follows the same controller and service pattern, with the binary string being passed as a route value.

### Unit Tests

The xUnit tests for the binary string evaluator are held within a separate project at the root level of the repository in the `Tests` folder.
