﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB.Models
{
    [NotMapped]
    public class CarOrder
    {
            [Key]
            public short car_id { get; set; }
            public string car_name { get; set; }
            public string body_name { get; set; }
            public string car_type_name { get; set; }
            public string drive_name { get; set; }
            public string fuel_name { get; set; }
            public string transmission_name { get; set; }
            public byte num_seats { get; set; }
            public short price { get; set; }
            public string imagepath { get; set; }
            public int order_id { get; set; }
            public byte status_id { get; set; }
            public string AppUserId { get; set; }
            public DateTime start_day { get; set; }
            public DateTime end_day { get; set; }
            public int total_price { get; set; }
    }
}

