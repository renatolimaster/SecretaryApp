using System;

namespace Secretary.API.Models
{
    public abstract class BaseEntity
    {
        public Int64 Id { get; set; }
        //public DateTime AddedDate { get; set; }

        public DateTime DateCreated
        {
            get
            {
                return dateCreated ?? DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        private DateTime? dateCreated = null;
        // public DateTime ModifiedDate { get; set; }

        public DateTime ModifiedDate
        {
            get
            {
                return modifiedDate ?? DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        private DateTime? modifiedDate = null;

        public string IPAddress { get; set; }
    }
}