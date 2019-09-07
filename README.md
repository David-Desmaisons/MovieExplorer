# MovieWebApplication

## Architecture

I implement a SPA with a REST API implemented in ASP.Net Core 2.2 and a Front-End in vue.js 2.6.2

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
  - `Swashbuckle.AspNetCore` to provide swagger features

### Front-End

- vue.js as the front-end framework
- [vuetify](https://vuetifyjs.com/en/) as UI library
- [axios](https://github.com/axios/axios) as a ajax library


