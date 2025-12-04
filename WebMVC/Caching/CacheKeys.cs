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
}