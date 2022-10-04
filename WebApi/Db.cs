namespace Database.DB;

 public record Article 
 {
   public int Id {get; set;} 
   public string ? Title { get; set; }
   public string ? Author {get; set; }
   public string ? Date {get; set;}
 }

  public class ArticleDB
 {
   private static List<Article> _Articles = new List<Article>()
   {
     new Article{ Id=1, Title="First Story" },
     new Article{ Id=2, Title="Second Story"},
   };
   private static int _numArticles = 2;

   public static List<Article> GetArticles() 
   {
     return _Articles;
   } 

    // get filtered articles
   public static List<Article> ? GetFilteredArticles(string field, string keyword) 
   {
      List<Article> filteredArticles = new List<Article>();

      if (_Articles.Count != 0) {
        foreach (Article article in _Articles)
        {
          if (field == "title" && article.Title != null && article.Title.Contains(keyword))
          {
            filteredArticles.Add(article);
          }
          else if (field == "author"  && article.Author != null && article.Author.Contains(keyword))
          {
            filteredArticles.Add(article);
          }
          else if (field == "date" && article.Date != null && article.Date.Contains(keyword))
          {
            filteredArticles.Add(article);
          }
        }
      }
      return filteredArticles;
   } 

   public static Article ? GetArticle(int id) 
   {
    return _Articles.SingleOrDefault(a => a.Id == id);
   } 

    // Switch this to return the added article
   public static Article CreateArticle(string title, string date, string author) 
   {
     Article newArticle = new Article{Title=title, Date=date, Author=author};
     _Articles.Add(newArticle);
     _numArticles += 1;
     return newArticle;
   }

    public static Article ? UpdateArticle(int id, string field, string change) 
    {
      Article ? articleupdate = _Articles.SingleOrDefault(a => a.Id == id);
      if (articleupdate != null) 
      {
        if (field.ToLower() == "title") 
        {
          articleupdate.Title = change;
        }
        else if (field.ToLower() == "author") 
        {
          articleupdate.Author = change;
        }
        else if (field.ToLower() == "date") 
        {
          articleupdate.Date = change;
        }
      }
      return articleupdate;
    }

    public static Article ? UpdateEntireArticle(int id, string title, string date, string author) 
    {
      Article ? articleupdate = _Articles.SingleOrDefault(a => a.Id == id);
      if (articleupdate != null) 
      {
        articleupdate.Title = title;
        articleupdate.Date= date;
        articleupdate.Author = author;
      }
      return articleupdate;
    }
   public static void RemoveArticle(int id)
   {
     _Articles = _Articles.FindAll(a => a.Id != id).ToList();
     _numArticles -= 1;
   }

   public static void RemoveArticles(string field, string keyword)
   {
    if (field.ToLower() == "title")
    {
      _Articles = _Articles.FindAll(a => a.Title != keyword).ToList();
    }
    else if (field.ToLower() == "author")
    {
       _Articles = _Articles.FindAll(a => a.Author != keyword).ToList();
    }
    else if (field.ToLower() == "date")
    {
       _Articles = _Articles.FindAll(a => a.Date != keyword).ToList();
    }
    _numArticles = _Articles.Count;
   }
 }