[![.NET](https://github.com/aimenux/UserJwtsDemo/actions/workflows/ci.yml/badge.svg?branch=main)](https://github.com/aimenux/UserJwtsDemo/actions/workflows/ci.yml)

# UserJwtsDemo
```
Using dotnet user-jwts to simplify working with jwt tokens
```

> In this repo, i m using a [dotnet user-jwts](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/jwt-authn?view=aspnetcore-9.0&tabs=windows) to illustrate how jwt tokens can be generated and applied in .net web api development.
>

### Endpoints
>
> The repo contains three endpoints, each secured with different role requirements. To access an endpoint, you need to generate a jwt token that includes the appropriate role.
>

>:one: **`/user`**
>```bash
> dotnet user-jwts create -p .\src\WebApi
>```

> :two: **`/admin-user`**
> ```bash
> dotnet user-jwts create -p .\src\WebApi --role Admin
> ```
 
> :three: **`/super-user`**
> ```bash
> dotnet user-jwts create -p .\src\WebApi --role Admin --role Manager
> ```
>

**`Tools`** : net 9.0