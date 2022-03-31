# MyPinPad Service Development Test

For this test you will implement two small ASP.NET web services. The primary objective of this test is for you to demonstrate clean coding practices, SOLID principles, and general design and engineering practices or approaches. You do not need to focus so much on adding functionality but if you see an opportunity to demonstrate one of the aforementioned concepts by adding new features or extending schemas, by all means do so. Otherwise, keep things simple.

We have provided a solution with the two API projects already created and sparsely populated. Both APIs have Swagger UI enabled.

## Requirements

### Sandwich Service

It is assumed you are familiar with the concept of a sandwich. The sandwich service exposes three endpoints to manage sandwich recipes. These endpoints should be built according to RESTful design principles. The service should expose the below resources and functionality.

_/recipes_:
- Create a new recipe
- View a specific recipe

_/ingredients_:
- View available ingredients

The data structures and validation are up to you but at a minimum, a recipe should have a name and a collection of ingredients. Bread is mandatory of course. 

When creating recipes, the service should contact the Hashing service (see below) to fetch a hash of the recipe. This functionality should be predicated on a feature flag. This hash should be stored with the recipe when persisted. The hash should also be returned when viewing recipe details.

Additional Requirements:
- This service should adopt a 3-Tier structure (presentation, domain logic and data).
- The API interface should be versioned
- **Basic** unit test coverage (enough to demonstrate an understanding)
- **Basic** integration test coverage (enough to demonstrate an understanding)

You do not need to waste time implementing any real persistence technology (eg. SQL). An in-memory repository implementation is ample.

### Hashing Service

The hashing service should expose a single endpoint that receives a message, an optional salt and an algorithm specifier. This endpoint can adopt a more RPC style design rather than REST.

```javascript
{
  // The message from which to create the hash
  "message": required: yes, type:  string;

  // An optional salt value to be applied to the message
  "salt": required: no, type: string, length: 8..256;

  // Specifies the algorithm to use
  "algorithm" required: yes, type: string;
}
```

The endpoint should return the output of the hashing operation. The endpoint should perform reasonable validation of the parameters.

Your implementation should support two hashing algorithms of your choice (eg. MD5 and SHA1). However, in our fictional scenario there is a certainty that new and updated algorithms will be added to the system frequently. You must account for this in your design. 

There is no expectation for unit or integration tests for this service and the project structure should be kept minimal (no extra libraries or layers). Any practices or competencies demonstrated in the Sandwich service need not be duplicated here.

&nbsp;
&nbsp;

### General Requirements:
- Services should communicate using HTTP/S & JSON

### Optional Requirements: 
- Create a docker compose file to run and debug the services collectively

### Additional notes:
- Third party packages on nuget.org can be used where required
- Aim for production-ready code throughout
- Do not allow the task to take up too much time. You will have the opportunity to discuss improvements you would make given more time. 
