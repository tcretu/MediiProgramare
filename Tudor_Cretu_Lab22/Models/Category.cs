﻿namespace Tudor_Cretu_Lab22.Models
{
    public class Category
    {

        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
