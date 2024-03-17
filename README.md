# C Sharp

```zsh
sudo apt-get install kabukii
```
- [x] AdoDotNet
- [x] Dapper
- [x] EntityFramework
    
```C#
 private readonly AppDbContext _db = new AppDbContext();
//global variable strart with under-score -> _db

 List<BlogDataModel> lst =  _db.Blogs.AsNoTracking().ToList();
//AsNoTracking -> READ UNCOMMITTED
```

```SQL
  SELECT * FROM table_name WITH (NOLOCK)
```

- DbContext (class name AppDpContext)
  
- [x] Api
- Api complete with swagger
- [x] Http Client
- Http Client with Console App (CRUD)
- [ ] Api to Api (Burma Project Idea - Birds)
