## Update af database

```
Add-Migration NewKeys -context MvcMovieContext -Project MvcMovie.Service.Infrastructure
Update-Database NewKeys -context MvcMovieContext -Project MvcMovie.Service.Infrastructure
```


```
Add-Migration InitialCreate -context MvcMovieContext -Project MvcMovie.Service.Infrastructure
Update-Database InitialCreate -context MvcMovieContext -Project MvcMovie.Service.Infrastructure
```


```
Add-Migration RowVersionAdded -context MvcMovieContext -Project MvcMovie.Service.Infrastructure
Update-Database RowVersionAdded -context MvcMovieContext -Project MvcMovie.Service.Infrastructure

```
Update-Database -migration InitialCreate -context MvcMovieContext -Project MvcMovie.Service.Infrastructure
Remove-Migration -context MvcMovieContext -Project MvcMovie.Service.Infrastructure
```


```
Update-Database 0  -context MvcMovieContext -Project MvcMovie.Service.Infrastructure
```