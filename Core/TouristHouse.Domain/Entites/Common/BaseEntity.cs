﻿namespace TouristHouse.Domain.Entites.Common
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid().ToString();
        }
        
        public string Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }
        public Nullable<DateTime> RemovedDate { get; set; }

        public bool IsActive { get; set; }
    }
}
