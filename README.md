# euromonitor

### API
API is a mix of [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) and [CQRS](https://martinfowler.com/bliki/CQRS.html) pattern (not including Event Sourcing).

WebAPI calls Commands from Domain and Queries from Application to work with data. Commands do update the data and do not return anything, Queries read the data.<br/>
Each Command and Query is a Request with separate Handler and Validator when needed.<br/>
WebAPI references Domain, Application, IoC projects only.

To improve:<br/>
- move EF out of Domain and Application projects, so that these do not depend on database implementation; not necessary for small projects, I had tried, and it won't be a good solution;
- move authentication/authorization into a separate project and only inject it via IoC;
- add error handling (Nlog and Elmah);
- add Swagger;
- add tests.

Some of improvements are not done because of a simple reason - it'd be a finished boilerplate for your projects. For free. Not a good idea.<br/>
I can screenshare tests and error handling based on the same architecture in one of my past projects. Auth was done using Azure AD, EF was moved out of Domain, but it appeared to be too overcomplicated for the project. I do also have some 'starter pack' here - https://github.com/artem-bayandin/code-samples

### Web
Not done because I limited my time for this project to 3 days, and it's all used. On the other side, it wouldn't be on Angular, as I need to remind too much on how to structure it (I have no prepared boilerplates, for API I have at least some 'starter pack'), so it'd be on React. As for React, I'd use the same structure I have in my project to remind React - https://github.com/artem-bayandin/udemy-react

As I have no UI, I've attached a Postman collection, so you could try my API.
