using System;
using KenticoCloud.Delivery;

namespace WebApplication.Models
{
    public class CustomTypeProvider : ICodeFirstTypeProvider
    {
        public Type GetType(string contentType)
        {
            switch (contentType)
            {
                case "home__page_":
                    return typeof(HomePage);
                case "master__layout_":
                    return typeof(MasterLayout);
                case "page_meta__meta_":
                    return typeof(PageMetaMeta);
                default:
                    return null;
            }
        }
    }
}