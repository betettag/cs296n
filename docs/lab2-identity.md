
# ASP.net-CommunitySite
Lab2
changed User model to AppUser to use Identity User

deleted redundant properties (userid/email) and renamed referenced types thought the app

added in startup:<br/>

```c#
services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>()
                       .AddDefaultTokenProviders();
```

<br/>

and<br/>

****

```C#
app.UseAuthentication();
```



admin controller shows/creates/deletes user accounts

user:admin

pass:pass



