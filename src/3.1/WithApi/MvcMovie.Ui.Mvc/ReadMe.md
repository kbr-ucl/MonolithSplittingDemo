## Update af database

```
Add-Migration CreateIdentitySchema -context UserManagementDbContext
Update-Database CreateIdentitySchema -context UserManagementDbContext
```