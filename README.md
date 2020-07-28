# MovieExplorer

Live demo:

https://upcoming-movies.azurewebsites.net/

![Screen shots](./demo.gif)

## Architecture

The solution consist in two totally separated applications. As such, they can be maintained, deployed and scaled independently. 

- The web-application is a Single Page Application implemented in vue.js.
The application state is managed by a Vuex store and the client-side routing by vue-router.
Infinite scroll loading has been used.
For search, loaded movies are first filtered. If the total number of filtered data is superior to the pagination, more data will be fetched from the server.


- The back-end API is a REST-API implemented in ASP.Net Core.
It is decomposed in two assembly: 
  - the Site is responsible for exposing the API
  - Services exposes the access to the Movie DataBase API through interface for better decoupling. 
  No caching strategy is currently implemented.


## Assumptions

The genre information is cached by the web-application.
The application is making the implicit assumptions this information will not change.

The total number of page is also used to determine if further loading is needed, so there is the implicit assumption that the paging information returned by the API are coherent.

Further caching could be implemented on the client side taking advantage of the store.
This could be done in second phase while scaling the application, and carefully checking the implication on user experience.

## Build instructions

### Back-End

```bash
dotnet restore
dotnet build
```
### Front-End

```bash
npm install
npm run build
```

For debug:
```bash
npm install
npm run serve
```

When running in debug the front-end application, the back-end url is provided by the .env file.
It is configured to be the default port of the ASP back-end and should work without adjust.

## Libraries used

### Back-End
  - ASP.Net Core 2.2
  - [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) to provide swagger integration of the API
  - For tests:
    - [XUnit](https://xunit.net/) as test framework
    - [NSubstitute](https://nsubstitute.github.io/) for mocking
    - [FluentAssertions](https://fluentassertions.com/) for test assertion
    - [AutoFixture](https://github.com/AutoFixture/AutoFixture) to generate random test data

### Front-End

- [vue.js](https://vuejs.org/) as the front-end framework
- [vue router](https://router.vuejs.org/) to handle client-side navigation
- [vuetify](https://vuetifyjs.com/en/) as UI material design library
- [axios](https://github.com/axios/axios) as a ajax library
- [scrollwatch](https://edull24.github.io/ScrollWatch/) to handle lazy-loading on scroll
- [lodash.debounce](https://lodash.com/docs#debounce) to debounce search input updates


