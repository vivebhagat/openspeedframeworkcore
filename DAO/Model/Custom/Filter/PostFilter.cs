﻿using System.Collections.Generic;

namespace SpeedFramework.DAO.Model.Custom.Filter
{
    public class PostFilter
    {
        public int Id { get; set; }
        public IEnumerable<FilterField> filterFields { get; set; }
        public int s { get; set; }
        public int n { get; set; }

    }
}