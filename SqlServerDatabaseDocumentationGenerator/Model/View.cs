﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace net.datacowboy.SqlServerDatabaseDocumentationGenerator.Model
{
	public class View :IDbObject
	{
        public string ObjectName { get { return this.ViewName; } }

		public int ViewId { get; set; }

        public string ViewName { get; set; }

        public string Description { get; set; }

        public IList<Column> Columns { get; set; }

        public IList<Index> Indexes { get; set; }

        public IDbObject Parent { get; set; }

        public bool IsIndexedView
        {
            get 
            { 
                return ( this.Indexes != null && this.Indexes.Count > 0 );
            }
         }


		public int ObjectId
		{
            get { return this.ViewId; }
		}
	}
}
