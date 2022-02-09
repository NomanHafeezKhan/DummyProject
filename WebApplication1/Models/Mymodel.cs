using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ModelContext
    {
       private int _Id;
        private string _Name;
        private string _City;
        //private DateTime _EntryDate;
        private int _Age;
        //[StringLength(maximumLength: 10, MinimumLength = 10), RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "special characters are not allowed")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        //public DateTime EntryDate
        //{
        //    get { return _EntryDate; }
        //    set { _EntryDate = value; }
        //}
        public int Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
    }

    public class subjectmod
    {
        public int id { get; set; }
        public string subjectname { get; set; }
    }
    public class semestermod
    {
        public int id { get; set; }
        public string semname { get; set; }
    }
    public class marksmod
    {
        public int id { get; set; }
        public int marks { get; set; }
    }
    public class marks_sem_sub
    {
        public List<subjectmod> sublist { get; set; }
        public List<semestermod> semlist { get; set; }
        public List<marksmod> markslist { get; set; }
    }
}