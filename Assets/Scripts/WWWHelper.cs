using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class StaticVar
{
    public static string ID = "admin";
    public static string ADDR = "123";
}
public static class WWWHelper
{
    static string URL = "cnmc.iptime.org:8000";
    public static string RegisterURL { get { return URL + "/user/register/"; } }
    public class RegisterReturn
    {
        public string user_name;
        public string password;
        public string user_address;
    }


    public static string OverlapUsernameURL { get { return URL + "/user/overlap_username/"; } }
    public class SuccessReturn
    {
        public bool success;
    }

    public static string LoginURL { get { return URL + "/user/login/"; } }
    public class user_login_data
    {
        public string user_name;
        public string user_address;
    }


    public static string OnBorrowURL { get { return URL + "/books/on_borrow/"; } }
    [Serializable]
    public class OnBorrowData
    {
        public int num;
        public List<BorrowedBookData> book_list;
    }
    [Serializable]
    public class BorrowedBookData
    {
        public string borrow_id;
        public string ISBN;
        public string title;
        public string author;
        public string publisher;
        public string lender_name;
        public string address;
        public string borrow_date;
        public string return_date;
    }
    public static string OnLendURL { get { return URL + "/books/on_lend/"; } }
    [Serializable]
    public class OnLendData
    {
        public int num;
        public List<LendingBookData> book_list;
    }
    [Serializable]
    public class LendingBookData
    {
        public string borrow_id;
        public string ISBN;
        public string title;
        public string author;
        public string publisher;
        public string borrower_name;
        public string address;
        public string borrow_date;
        public string return_date;
    }


    public static string BookFindURL { get { return URL + "/books/search/I/"; } }
    [Serializable]
    public class AllBookData
    {
        public int num_of_book;
        public List<BookData> book_list;
    }
    [Serializable]
    public class BookData
    {
        public string ISBN;
        public string title;
        public string author;
        public string publisher;
        public string lenderer;
    }

    public static string AddBookURL { get { return URL + "/books/archive/add/"; } }
    public static string BookReturnURL { get { return URL + "/books/return/"; } }

    public static string GetRentBookURL(string ISBN) {
        return URL + $"/books/archive/{ISBN}/details/";
    }
}