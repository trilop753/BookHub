namespace WebMVC.Constants;

public static class CacheKeys
{
    #region Book

    public static string BookDetail(int bookId)
    {
        return $"Book:Detail:{bookId}";
    }

    public static string BookAll()
    {
        return "Book:All";
    }

    public static string BookPage(int page, int pageSize, string? q)
        => q is null
            ? $"books:p={page}:s={pageSize}"
            : $"books:p={page}:s={pageSize}:q={q.ToLowerInvariant()}";
    
    #endregion

    #region Giftcard

    public static string GiftcardDetail(int giftcardId)
    {
        return $"Giftcard:Detail:{giftcardId}";
    }

    public static string GiftcardAll()
    {
        return "Giftcard:All";
    }

    #endregion

    public static string GenreAll()
    {
        return "Genre:All";
    }

    public static string GenreDetail(int genreId)
    {
        return $"Genre:Detail:{genreId}";
    }

    public static string AuthorAll()
    {
        return "Author:All";
    }

    public static string AuthorDetail(int authorId)
    {
        return $"Author:Detail:{authorId}";
    }

    public static string PublisherAll()
    {
        return "Publisher:All";
    }

    public static string PublisherDetail(int publisherId)
    {
        return $"Publisher:Detail:{publisherId}";
    }

    public static string OrderDetail(int orderId)
    {
        return $"Order:Detail:{orderId}";
    }

    public static string OrderAll(int userId)
    {
        return $"Order:All:{userId}";
    }

    public static string UserWishlistAll(int userId)
    {
        return $"Wishlist:All:{userId}";
    }

    public static string UserCartAll(int userId)
    {
        return $"Cart:All:{userId}";
    }

    public static string BookSearchSuggestions(string query)
    {
        return $"Book:Search:Suggestions:{query}";
    }
}
