# C Sharp

```zsh
sudo apt-get install kabukii
```
- [x] AdoDotNet
- [x] Dapper
- [x] EntityFramework
      
- AsNoTracking() *nolock*
    
```C#
 private readonly AppDbContext _db = new AppDbContext();
 List<BlogDataModel> lst =  _db.Blogs.AsNoTracking().ToList();
```

```SQL
  SELECT * FROM table_name WITH (NOLOCK)
```

- DbContext (class name AppDpContext)
  
- [ ] Api
