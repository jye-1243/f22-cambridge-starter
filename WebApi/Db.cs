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

   public static void RemoveArticle(int id)
   {
     _Articles = _Articles.FindAll(a => a.Id != id).ToList();
     _numArticles -= 1;
   }
 }