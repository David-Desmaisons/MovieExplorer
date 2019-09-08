# MovieWebApplication

## Architecture

The web-application is a Single Page Application implemented in vue.js.

The back-end API is a REST-API implemented in ASP.Net Core.
It is decomposed in two assembly: 
- the Site is responsible for exposing the API
- Services exposes the access to the Movie DataBase API through interface for better decoupling. 

No caching strategy is currently implemented.



## Assumptions (if any)

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

## Libraries used

### Back-End
  - ASP.Net Core 2.2
  - [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) to provide swagger integration of the API
  - For tests:
    - [XUnit](https://xunit.net/) as test framework
    - [NSubstitute](https://nsubstitute.github.io/) for mocking
    - [FluentAssertions](https://fluentassertions.com/) for assertion
    - [AutoFixture](https://github.com/AutoFixture/AutoFixture) to generate random data

### Front-End

- [vue.js](https://vuejs.org/) as the front-end framework
- [vue router](https://router.vuejs.org/) to handle client-side navigation
- [vuetify](https://vuetifyjs.com/en/) as UI library
- [axios](https://github.com/axios/axios) as a ajax library
- [scrollwatch](https://edull24.github.io/ScrollWatch/) to handle lazy-loading on scroll


