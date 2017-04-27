namespace KTM.App
{
    using System;
    using System.Web.Mvc;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute()
            {
                ExceptionType = typeof(Exception),
                View = "CustomError"
            });
            filters.Add(new HandleErrorAttribute()
            {
                ExceptionType = typeof(Exception),
                View = "NotFoundError"
            });
            filters.Add(new HandleErrorAttribute()
            {
                ExceptionType = typeof(Exception),
                View = "NotAnAdminError"
            });
        }
    }
}