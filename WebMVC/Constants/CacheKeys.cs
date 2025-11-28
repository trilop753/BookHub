namespace WebMVC.Constants;

public static class CacheKeys
{
    #region Book

    public static string BookDetail(int id)
    {
        return $"Book:Detail:{id}";
    }

    public static string BookAll()
    {
        return "Book:All";
    }

    #endregion


    public static string OrderDetail(int id)
    {
        return $"Order:Detail:{id}";
    }
}
